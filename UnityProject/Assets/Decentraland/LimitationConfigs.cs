using System;

namespace Dcl
{
    public static class LimitationConfigs
    {

        public static long GetMaxTriangles(int n)
        {
            return n * 10000;
        }
        public static long GetMaxEnities(int n)
        {
            return n * 200;
        }
        public static long GetMaxBodies(int n)
        {
            return n * 300;
        }
        public static long GetMaxMaterials(int n)
        {
            return (long)Math.Floor(Math.Log(n + 1, 2) * 20);
        }
        public static long GetMaxTextures(int n)
        {
            return (long)Math.Floor(Math.Log(n + 1, 2) * 10);
        }
        public static long GetMaxHeight(int n)
        {
            return (long)Math.Floor(Math.Log(n + 1, 2) * 20);
        }
    }
}