Create Database EmployeeDB

create table dbo.Employee(
EmployeeId int identity(1,1),
EmployeeName varchar(500),
EmployeeAddress varchar(500),
PhoneNumber varchar(500),
Position varchar(500)
)

insert into dbo.Employee values
('Angelo Jules','119 Russell Drive, Bradford, L3X 0Z8','416-778-9988', 'Developer')

insert into dbo.Employee values
('Cora Dinatale','30 Stadium Road, Toronto, M5V 3P4','416-524-1928', 'Developer')

insert into dbo.Employee values
('Roger Flynn','390 Queens Quay, Toronto, M5V 3P4','416-776-5566', 'Manager')

insert into dbo.Employee values
('Aman Patel','45 Hamilton Road, Hamilton, M46 3Y7','416-778-8997', 'Senior Editor')


