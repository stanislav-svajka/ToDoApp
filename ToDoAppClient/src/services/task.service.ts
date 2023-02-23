import {Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {ITask} from "../models/ITask";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  constructor(private http: HttpClient) {
  }

  getId(username:string){
    return this.http.get<number>('https://localhost:5001/api/User/userid/'+username)
  }

  addTask(task:ITask) : Observable<ITask>{
    return this.http.post<ITask>('https://localhost:5001/api/Task',task)
  }

  getAllTasks(username:string) : Observable<ITask[]>{
    return this.http.get<ITask[]>('https://localhost:5001/api/Task/user/'+username)
  }

  removeTask(task:ITask){
    return this.http.delete<boolean>('https://localhost:5001/api/Task/'+task.id,{responseType:"json"})
  }
}
