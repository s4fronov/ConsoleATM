using ConsoleATMMachine.Models;

namespace ConsoleATMMachine
{
    public static class ATMCalculator
    {
        public static int[] Calculate(ATMInformation info, int withdrawalAmount)
        {
            var denominals = new int[7];

            denominals[0] = withdrawalAmount / 100;
            denominals[0] = denominals[0] > info.CountOfDenominal100 ? info.CountOfDenominal100 : denominals[0];
            withdrawalAmount -= 100 * denominals[0];

            denominals[1] = withdrawalAmount / 50;
            denominals[1] = denominals[1] > info.CountOfDenominal50 ? info.CountOfDenominal50 : denominals[1];
            withdrawalAmount -= 50 * denominals[1];

            denominals[2] = withdrawalAmount / 20;
            denominals[2] = denominals[2] > info.CountOfDenominal20 ? info.CountOfDenominal20 : denominals[2];
            withdrawalAmount -= 20 * denominals[2];

            denominals[3] = withdrawalAmount / 10;
            denominals[3] = denominals[3] > info.CountOfDenominal10 ? info.CountOfDenominal10 : denominals[3];
            withdrawalAmount -= 10 * denominals[3];

            denominals[4] = withdrawalAmount / 5;
            denominals[4] = denominals[4] > info.CountOfDenominal5 ? info.CountOfDenominal5 : denominals[4];
            withdrawalAmount -= 5 * denominals[4];

            denominals[5] = withdrawalAmount / 2;
            denominals[5] = denominals[5] > info.CountOfDenominal2 ? info.CountOfDenominal2 : denominals[5];
            withdrawalAmount -= 2 * denominals[5];

            denominals[6] = withdrawalAmount / 1;
            denominals[6] = denominals[6] > info.CountOfDenominal1 ? info.CountOfDenominal1 : denominals[6];
            withdrawalAmount -= 1 * denominals[6];

            if (withdrawalAmount == 0)
                return denominals;
            else
            {
                string message = "Error! It's impossible to withdraw such an amount \n";

                if (info.CountOfDenominal100 == 0)
                    message += "Denominal $100 is ended \n";

                if (info.CountOfDenominal50 == 0)
                    message += "Denominal $50 is ended \n";

                if (info.CountOfDenominal20 == 0)
                    message += "Denominal $20 is ended \n";

                if (info.CountOfDenominal10 == 0)
                    message += "Denominal $10 is ended \n";

                if (info.CountOfDenominal5 == 0)
                    message += "Denominal $5 is ended \n";

                if (info.CountOfDenominal2 == 0)
                    message += "Denominal $2 is ended \n";

                if (info.CountOfDenominal1 == 0)
                    message += "Denominal $1 is ended \n";

                throw new Exception(message);
            }
        }
    }
}
