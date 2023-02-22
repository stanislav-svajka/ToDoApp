import {Component, OnInit} from '@angular/core';
import {TaskService} from "../../services/task.service";
import {ITask} from "../../models/ITask";

@Component({
  selector: 'app-todo',
  templateUrl: './todo.component.html',
  styleUrls: ['./todo.component.css']
})
export class TodoComponent implements OnInit{

  taskObj={} as ITask
  taskArr:ITask[]=[];

  constructor(private taskService: TaskService) {
  }

  addTask(etask:ITask){
    this.taskObj.username=localStorage.getItem('username')!
    this.taskService.addTask(etask).subscribe(res=>{
      console.log(res)
    }, error => {
      alert(error)
    })
  }

  getAllTasks(){
    this.taskService.getAllTasks().subscribe(res=>{
      this.taskArr=res;
    }, error => {
      alert(error)
    })
  }

  ngOnInit(): void {
    this.taskObj={}as ITask
    this.getAllTasks()
  }

}
