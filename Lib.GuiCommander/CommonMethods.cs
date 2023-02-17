using System.Text;

namespace Lib.GuiCommander
{
    public static class CommonMethods
    {
        public static string UpFirstChar(this string str)
        {
            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToUpper(str[0]) + str[1..];
        }

        public static string LowFirstChar(this string str)
        {
            if (str.Length == 0)
            {
                return string.Empty;
            }

            return char.ToLower(str[0]) + str[1..];
        }


        public static string ToSnakeCase(this string str)
        {
            if (String.IsNullOrEmpty(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            if (str.Length < 2)
            {
                return str.ToLower();
            }

            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(str[0]));

            for (int i = 1; i < str.Length; ++i)
            {
                char c = str[i];
                if (char.IsUpper(c))
                {
                    sb.Append('_');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
