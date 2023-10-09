namespace CleanArchitectureWithoutMediatR.Utils
{
    public static class Validation
    {
        public static bool ValidateUserName(string? userName)
        {
            if (userName == null) return true;
            string[] nameParts = userName.Split(' ');

            if (nameParts.Length < 2)
            {
                return false;
            }

            foreach (string part in nameParts)
            {
                if (!part.All(char.IsLetter) && part.Any(c => c != ' '))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
