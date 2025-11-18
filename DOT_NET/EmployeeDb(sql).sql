create database EmployeeDB

use EmployeeDB

CREATE TABLE Employees (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Department NVARCHAR(50) NOT NULL,
    Salary DECIMAL(10,2) NOT NULL,
    Email NVARCHAR(100) UNIQUE
);

CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    UserName NVARCHAR(50) UNIQUE,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20)
);



-- Employees
INSERT INTO Employees (FullName, Department, Salary, Email)
VALUES 
('John Doe', 'IT', 65000.00, 'john.doe@company.com'),
('Emma Smith', 'HR', 52000.00, 'emma.smith@company.com'),
('Raj Patel', 'Finance', 58000.00, 'raj.patel@company.com');

-- Users
INSERT INTO Users (UserName, Password, Role)
VALUES 
('admin', 'Admin@123', 'Admin'),
('employee1', 'Emp@123', 'User');


SELECT * FROM Employees;
SELECT * FROM Users;
