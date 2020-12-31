using System;

namespace ChessNET.Domain
{
    public enum File 
    {
        A = 1,
        B,
        C,
        D,
        E,
        F,
        G,
        H
    }

    public static class FileExtensions
    {
        public static File FromString(string s)
        {
            return s.ToLower() switch
            {
                "a" => File.A,
                "b" => File.B,
                "c" => File.C,
                "d" => File.D,
                "e" => File.E,
                "f" => File.F,
                "g" => File.G,
                "h" => File.H,
                _ => throw new ArgumentException("Invalid file: " + s)
            };
        }
    }
}