using System;

namespace ConsoleApplication1
{
    public static class GameMath
    {
        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            var result = value;
            if (value.CompareTo(min) < 0)
                result = min;
            if (value.CompareTo(max) > 0)
                result = max;

            return result;
        }
        //Non Generic
        /*
        public static int Clamp(int value, int min, int max)
        {
            var result = value;
            
            if (result < min)
                result = min;
            
            if (result > max)
                result = max;

            return result;
        }
        */
    }
}