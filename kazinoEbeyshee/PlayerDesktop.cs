using PlayersBalance; 
using LinesConstructor; // статический класс сборщика линий
using Math; // статический класс вычислителя
class Program
{
    static public Random r = new();
    static public string[] elements = { "🍇", "🍉", "🍒", "🍊", "💎", "🔔", "🍀", "🍾", "👑" };
    static void Main(string[] args)
    {
        Balance balik = new Balance(1000.00, "dzhyar"); // баланс и функции с ним связанные
        double currentBet = 0;

        List<string> firstRow = new(); //линии
        List<string> secondRow = new();
        List<string> thirdRow = new();

        //начало игры
        Console.Clear();
        Console.CursorVisible = false;
        while (true)
        {
            Console.ReadKey();
            // анимка
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
                List<string> makeLine = new(); // линия отправляемая в конструктор и передающаяся на расчеты в math
                List<string> uniqueContainerOfPlayedElems = new(); // множество уникальных элементов сыгровки
                Dictionary<string, int> elementAndNumPairs = new(); // содержит пару элемент -> необходимое количество замен при двойном успехе

                currentBet = balik.SetBet(10);

                //ебучие расчеты в 10+ строк
                {
                    balik.Money += Computer.ComputeRow(firstRow, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                    balik.Money += Computer.ComputeRow(secondRow, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                    balik.Money += Computer.ComputeRow(thirdRow, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);

                    makeLine = Constructor.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                    makeLine = Constructor.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow, true);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);

                    makeLine = Constructor.AsinasCross(ref firstRow, ref secondRow, ref thirdRow);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                    makeLine = Constructor.AsinasCross(ref firstRow, ref secondRow, ref thirdRow, true);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);

                    makeLine = Constructor.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, true);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                    makeLine = Constructor.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, false);
                    balik.Money += Computer.ComputeRow(makeLine, currentBet, ref uniqueContainerOfPlayedElems, ref elementAndNumPairs);
                }
                if (uniqueContainerOfPlayedElems.Count() != 0) // двойной успех при выигрыше
                {
                    string elementPlayedByRandom = DisplayEdging();
                    if (uniqueContainerOfPlayedElems.Contains(elementPlayedByRandom)) // если выпал элемент из списка
                    {
                        int numOfElementToChange = elementAndNumPairs[elementPlayedByRandom];
                        List<int> listToGetChangedLines = new();

                        Constructor.ChangeLines(ref firstRow, ref secondRow, ref thirdRow, numOfElementToChange, elementPlayedByRandom);
                        DisplayRow(ref firstRow, 1);
                        DisplayRow(ref secondRow, 2);
                        DisplayRow(ref thirdRow, 3);

                        // опять ебливые расчеты
                        {
                            balik.Money += Computer.ComputeRow(firstRow, currentBet, elementPlayedByRandom);
                            balik.Money += Computer.ComputeRow(secondRow, currentBet, elementPlayedByRandom);
                            balik.Money += Computer.ComputeRow(thirdRow, currentBet, elementPlayedByRandom);

                            makeLine = Constructor.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);
                            makeLine = Constructor.MakeDiagonal(ref firstRow, ref secondRow, ref thirdRow, true);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);

                            makeLine = Constructor.AsinasCross(ref firstRow, ref secondRow, ref thirdRow);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);
                            makeLine = Constructor.AsinasCross(ref firstRow, ref secondRow, ref thirdRow, true);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);

                            makeLine = Constructor.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, true);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);
                            makeLine = Constructor.FromCenterAndUpOrDown(ref firstRow, ref secondRow, ref thirdRow, false);
                            balik.Money += Computer.ComputeRow(makeLine, currentBet, elementPlayedByRandom);
                        }
                    }
                }
            }
            // матешка
            DisplayPlayerStats(balik);
            // анимка           
        }
    }

    //функции анимации
    public static void DisplayRow(ref List<string> list, int numOfRow) // отображает движущуюся и статичную часть строки
    {
        Console.SetCursorPosition(14, 2 + numOfRow);
        foreach (string elem in list)
        {
            Console.Write(elem);
        }
        for (int i = list.Count; i < 5; i++)
        {
            Console.Write(elements[r.Next(0, 8)]);
        }
        Console.WriteLine();
    }

    public static void DisplayPlayerStats(Balance balik) // отображает данные пользователя
    {
        balik.ReturnPlayerStats(out string name, out double balance);
        Console.SetCursorPosition(7, 7);
        Console.Write($"name: {name}");
        Console.SetCursorPosition(21, 7);
        Console.Write($"balance: {balance}");
    }

    public static string DisplayEdging() //отображает элементы рулетки вокруг поля, также возвращает элемент который был выбран в результате
    {
        Queue<string> roulette = new();
        for (int i = 1; i <= 9; i++)
            roulette.Enqueue(elements[r.Next(0, 8)]);

        for (int i = 1; i <= 40; i++)
        {
            Console.SetCursorPosition(10, 1);
            int checkCenter = 0;
            foreach (var item in roulette)
            {
                if (checkCenter == 4)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(item);
                }
                else
                {
                    Console.ResetColor();
                    Console.Write(item);
                }

                checkCenter++;
            }
            if (i != 40)
            {
                roulette.Enqueue(elements[r.Next(0, 8)]);
                roulette.Dequeue();
            }
            Thread.Sleep(65);
        }

        while (roulette.Count() != 5)
            roulette.Dequeue();
        return roulette.Peek();
    }
}