use CollegeDB

ALTER TABLE Student
DROP CONSTRAINT FK__Student__CourseI__4D94879B;

ALTER TABLE Student
ADD CONSTRAINT FK__Student__CourseI__4D94879B
FOREIGN KEY (CourseId) REFERENCES Course(CourseId)
ON DELETE CASCADE;


select *from Student
select *from Course

UPDATE Student
SET CourseId = 7
WHERE StudentId = 13;
