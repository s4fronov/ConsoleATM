namespace ConsoleATMMachine
{
    public static class ATMCalculator
    {
        public static int[] Calculate(int withdrawalAmount)
        {
            var result = new int[7];

            result[0] = withdrawalAmount / 100;
            withdrawalAmount -= 100 * result[0];

            result[1] = withdrawalAmount / 50;
            withdrawalAmount -= 50 * result[1];

            result[2] = withdrawalAmount / 20;
            withdrawalAmount -= 20 * result[2];

            result[3] = withdrawalAmount / 10;
            withdrawalAmount -= 10 * result[3];

            result[4] = withdrawalAmount / 5;
            withdrawalAmount -= 5 * result[4];

            result[5] = withdrawalAmount / 2;
            withdrawalAmount -= 2 * result[5];

            result[6] = withdrawalAmount / 1;
            withdrawalAmount -= 1 * result[6];

            if (withdrawalAmount == 0)
                return result;
            else
                throw new Exception("Operation is incorrect");
        }
    }
}
