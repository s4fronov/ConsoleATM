using Newtonsoft.Json;
using ConsoleATMMachine;
using ConsoleATMMachine.Models;

int withdrawalAmount;
var json = File.ReadAllText(@"..\..\..\Info.json");
var info = JsonConvert.DeserializeObject<ATMInformation>(json);

Console.WriteLine($"Your balance: ${info.Balance}");
Console.Write("Please enter the withdrawal amount: ");
withdrawalAmount = Convert.ToInt32(Console.ReadLine());

if (withdrawalAmount > 0)
{
    info.Balance -= withdrawalAmount;
    var amounts = ATMCalculator.Calculate(withdrawalAmount);

    Console.WriteLine($"Your balance: ${info.Balance}");
    Console.WriteLine($"You got: ${withdrawalAmount}");
    Console.WriteLine($"Nominals:");

    Console.WriteLine($"$100: {amounts[0]}");
    info.CountOfNom100 -= amounts[0];

    Console.WriteLine($"$50:  {amounts[1]}");
    info.CountOfNom50 -= amounts[1];

    Console.WriteLine($"$20:  {amounts[2]}");
    info.CountOfNom20 -= amounts[2];

    Console.WriteLine($"$10:  {amounts[3]}");
    info.CountOfNom10 -= amounts[3];

    Console.WriteLine($"$5:   {amounts[4]}");
    info.CountOfNom5 -= amounts[4];

    Console.WriteLine($"$2:   {amounts[5]}");
    info.CountOfNom2 -= amounts[5];

    Console.WriteLine($"$1:   {amounts[6]}");
    info.CountOfNom1 -= amounts[6];

}
else
    Console.WriteLine("Entered withdrawal amount is incorrect!");

var newInfo = JsonConvert.SerializeObject(info);
File.WriteAllText(@"..\..\..\Info.json", newInfo);

Console.WriteLine("Withdrawal status is success!");

Console.ReadKey();
