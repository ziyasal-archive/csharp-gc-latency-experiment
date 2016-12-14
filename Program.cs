using System;

namespace ConsoleApplication
{
    public static class ArrayExtensions{
         public static void Populate<T>(this T[] arr, T value ) {
            for ( int i = 0; i < arr.Length;i++ ) {
                arr[i] = value;
            }
        }
    }
    public class Program
    {
        private  const int windowSize = 200000;
        private  const int msgCount = 1000000;
        private  const int msgSize = 1024;
        private static long worst = 0;

        private static byte[] createMessage(int n)
        {
            byte[] msg = new byte[msgSize];
            msg.Populate((byte)n);
            return msg;
        }
       
        private static void pushMessage( byte[][] store, int id)
        {
            long start = DateTime.Now.Ticks;
            store[id % windowSize] = createMessage(id);
            long elapsed = DateTime.Now.Ticks - start;
            if (elapsed > worst)
            {
                worst = elapsed;
            }
        }
        public static void Main(string[] args)
        {
            byte[][] store = new byte[windowSize][];
            for (int i = 0; i < msgCount; i++)
            {
                pushMessage(store, i);
            }

            Console.WriteLine("Worst push time: " + (worst / 1000000.0f));
        }
    }
}
