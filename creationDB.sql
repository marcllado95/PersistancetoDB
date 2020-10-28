CREATE TABLE Employee(EmployeeId INT UNIQUE AUTO_INCREMENT , Name VARCHAR(25), Surname VARCHAR(25), Job VARCHAR(25), Salary INT);

INSERT into employee(id,Name,Surname,Job,Salary)values(1, "Bastian", "Schweinsteiger", "Football Player", 1000000); 
INSERT into employee(id,Name,Surname,Job,Salary)values(2, "Rodolfo", "Ataúlfo", "Undertaker", 33333); 
INSERT into employee(id,Name,Surname,Job,Salary)values(3, "Osama", "Crespo", "Actor", 2100); 

Select * from employee;
