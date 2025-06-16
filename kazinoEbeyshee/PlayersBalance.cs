namespace PlayersBalance;

class Balance
{
    private double money;
    private string name;

    public Balance(double money, string name) //конструкторы
    {
        this.money = money;
        this.name = name;
    }
    public Balance() : this(0.00, "undefined")
    { }

    public void ReturnPlayerStats(out string name, out double money) //отображает данные игрока
    {
        name = this.name;
        money = this.money;
    }
    public double SetBet() //ставка
    {
        Console.Write("set your bet:");
        double bet = Convert.ToDouble(Console.ReadLine());
        while (bet < this.money)
        {
            Console.WriteLine($"Not available. Your balanse is {this.money}");
            Console.Write("set your bet:");
            bet = Convert.ToDouble(Console.ReadLine());
        }
        this.money -= bet;
        return bet;
    }

    public double SetBet(double bet) //тест работоспособности компьютера, когда доделаешь все в main-е заменить нахуй
    {
        this.money -= bet;
        return bet;
    }
    public void ReturnNewBalance(double money) => this.money += money; //изменение баланса в случае выигрыша

    public double Moneys
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
        }
    }
}