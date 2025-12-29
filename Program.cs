using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

StudentService studentService = new StudentService();
bool exit = false;

while (!exit)
{
    Console.WriteLine("==== Student Management System ====");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Show Students");
    Console.WriteLine("3. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    switch (choice)
    {
        case "1":
            try
            {
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Age: ");
                int age = int.Parse(Console.ReadLine());

                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Student student = new Student(id, name, age, email);
                studentService.AddStudent(student);

                Console.WriteLine("Student added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            break;

        case "2":
            var students = studentService.GetAllStudents();

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
            }
            else
            {
                foreach (var s in students)
                {
                    Console.WriteLine(
                        $"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}, Email: {s.Email}"
                    );
                }
            }
            break;

        case "3":
            exit = true;
            Console.WriteLine("Goodbye!");
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }

    Console.WriteLine();
}
