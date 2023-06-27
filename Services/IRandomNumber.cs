﻿namespace MVC_TDPC_Net6.Services
{
    public interface IRandomNumber
    {
        int GenerateNumber();
    }
    public class RandomNumberLessThan10 : IRandomNumber
    {
        //numero casuale < 10
        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(10);
        }
    }
    public class RandomNumberGreaterThan50 : IRandomNumber
    {
        //numero casuale > 50
        public int GenerateNumber()
        {
            Random random = new Random();
            return random.Next(50, int.MaxValue);
        }
    }
}
