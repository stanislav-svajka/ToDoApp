import {ITask} from "./ITask";

export interface IDialog {
  etask:ITask
}

export interface IDialogResult{
  title: string
  description:string
  userId:number
  isCompleted:boolean
  group:string
  id:number

}

