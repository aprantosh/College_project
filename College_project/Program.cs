using System;
using System.Collections.Generic;

class Student
{
    public string Name { get; set; }
    public int RollNumber { get; set; }
    public College College { get; set; }

    public static Student CreateStudent()
    {
        Console.WriteLine("Enter student name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter student roll number:");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        return new Student { Name = name, RollNumber = rollNumber };
    }
}

class Teacher
{
    public string Name { get; set; }
    public string Subject { get; set; }

    public static Teacher CreateTeacher()
    {
        Console.WriteLine("Enter teacher name:");
        string name = Console.ReadLine();

        Console.WriteLine("Enter teacher subject:");
        string subject = Console.ReadLine();

        return new Teacher { Name = name, Subject = subject };
    }
}

class College
{
    public string Name { get; set; }
    public string Location { get; set; }
    public List<Student> Students { get; set; }
    public List<Teacher> Teachers { get; set; }

    public College(string name, string location)
    {
        Name = name;
        Location = location;
        Students = new List<Student>();
        Teachers = new List<Teacher>();
    }

    public void AddStudent()
    {
        Student student = Student.CreateStudent();
        student.College = this;
        Students.Add(student);
        Console.WriteLine("Student added successfully!");
    }

    public void RemoveStudent()
    {
        Console.WriteLine("Enter student roll number to remove:");
        int rollNumber = Convert.ToInt32(Console.ReadLine());

        Student studentToRemove = Students.Find(s => s.RollNumber == rollNumber);

        if (studentToRemove != null)
        {
            Students.Remove(studentToRemove);
            Console.WriteLine("Student removed successfully from " + Name);
        }
        else
        {
            Console.WriteLine("Student with the provided roll number not found.");
        }
    }

    public void AddTeacher()
    {
        Teacher teacher = Teacher.CreateTeacher();
        Teachers.Add(teacher);
        Console.WriteLine("Teacher added successfully!");
    }

    public void RemoveTeacher()
    {
        Console.WriteLine("Enter teacher name to remove:");
        string teacherName = Console.ReadLine();

        Teacher teacherToRemove = Teachers.Find(t => t.Name.Equals(teacherName, StringComparison.OrdinalIgnoreCase));

        if (teacherToRemove != null)
        {
            Teachers.Remove(teacherToRemove);
            Console.WriteLine("Teacher removed successfully from " + Name);
        }
        else
        {
            Console.WriteLine("Teacher with the provided name not found.");
        }
    }

    public void DisplayStudents()
    {
        Console.WriteLine($"Students in {Name}:");
        foreach (var student in Students)
        {
            Console.WriteLine($"Name: {student.Name}, Roll Number: {student.RollNumber}");
        }
    }

    public void DisplayTeachers()
    {
        Console.WriteLine($"Teachers in {Name}:");
        foreach (var teacher in Teachers)
        {
            Console.WriteLine($"Name: {teacher.Name}, Subject: {teacher.Subject}");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Step 5: Create colleges
        College college1 = new College("OKlahoma Central University", "Oklahoma City");
        College college2 = new College("Dallas Central University", "Dallas");

        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("=== College Management System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Remove Student");
            Console.WriteLine("3. Add Teacher");
            Console.WriteLine("4. Remove Teacher");
            Console.WriteLine("5. Display Students");
            Console.WriteLine("6. Display Teachers");
            Console.WriteLine("7. Exit Program");
            Console.WriteLine("Enter your choice:");

            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Select a college:");
                    Console.WriteLine("1. " + college1.Name);
                    Console.WriteLine("2. " + college2.Name);
                    string collegeChoice = Console.ReadLine();

                    if (collegeChoice == "1")
                        college1.AddStudent();
                    else if (collegeChoice == "2")
                        college2.AddStudent();
                    else
                        Console.WriteLine("Invalid college choice.");

                    break;
                case "2":
                    Console.WriteLine("Select a college:");
                    Console.WriteLine("1. " + college1.Name);
                    Console.WriteLine("2. " + college2.Name);
                    collegeChoice = Console.ReadLine();

                    if (collegeChoice == "1")
                        college1.RemoveStudent();
                    else if (collegeChoice == "2")
                        college2.RemoveStudent();
                    else
                        Console.WriteLine("Invalid college choice.");

                    break;
                case "3":
                    Console.WriteLine("Select a college:");
                    Console.WriteLine("1. " + college1.Name);
                    Console.WriteLine("2. " + college2.Name);
                    collegeChoice = Console.ReadLine();

                    if (collegeChoice == "1")
                        college1.AddTeacher();
                    else if (collegeChoice == "2")
                        college2.AddTeacher();
                    else
                        Console.WriteLine("Invalid college choice.");

                    break;
                case "4":
                    Console.WriteLine("Select a college:");
                    Console.WriteLine("1. " + college1.Name);
                    Console.WriteLine("2. " + college2.Name);
                    collegeChoice = Console.ReadLine();

                    if (collegeChoice == "1")
                        college1.RemoveTeacher();
                    else if (collegeChoice == "2")
                        college2.RemoveTeacher();
                    else
                        Console.WriteLine("Invalid college choice.");

                    break;
                case "5":
                    college1.DisplayStudents();
                    college2.DisplayStudents();
                    break;
                case "6":
                    college1.DisplayTeachers();
                    college2.DisplayTeachers();
                    break;
                case "7":
                    exitProgram = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }

        // Wait for user input to exit
        Console.ReadLine();
    }
}
