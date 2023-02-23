import {Component, Inject, OnInit} from '@angular/core';
import {TaskService} from "../../services/task.service";
import {ITask} from "../../models/ITask";
import {MAT_DIALOG_DATA, MatDialog} from "@angular/material/dialog";
import {IDialog, IDialogResult} from "../../models/IDialog";
import {MessageService} from "../../services/message.service";

@Component({
  selector: 'app-edit-task',
  templateUrl: './edit-task.component.html',
  styleUrls: ['./edit-task.component.css']
})
export class EditTaskComponent implements OnInit{

  username:string=''



  isCompleted=false
  constructor(private taskService:TaskService, @Inject(MAT_DIALOG_DATA) public data:IDialog,private dialog:MatDialog, private message:MessageService) {
}

  updateTask(etask:ITask){
    etask.group='dsdsds'
    etask.userId=1
    etask.isCompleted=this.isCompleted

    console.log(etask)
    this.taskService.updateTask(etask).subscribe(()=>{
    })
    this.message.successMessage("Successfully updated your task")
    this.dialog.closeAll();

  }
  onNoClick() {
    this.dialog.closeAll();
  }


  ngOnInit(): void {
  }

}
