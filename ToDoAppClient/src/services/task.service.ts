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

  addTask(task:ITask) : Observable<ITask>{
    return this.http.post<ITask>('https://localhost:5001/api/Task',task)
  }

  getAllTasks() : Observable<ITask[]>{
    return this.http.get<ITask[]>('https://localhost:5001/api/Task')
  }
}
