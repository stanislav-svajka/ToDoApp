import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ITask} from "../models/ITask";
import {Observable} from "rxjs";
import {IDialog, IDialogResult} from "../models/IDialog";

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  token = localStorage.getItem("token") || null

  constructor(private http: HttpClient) {
  }

  getId(username: string) {
    return this.http.get<number>('https://localhost:5001/api/User/userid/' + username)
  }

  addTask(task: ITask): Observable<ITask> {
    return this.http.post<ITask>('https://localhost:5001/api/Task', task,
      {headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)})
  }

  getAllTasks(username: string): Observable<ITask[]> {
    return this.http.get<ITask[]>('https://localhost:5001/api/Task/user/' + username,
      {headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)})
  }

  removeTask(task: ITask) {
    return this.http.delete<boolean>('https://localhost:5001/api/Task/' + task.id,
      {headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)})
  }

  updateTask(task: ITask) {
    return this.http.put<ITask>('https://localhost:5001/api/Task/' + task.id, task,
      {headers: new HttpHeaders().set("Authorization", "Bearer " + this.token)})
  }
}
