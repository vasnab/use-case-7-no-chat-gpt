namespace StudentsUseCase7Tests
{
    public class PlayerAnalyzerTests
    {
        private readonly IPlayerAnalyzer sut;
        public PlayerAnalyzerTests()
        {
            sut = new PlayerAnalyzer();
        }

        [Fact]
        public void Normal_Player()
        {
            //Arange
            var testPlayers = new List<Player>() 
            { 
                new Player(){ Age = 25,Experience=5, Skills = new List<int>() {2, 2, 2 } },
            };

            //Act
            var result = sut.CalculateScore(testPlayers);

            //Assert
            Assert.Equal(250, result);
        }

        [Fact]
        public void Junior_Player()
        {
            //Arange
            var testPlayers = new List<Player>()
            {
                new Player(){ Age = 15,Experience = 3, Skills = new List<int>() {3, 3, 3 } },
            };

            //Act
            var result = sut.CalculateScore(testPlayers);

            //Assert
            Assert.Equal(67.5, result);
        }

        [Fact]
        public void Senior_Player()
        {
            //Arange
            var testPlayers = new List<Player>()
            {
                new Player(){ Age = 35,Experience = 15, Skills = new List<int>() {4, 4, 4 } },
            };

            //Act
            var result = sut.CalculateScore(testPlayers);

            //Assert
            Assert.Equal(2520, result);
        }

        [Fact]
        public void Multiple_Players()
        {
            //Arange
            var testPlayers = new List<Player>()
            {
                new Player(){ Age = 35,Experience = 15, Skills = new List<int>() {4, 4, 4 } },
                new Player(){ Age = 25,Experience=5, Skills = new List<int>() {2, 2, 2 } }
            };

            //Act
            var result = sut.CalculateScore(testPlayers);

            //Assert
            Assert.Equal(2520 + 250, result);
        }


        [Fact]
        public void Null_Skills()
        {
            //Arange
            var testPlayers = new List<Player>()
            {
                new Player(){ Age = 35,Experience = 15 },
            };

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => sut.CalculateScore(testPlayers));
        }

        [Fact]
        public void Empty_Array()
        {
            //Arange
            var testPlayers = new List<Player>();

            //Act
            var result = sut.CalculateScore(testPlayers);

            //Assert
            Assert.Equal(0, result);
        }
    }

}