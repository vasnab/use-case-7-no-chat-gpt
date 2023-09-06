namespace StudentsUseCase7Tests
{
    public class StudentConverterTests
    {
        private readonly IStudentConverter sut;
        public StudentConverterTests()
        {
            sut = new StudentConverter();
        }

        [Fact]
        public void High_Achiever()
        {
            //Arange
            var testStudents = new List<Student>() 
            { 
                new Student(){Name = "test", Age = 21, Grade = 91 },
            };

            //Act
            var result = sut.ConvertStudents(testStudents);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains(result, x => x.HonorRoll);
        }

        [Fact]
        public void Exceptional_Young_High_Achiever()
        {
            //Arange
            var testStudents = new List<Student>()
            {
                new Student(){Name = "test", Age = 20, Grade = 91 },
            };

            //Act
            var result = sut.ConvertStudents(testStudents);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.Contains(result, x => x.Exceptional);
        }

        [Fact]
        public void Passed_Student()
        {
            //Arange
            // grade between 71 and 90 (inclusive)
            var testStudents = new List<Student>()
            {
                new Student(){ Name = "test", Age = 20, Grade = 71 },
                new Student(){ Name = "test", Age = 20, Grade = 90 }
            };

            //Act
            var result = sut.ConvertStudents(testStudents);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.True(x.Passed));
        }

        [Fact]
        public void Failed_Student()
        {
            //Arange
            // grade between 71 and 90 (inclusive)
            var testStudents = new List<Student>()
            {
                new Student(){ Name = "test", Age = 20, Grade = 70 },
                new Student(){ Name = "test", Age = 20, Grade = 0 }
            };

            //Act
            var result = sut.ConvertStudents(testStudents);

            //Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
            Assert.All(result, x => Assert.False(x.Passed));
        }

        //Negative Test Cases
        [Fact]
        public void Empty_Array()
        {
            //Arange
            // grade between 71 and 90 (inclusive)
            var testStudents = new List<Student>();

            //Act
            var result = sut.ConvertStudents(testStudents);

            //Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }

        [Fact]
        public void Null_Array()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.ConvertStudents(null));
        }
    }

}