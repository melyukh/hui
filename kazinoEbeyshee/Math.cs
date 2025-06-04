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
    public double ComputeRow(in List<string> line, in double bet, ref List<string> UniqueContainerOfPlayedElems, ref Dictionary<string, int> dict)
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
                    if (numOfCurrent >= 3) // если сыграло, то: возвращаем выишрыш, получаем количество сыгравших элементов и добавляем его в контейнер с уникальными игровками на проход
                    {
                        if (!UniqueContainerOfPlayedElems.Contains(element)) //добавляем элемент в список сыгравших
                            UniqueContainerOfPlayedElems.Add(element);

                        if (dict.ContainsKey(element)) //добавляем в словарь сыгравший элемент чтобы потом узнать сколько символов заменять
                        {
                            if (numOfCurrent * 2 > dict[element])
                                dict[element] = numOfCurrent * 2;
                        }
                        else
                            dict.Add(element, numOfCurrent * 2);

                        return bet * (numOfCurrent - 2) * valueOfKoeff[element];
                    }
                    else
                        return 0;
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
            if (numOfCurrent >= 3)
            {
                if (!UniqueContainerOfPlayedElems.Contains(element)) //добавляем элемент в список сыгравших
                    UniqueContainerOfPlayedElems.Add(element);
                
                if (dict.ContainsKey(element)) //добавляем в словарь сыгравший элемент чтобы потом узнать сколько символов заменять
                {
                    if (numOfCurrent * 2 > dict[element])
                        dict[element] = numOfCurrent * 2;
                }
                else
                    dict.Add(element, numOfCurrent * 2);

                return bet * (numOfCurrent - 2) * valueOfKoeff[element];
            }
            else
                return 0;    
        }
    }
    public double ComputeRow(in List<string> line, in double bet, string elementToPlay) //перегрузка для игры по конкретному элементу(типо когда залетел двойной успех)
    {
        int numOfCurrent = 0;
        foreach (string element in line)
        {
            if (element == elementToPlay)
                numOfCurrent++;
            else
                break;
        }
        return numOfCurrent >= 3 ? bet * (numOfCurrent - 2) * valueOfKoeff[elementToPlay] : 0;
    } 
}
