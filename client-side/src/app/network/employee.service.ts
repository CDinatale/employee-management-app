import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  readonly API_URL = 'http://localhost:64588/api';

  constructor(private http: HttpClient) { }

  getEmployees():any{
    return this.http.get(this.API_URL+'/Employee');
  }

  addEmployee(employee:any){
    return this.http.post(this.API_URL+'/Employee', employee);
  }

  updateEmployee(employee:any){
    return this.http.put(this.API_URL+'/Employee', employee);
  }

  deleteEmployee(id:any){
    return this.http.delete(this.API_URL+'/Employee/'+ id);
  }
}
