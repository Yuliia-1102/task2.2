abstract class Worker
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int WorkDay { get; set; }

    public Worker(string name, string position, int workDay)
    {
        Name = name;
        Position = position;
        WorkDay = workDay;
    }

    public abstract void FillWorkDay();

    public void Call()
    {
        Console.WriteLine($"{Name} дзвонить.");
    }

    public void WriteCode()
    {
        Console.WriteLine($"{Name} пише код.");
    }

    public void Relax()
    {
        Console.WriteLine($"{Name} відпочиває.");
    }
}

class Developer : Worker
{
    public Developer(string name) : base(name, "Розробник", 8) { }

    public override void FillWorkDay()
    {
        WriteCode();
        Call();
        Relax();
        WriteCode();
    }
}

class Manager : Worker
{
    private Random random = new Random();

    public Manager(string name) : base(name, "Менеджер", 6) { }

    public override void FillWorkDay()
    {
        int callCount1 = random.Next(1, 11);
        for (int i = 0; i < callCount1; i++)
        {
            Call();
        }

        Relax();

        int callCount2 = random.Next(1, 6);
        for (int i = 0; i < callCount2; i++)
        {
            Call();
        }
    }
}

class Team
{
    public string TeamName { get; set; }
    private List<Worker> workers = new List<Worker>();

    public Team(string teamName)
    {
        TeamName = teamName;
    }

    public void AddWorker(Worker worker)
    {
        workers.Add(worker);
    }

    public void DisplayTeamInfo()
    {
        Console.WriteLine($"Назва команди: {TeamName}");
        foreach (var worker in workers)
        {
            Console.WriteLine($"{worker.Name}");
        }
    }

    public void DisplayDetailedTeamInfo()
    {
        Console.WriteLine($"Назва команди: {TeamName}");
        foreach (var worker in workers)
        {
            Console.WriteLine($"<{worker.Name}> - <{worker.Position}> - <{worker.WorkDay}>");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        Developer developer1 = new Developer("Гордієнко Максим Валерійович");
        Developer developer2 = new Developer("Гуцулка Ксенія Володимирівна");
        Manager manager1 = new Manager("Ляшко Назар Максимович");

        Team team1 = new Team("C# розробники");
        team1.AddWorker(developer1);
        team1.AddWorker(developer2);
        team1.AddWorker(manager1);

        Console.WriteLine("Повні імена працівників:\n");
        team1.DisplayTeamInfo();

        Console.WriteLine("\nДетальна інформація про співробітників:\n");
        team1.DisplayDetailedTeamInfo();

        Console.ReadLine();
    }
}