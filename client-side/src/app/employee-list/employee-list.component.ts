import { Component, OnInit } from '@angular/core';
import { Employee } from '../model/employee';
import { EmployeeService } from '../network/employee.service';
import { faTrashAlt } from '@fortawesome/free-solid-svg-icons';


@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {
  faTrashAlt = faTrashAlt;
  employees: Employee[] = [];

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.getEmployeeList();
  }

  getEmployeeList() {
    this.employeeService.getEmployees()
    .subscribe((data: any[]) => this.employees = data);
  }

  deleteEmployee(item: any){
    if(confirm('Are you sure you would like to delete this employee?')){
      this.employeeService.deleteEmployee(item.EmployeeId).subscribe(data=>{
        console.log(data)
      })
      window.location.reload();
    }
  }

}
