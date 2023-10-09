namespace TrifonCleanArch.Utils
{
    public static class ValidateInput
    {
        public static bool IsValidNumber(string? input)
        {
            return decimal.TryParse(input, out _);
        }
        public static bool ValidateUserName(string? userName)
        {
            if (userName == null) return true;
            string[] nameParts = userName.Split(' ');

            if (nameParts.Length >= 2) return nameParts.All(part => part.All(char.IsLetter) || part.All(c => c == ' '));
            return false;

        }
    }
}
