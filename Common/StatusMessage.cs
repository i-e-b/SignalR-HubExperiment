using System;

namespace Common
{
    public class StatusMessage
    {
        public static void Write(string s)
        {
            string leader;
            try {
                var w = Math.Max(0, Console.BufferWidth - s.Length - 1);
                leader = new string(' ', w);
            } catch {
                leader = " > ";
            }
            Console.WriteLine(leader + s);
        }
    }
}