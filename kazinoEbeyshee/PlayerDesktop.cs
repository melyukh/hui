using PlayersBalance;
using Math;
using LinesConstructor;

class Program
{
    static public Random r = new();
    static public string[] elements = { "🍇", "🍉", "🍒", "🍊", "💎", "🔔", "🍀", "👑", "🍾" };
    static void Main(string[] args)
    {
        Computer computer = new Computer(); //вычислитель
        Constructor lc = new();

        Balance balik = new Balance(1000.00, "dzhyar"); // баланс и функции с ним связанные
        double currentBet = 0;

        List<string> firstRow = new(); //линии
        List<string> secondRow = new();
        List<string> thirdRow = new();
        
        //начало игры
        Console.Clear();
        while (true)
        {
            //animation
            Console.ReadKey();
            Console.Clear();

            firstRow.Clear();
            secondRow.Clear();
            thirdRow.Clear();

            for (int frames = 1; frames <= 75; frames++)
            {
                DisplayRow(ref firstRow);
                DisplayRow(ref secondRow);
                DisplayRow(ref thirdRow);
                Thread.Sleep(50);

                if (frames % 15 == 0)
                {
                    firstRow.Add(elements[r.Next(0, 9)]);
                    secondRow.Add(elements[r.Next(0, 9)]);
                    thirdRow.Add(elements[r.Next(0, 9)]);
                }

                if (frames != 75)
                {
                    Console.Clear();
                }
            }

            //mathSolution
            List<string> makeLine = new();
            currentBet = balik.SetBet(10);
            balik.ReturnNewBalance(computer.ComputeRow(firstRow, currentBet));
            balik.ReturnNewBalance(computer.ComputeRow(secondRow, currentBet));
            balik.ReturnNewBalance(computer.ComputeRow(thirdRow, currentBet));

            makeLine = lc.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));
            makeLine = lc.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow, true);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));

            makeLine = lc.AsinasCross(ref firstRow, ref secondRow, ref thirdRow);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));
            makeLine = lc.AsinasCross(ref firstRow, ref secondRow, ref thirdRow, true);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));

            makeLine = lc.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, true);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));
            makeLine = lc.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, false);
            balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet));
            //mathSolution

            balik.DisplayPlayerStats();
            //animation            
        }
    }
    public static void DisplayRow(ref List<string> list)
    {
        foreach(string elem in list)
        {
            Console.Write(elem);
        }
        for(int i = list.Count; i < 5; i++)
        {
            Console.Write(elements[r.Next(0, 8)]);
        }
        Console.WriteLine();
    }
}