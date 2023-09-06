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

public class Player
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }
    public List<int> Skills { get; set; }
}


public class PlayerAnalyzer : IPlayerAnalyzer
{
    public double CalculateScore(List<Player> players)
    {
        double score = 0;

        foreach (var player in players)
        {
            double skillsAverage = player.Skills.Sum() / (double)player.Skills.Count;
            double contribution = player.Age * player.Experience * skillsAverage;

            if (player.Age < 18)
            {
                contribution *= 0.5;
            }

            if (player.Experience > 10)
            {
                contribution *= 1.2;
            }
            score += contribution;
        }

        return score;
    }
}