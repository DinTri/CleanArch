namespace SalaryCalculatorWithAdapter.Utils
{
    public static class Validation
    {
        public static bool ValidateUserName(string? userName)
        {
            if (userName == null) return true;
            string[] nameParts = userName.Split(' ');

            if (nameParts.Length >= 2) return nameParts.All(part => part.All(char.IsLetter) || part.All(c => c == ' '));
            return false;

        }
    }
}
