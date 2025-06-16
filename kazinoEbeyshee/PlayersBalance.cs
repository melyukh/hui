namespace PlayersBalance;

class Balance
{
    private double money;
    private string name;

    public double Money //свойство, позволяющее работать с балансом
    {
        get{ return money; }
        set{ money = value; }
    }

    public Balance(double money, string name) //конструкторы
    {
        this.Money = money;
        this.name = name;
    }
    public Balance() : this(0.00, "undefined")
    { }

    public void ReturnPlayerStats(out string name, out double money) //отображает данные игрока
    {
        name = this.name;
        money = this.Money;
    }
    public double SetBet() //ставка
    {
        Console.Write("set your bet:");
        double bet = Convert.ToDouble(Console.ReadLine());
        while (bet < this.Money)
        {
            Console.WriteLine($"Not available. Your balanse is {this.Money}");
            Console.Write("set your bet:");
            bet = Convert.ToDouble(Console.ReadLine());
        }
        this.Money -= bet;
        return bet;
    }

    public double SetBet(double bet) //тест работоспособности компьютера, когда доделаешь все в main-е заменить нахуй
    {
        this.Money -= bet;
        return bet;
    }   
    
}