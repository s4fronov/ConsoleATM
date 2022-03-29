using Newtonsoft.Json;
using ConsoleATMMachine;
using ConsoleATMMachine.Models;

int withdrawalAmount;
bool isError = false;
var json = File.ReadAllText(@"..\..\..\Info.json");
var info = JsonConvert.DeserializeObject<ATMInformation>(json);

Console.WriteLine($"Your balance: ${info.Balance}");

Console.WriteLine();
Console.Write("Please enter the withdrawal amount: ");
withdrawalAmount = Convert.ToInt32(Console.ReadLine());

if (withdrawalAmount > 0 && info.Balance >= withdrawalAmount)
{
    var denominals = new int[7];

    try
    {
        denominals = ATMCalculator.Calculate(info, withdrawalAmount);
    }
    catch (Exception ex)
    {
        Console.WriteLine();
        Console.WriteLine(ex.Message);
        withdrawalAmount = 0;
        isError = true;
    }
    finally
    {
        ATMDenominalsChecker.CheckNominals(info, denominals);

        info.Balance -= withdrawalAmount;

        Console.WriteLine($"You got: ${withdrawalAmount}");

        Console.WriteLine();
        Console.WriteLine($"Your balance: ${info.Balance}");
    }
}
else
{
    Console.WriteLine("Entered withdrawal amount is incorrect! Insufficient funds in the account");
    isError = true;
}

string status = isError ? "error" : "success";

var newInfo = JsonConvert.SerializeObject(info);
File.WriteAllText(@"..\..\..\Info.json", newInfo);

Console.WriteLine();
Console.WriteLine($"Withdrawal status is {status}!");

Console.ReadKey();
