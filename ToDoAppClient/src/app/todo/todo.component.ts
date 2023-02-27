import {Component, OnInit} from '@angular/core';
import {ITask} from "../../models/ITask";
import {TaskService} from "../../services/task.service";
import {MatDialog} from "@angular/material/dialog";
import {EditTaskComponent} from "../edit-task/edit-task.component";
import {MessageService} from "../../services/message.service";
import {DatePipe} from "@angular/common";

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit {

  taskObj = {} as ITask
  taskArr: ITask[] = [];
  username: string = '';
  userId: number = 0
  today= new Date();
  tempDate!:Date
  // isOverDue:boolean=false

  constructor(private taskService: TaskService, private dialog: MatDialog, private message: MessageService) {
  }


  openDialog(etask: ITask) {
    let dialogRef = this.dialog.open(EditTaskComponent, {
      height: '400px',
      width: '600px',
      data: {
        etask: {
          title: etask.title,
          description: etask.description,
          id: etask.id,
          isCompleted: etask.isCompleted,
          expirationTime: etask.expirationTime,
          group:etask.group
        }
      }
    });
    dialogRef.afterClosed().subscribe(() => {
      this.getAllTasks()
    })
  }

  addTask(etask: ITask) {
    this.taskObj.username = this.username
    etask.group = this.taskObj.group
    etask.isCompleted = false
    etask.userId = this.userId
    etask.expirationTime = new Date(this.taskObj.expirationTime.setHours(1))
    this.taskService.addTask(etask).subscribe((res: any) => {
      console.log(res)
      this.getAllTasks()
      this.taskObj.title = ""
      this.taskObj.description = ""
      this.taskObj.group = ""
      this.message.successMessage("Task successfully added")
    })
  }

  getUserId(): number {
    this.taskService.getId(this.username).subscribe((res: number) => {
      this.userId = res
    })
    console.log(this.username)
    console.log(this.userId)
    return this.userId
  }

  getAllTasks() {
    this.taskService.getAllTasks(this.username).subscribe((res: ITask[]) => {
      this.taskArr = res;
      console.log(this.taskArr)
    })
  }

  removeTask(etask: ITask) {
    console.log(etask)
    this.taskService.removeTask(etask).subscribe(() => {
      this.getAllTasks()
      this.message.successMessage("Task successfully removed")
    })
  }

  ngOnInit(): void {
    this.username = localStorage.getItem("username")!
    this.getUserId()
    this.taskObj = {} as ITask
    this.getAllTasks()
    // console.log(this.today+'2')
    // console.log(this.taskObj.expirationTime+'1')
  }

  isOverDue(time:Date){
   this.tempDate = new Date(time)
    // console.log(this.today.getMilliseconds()+'   1')
    // console.log(this.tempDate.getMilliseconds()+'   2')
    // console.log(this.tempDate<this.today)
    if(this.tempDate>this.today)
      return false;
    if(this.tempDate<this.today)
      return true;
    return false
  }

}
