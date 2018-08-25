using System;

public static class LimitationConfigs {

    public static long GetMaxTriangles(int n)
    {
        return (long)Math.Floor(Math.Log(n + 1, 2) * 10000);
    }
    public static long GetMaxEnities(int n)
    {
        return (long)Math.Floor(Math.Log(n + 1, 2) * 200);
    }
    public static long GetMaxHeight(int n)
    {
        return (long)Math.Floor(Math.Log(n + 1, 2) * 20);
    }
}
