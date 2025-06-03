namespace LinesConstructor;

class Constructor
{
    public List<string> MakeDiagonal(ref List<string> top, ref List<string> center, ref List<string> bottom) // по диагонали вверх и вниз, с перегрузкой
    {
        List<string> list = new();
        list.Add(top[0]);
        list.Add(center[1]);
        list.Add(bottom[2]);
        list.Add(center[3]);
        list.Add(top[4]);

        return list;
    }
    public List<string> MakeDiagonal(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom)
    {
        List<string> list = new();
        list.Add(bottom[0]);
        list.Add(center[1]);
        list.Add(top[2]);
        list.Add(center[3]);
        list.Add(bottom[4]);

        return list;
    }

    public List<string> AsinasCross(ref List<string> top, ref List<string> center, ref List<string> bottom) // по прямой, диагональ, по прямой, с перегрузкой
    {
        List<string> list = new();
        list.Add(top[0]);
        list.Add(top[1]);
        list.Add(center[2]);
        list.Add(bottom[3]);
        list.Add(bottom[4]);

        return list;
    }

    public List<string> AsinasCross(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom)
    {
        List<string> list = new();
        list.Add(bottom[0]);
        list.Add(bottom[1]);
        list.Add(center[2]);
        list.Add(top[3]);
        list.Add(top[4]);

        return list;
    }
    
    public List<string> FromCenterAndUpOrDown(ref List<string> top, ref List<string> center, ref List<string> bottom, bool setFlagToStartFromTheBottom) // две лини из центра со смещением, без перегрузки
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
}