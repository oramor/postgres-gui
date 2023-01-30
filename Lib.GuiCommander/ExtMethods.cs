namespace Lib.GuiCommander
{
    public static class ExtMethods
    {
        public static string? UpFirstChar(this string str)
        {
            if (str == null) return null;

            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToUpper(str[0]) + str[1..];
        }

        public static string? LowFirstChar(this string str)
        {
            if (str == null) return null;

            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToLower(str[0]) + str[1..];
        }
    }
}
