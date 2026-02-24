using System;
using System.Collections.Generic;

/*
 
 Department is a single entity.
 Multiple Students can belong to the same Department → this is many-to-one
 Each Student still has a one-to-one relation with IDCard.
 College has one-to-many relationship with Students.

 */

// One-to-One
class IDCard
{
    public int CardNumber { get; set; }
}

// Student
class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public IDCard IdCard { get; set; }   // One Student → One IDCard
    public Department Dept { get; set; }  // Many Students → One Department
}

// One-to-Many
class College
{
    public string CollegeName { get; set; }
    public List<Student> Students { get; set; }   // One College → Many Students
}

// Many-to-One
class Department
{
    public string DeptName { get; set; }
}

class Program
{
    static void Main()
    {
        // Departments
        Department cse = new Department { DeptName = "CSE" };
        Department ece = new Department { DeptName = "ECE" };

        // Students
        Student s1 = new Student
        {
            Id = 1,
            Name = "Hari",
            IdCard = new IDCard { CardNumber = 101 },
            Dept = cse   // belongs to CSE
        };

        Student s2 = new Student
        {
            Id = 2,
            Name = "Vishnu",
            IdCard = new IDCard { CardNumber = 102 },
            Dept = ece   // belongs to ECE
        };

        Student s3 = new Student
        {
            Id = 3,
            Name = "Arun",
            IdCard = new IDCard { CardNumber = 103 },
            Dept = cse   // belongs to CSE
        };

        // College
        College college = new College
        {
            CollegeName = "VCET",
            Students = new List<Student> { s1, s2, s3 }
        };

    }
}
