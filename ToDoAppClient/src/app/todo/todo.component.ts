import {Component, OnInit} from '@angular/core';
import {ITask} from "../../models/ITask";
import {TaskService} from "../../services/task.service";
import {MatDialog} from "@angular/material/dialog";
import {EditTaskComponent} from "../edit-task/edit-task.component";


@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit{

  taskObj={} as ITask
  taskArr:ITask[]=[];
  username: string = '';
  userId: number = 0

  constructor(private taskService: TaskService, private dialog:MatDialog) {
  }

  openDialog(etask:ITask)
  {
    let dialogRef = this.dialog.open(EditTaskComponent, {
      height: '400px',
      width: '600px',
      data:{
        etask:{
          title:etask.title,
          description:etask.description,
          id:etask.id
        }
      }
    });
  }

  addTask(etask:ITask){
    this.taskObj.username=this.username
    etask.group='work'
    etask.isCompleted=false
    etask.userId=this.userId
    this.taskService.addTask(etask).subscribe((res: any)=>{
      console.log(res)
      this.getAllTasks()
      this.taskObj.title=""
      this.taskObj.description=""
    })
  }

  getUserId():number
  {
    this.taskService.getId(this.username).subscribe((res:number) =>{
      this.userId=res
    } )
    console.log(this.username)
    console.log(this.userId)
    return this.userId
  }

  getAllTasks(){
    this.taskService.getAllTasks(this.username).subscribe((res:ITask[])=>{
      this.taskArr=res;
      console.log(this.taskArr)
    })
  }

  removeTask(etask:ITask){
    console.log(etask)
    this.taskService.removeTask(etask).subscribe(()=>{
      this.getAllTasks()
    })
  }

  ngOnInit(): void {
    this.username=localStorage.getItem("username")!
    this.getUserId()
    this.taskObj = {} as ITask
    this.getAllTasks()
  }

}
