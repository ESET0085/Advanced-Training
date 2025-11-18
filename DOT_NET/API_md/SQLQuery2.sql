use CollegeDB

select *from Student
select *from Course
select *from Users
CREATE TABLE Users (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) -- optional: Admin, Student, Teacher, etc.
);


INSERT INTO Users (Username, PasswordHash, Role)
VALUES ('sowmya','mypassword', 'Admin');

drop table Users

truncate table Users