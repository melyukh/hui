using PlayersBalance;
using Math;
using LinesConstructor;

class Program
{
    static public Random r = new();
    static public string[] elements = { "🍇", "🍉", "🍒", "🍊", "💎", "🔔", "🍀", "🍾", "👑"};
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
            // анимка
            Console.ReadKey();
            Console.Clear();

            firstRow.Clear();
            secondRow.Clear();
            thirdRow.Clear();

            for (int frames = 1; frames <= 75; frames++)
            {
                
                DisplayRow(ref firstRow, 1);
                DisplayRow(ref secondRow, 2);
                DisplayRow(ref thirdRow, 3);
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

            // матешка
            {
                List<string> makeLine = new();
                List<string> uniqueContainerOfPlayedElems = new();
                int huetaKoroche = 0;
                currentBet = balik.SetBet(10);

                balik.ReturnNewBalance(computer.ComputeRow(firstRow, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));
                balik.ReturnNewBalance(computer.ComputeRow(secondRow, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));
                balik.ReturnNewBalance(computer.ComputeRow(thirdRow, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));

                makeLine = lc.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));
                makeLine = lc.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow, true);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));

                makeLine = lc.AsinasCross(ref firstRow, ref secondRow, ref thirdRow);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));
                makeLine = lc.AsinasCross(ref firstRow, ref secondRow, ref thirdRow, true);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));

                makeLine = lc.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, true);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));
                makeLine = lc.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, false);
                balik.ReturnNewBalance(computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref huetaKoroche));

                if (uniqueContainerOfPlayedElems.Count() != 0) // недоделан двойной успех при выигрыше
                {
                    string elementPlayedByRandom = elements[r.Next(0, 8)];
                    if (uniqueContainerOfPlayedElems.Contains(elementPlayedByRandom))
                    {
                        
                    }
                }
            } 
            // матешка

            balik.DisplayPlayerStats();
            // анимка           
        }
    }
    public static void DisplayRow(ref List<string> list, int numOfRow)
    {
        Console.SetCursorPosition(10, 2+numOfRow);
        foreach (string elem in list)
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