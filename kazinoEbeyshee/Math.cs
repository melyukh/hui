namespace Math;
class Computer
{
    private Dictionary<string, double> valueOfKoeff = new Dictionary<string, double>()
    {
        {"🍇", 1.0 },
        {"🍉", 0.8 },
        {"🍒", 1.0 },
        {"🍊", 1.2 },
        {"💎", 10.0},
        {"🔔", 5.0 },
        {"🍀", 2.0 },
        {"🍾", 3.0 },
    };

    public double ComputeRow(in List<string> line, in double bet)
    {
        int numOfCurrent = 1;
        string element = line[0];

        if (element == "👑") //если начало с вайлда, то нужно найти едемент к которому может быть привязана линия если же все вайлды то *20
        {
            for (int j = 1; j < 5; j++)
            {
                if (line[j] != element)
                {
                    element = line[j];
                    for (int i = 1; i < 5; i++)
                    {
                        if (line[i] == "👑" || line[i] == element)
                            numOfCurrent++;
                        else
                            break;
                    }
                    return numOfCurrent >= 3 ? bet * (numOfCurrent - 2) * valueOfKoeff[element] : 0;
                }
            }
            return bet * 20.0;
        }

        else //нормальная линия без вайлда в начале
        {
            for (int i = 1; i < 5; i++)
            {
                if (line[i] == "👑" || line[i] == element)
                    numOfCurrent++;
                else
                    break;
            }
            return numOfCurrent >= 3 ? bet * (numOfCurrent - 2) * valueOfKoeff[element] : 0;
        }
    }
}
