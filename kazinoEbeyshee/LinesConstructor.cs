namespace LinesConstructor;

static class Constructor
{
    static public List<string> MakeDiagonal(ref List<string> top, ref List<string> center, ref List<string> bottom) // по диагонали вверх и вниз, с перегрузкой
    {
        List<string> list = new();
        list.Add(top[0]);
        list.Add(center[1]);
        list.Add(bottom[2]);
        list.Add(center[3]);
        list.Add(top[4]);

        return list;
    }
    static public List<string> MakeDiagonal(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom)
    {
        List<string> list = new();
        list.Add(bottom[0]);
        list.Add(center[1]);
        list.Add(top[2]);
        list.Add(center[3]);
        list.Add(bottom[4]);

        return list;
    }
    static public List<string> AsinasCross(ref List<string> top, ref List<string> center, ref List<string> bottom) // по прямой, диагональ, по прямой, с перегрузкой
    {
        List<string> list = new();
        list.Add(top[0]);
        list.Add(top[1]);
        list.Add(center[2]);
        list.Add(bottom[3]);
        list.Add(bottom[4]);

        return list;
    }
    static public List<string> AsinasCross(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom)
    {
        List<string> list = new();
        list.Add(bottom[0]);
        list.Add(bottom[1]);
        list.Add(center[2]);
        list.Add(top[3]);
        list.Add(top[4]);

        return list;
    }
    static public List<string> FromCenterAndUpOrDown(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom) // две лини из центра со смещением, без перегрузки
    {
        List<string> list = new();
        list.Add(center[0]);

        if (setFlagToStartFromTheBottom)
        {
            for (int i = 1; i < 4; i++)
                list.Add(bottom[i]);
        }
        else
        {
            for (int i = 1; i < 4; i++)
                list.Add(top[i]);
        }

        list.Add(center[4]);
        return list;
    }

    static public void ChangeLines(ref List<string> firstRow, ref List<string> secondRow, ref List<string> thirdRow, int colichestvo, string itemToSwap)
    {
        List<string> strings = new();
        strings.AddRange(firstRow);
        strings.AddRange(secondRow);
        strings.AddRange(thirdRow);

        List<int> indexesThatWeCanChange = new(); // создаем список индексов которые можно поменять и меняем элементы рандомной выборкой
        int i = 0;
        foreach (var item in strings)
        {
            if (item != itemToSwap)
                indexesThatWeCanChange.Add(i);

            i++;
        }

        Random choiser = new();

        while (!(indexesThatWeCanChange.Count() == 0) && colichestvo > 0)
        {
            i = indexesThatWeCanChange[choiser.Next(0, indexesThatWeCanChange.Count())];
            strings[i] = itemToSwap;
            indexesThatWeCanChange.Remove(i);
            colichestvo--;
        }
        
        firstRow = strings.GetRange(0, 5);
        secondRow = strings.GetRange(5, 5);
        thirdRow = strings.GetRange(10, 5);
    }
}