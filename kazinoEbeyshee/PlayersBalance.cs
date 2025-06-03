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

    public void DisplayPlayerStats() //отображает данные игрока
    {
        Console.SetCursorPosition(1,  8);
        Console.Write($"name: {name}");
        Console.SetCursorPosition(18, 8);
        Console.Write($"balance: {money}");
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
}