namespace AdvancedConstructor
{
  
        class Student
        {
            int id;
            string name;
            int age;

            // Constructor 1
            public Student()
            {
                Console.WriteLine("Default constructor");
            }

            // Constructor 2
            public Student(int id) : this()
            {
                this.id = id;
                Console.WriteLine("ID constructor");
            }

            // Constructor 3
            public Student(int id, string name) : this(id)
            {
                this.name = name;
                Console.WriteLine("ID + Name constructor");
            }

            // Constructor 4
            public Student(int id, string name, int age) : this(id, name)
            {
                this.age = age;
                Console.WriteLine("ID + Name + Age constructor");
            }
        }

        // private constructor
        class GameStats
        {
            public int HighScore { get; set; }
            public int CurrentScore { get; set; }
            public int LivesAvailable { get; set; }

            private static GameStats instance;

            // private constructor
            private GameStats()
            {
                HighScore = 0;
                CurrentScore = 0;
                LivesAvailable = 3;
            }

            public static GameStats GetInstance()
            {
                if (instance == null)
                {
                    instance = new GameStats();
                }
                return instance;
            }
        }
        class Level1
        {
            GameStats stats = GameStats.GetInstance();

            public void Play()
            {
                stats.CurrentScore += 100;
                stats.HighScore = stats.CurrentScore;
                stats.LivesAvailable--;
            }
        }

        class Level2
        {
            GameStats stats = GameStats.GetInstance();

            public void Play()
            {
                stats.CurrentScore += 200;
                stats.HighScore = Math.Max(stats.HighScore, stats.CurrentScore);
            }
        }
    class Program
    {
        static void Main()
        {
            Level1 lv1 = new Level1(); // obj1
            lv1.Play();

            Level2 lv2 = new Level2(); // obj2
            lv2.Play();
        }
    }





}

