using ConsoleATMMachine.Models;

namespace ConsoleATMMachine
{
    public static class ATMDenominalsChecker
    {
        public static void CheckNominals(ATMInformation info, int[] denominals)
        {
            Console.WriteLine();
            Console.WriteLine($"Denominals:");

            Console.WriteLine($"$100: {denominals[0]}");
            info.CountOfDenominal100 -= denominals[0];


            Console.WriteLine($"$50:  {denominals[1]}");
            info.CountOfDenominal50 -= denominals[1];


            Console.WriteLine($"$20:  {denominals[2]}");
            info.CountOfDenominal20 -= denominals[2];


            Console.WriteLine($"$10:  {denominals[3]}");
            info.CountOfDenominal10 -= denominals[3];


            Console.WriteLine($"$5:   {denominals[4]}");
            info.CountOfDenominal5 -= denominals[4];


            Console.WriteLine($"$2:   {denominals[5]}");
            info.CountOfDenominal2 -= denominals[5];


            Console.WriteLine($"$1:   {denominals[6]}");
            info.CountOfDenominal1 -= denominals[6];

            Console.WriteLine();
        }
    }
}
