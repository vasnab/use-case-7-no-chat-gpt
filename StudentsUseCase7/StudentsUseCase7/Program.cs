// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

public class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Grade { get; set; }
    public bool Exceptional { get; set; }
    public bool HonorRoll { get; set; }
    public bool Passed { get; set; }
}

public class StudentConverter : IStudentConverter
{
    public List<Student> ConvertStudents(List<Student> students)
    {

        return students.Select(student =>
        {
            var result = new Student
            {
                Name = student.Name,
                Age = student.Age,
                Grade = student.Grade
            };

            if (student.Grade > 90)
            {
                if (student.Age < 21)
                {
                    result.Exceptional = true;
                }
                else
                {
                    result.HonorRoll = true;
                }
            }
            else if (student.Grade > 70)
            {
                result.Passed = true;
            }
            else
            {
                result.Passed = false;
            }

            return result;
        }).ToList();
    }
}