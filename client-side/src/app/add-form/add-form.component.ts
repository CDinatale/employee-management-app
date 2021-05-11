import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { EmployeeService } from '../network/employee.service';

@Component({
  selector: 'app-add-form',
  templateUrl: './add-form.component.html',
  styleUrls: ['./add-form.component.css'],
})
export class AddFormComponent implements OnInit {
  addForm = this.formBuilder.group({
    EmployeeName: '',
    EmployeeAddress: '',
    PhoneNumber: '',
    Position: '',
  });

  employee: any

  constructor(private formBuilder: FormBuilder, private employeeService: EmployeeService) {}

  ngOnInit(): void {

  }

  addEmployee() {
    var employee = {
      EmployeeName: this.addForm.value.EmployeeName,
      EmployeeAddress: this.addForm.value.EmployeeAddress,
      PhoneNumber: this.addForm.value.PhoneNumber,
      Position: this.addForm.value.Position,
    };

    this.employeeService.addEmployee(employee).subscribe((res) => {
      console.log(res);
      window.location.reload();
    });
  }

  updateEmployee(){
    var employee = {
      EmployeeName: this.addForm.value.EmployeeName,
      EmployeeAddress: this.addForm.value.EmployeeAddress,
      PhoneNumber: this.addForm.value.PhoneNumber,
      Position: this.addForm.value.Position,
    };

    this.employeeService.updateEmployee(employee).subscribe((res) => {
      console.log(res);
      window.location.reload();
    });
  }

}
