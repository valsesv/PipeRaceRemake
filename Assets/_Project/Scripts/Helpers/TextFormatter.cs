namespace valsesv._Project.Scripts.Helpers
{
    public static class TextFormatter
    {
        private const string Format = "F2";

        public static string NumberWithLetter(double value)
        {
            return value switch
            {
                < 1e4 => value.ToString("F0"),
                >= 1e14 => GetAlphabetNumber(value),
                >= 1e10 => (value / 1e9).ToString(Format) + 'B',
                >= 1e7 => (value / 1e6).ToString(Format) + 'M',
                >= 1e4 => (value / 1e3).ToString(Format) + 'K',
                _ => null
            };
        }

        private static string GetAlphabetNumber(double value)
        {
            char? letter1 = null;
            var letter2 = 'a';
            while (value > 1e4)
            {
                value /= 1000;
                if (letter2 == 'z')
                {
                    letter2 = 'a';
                    if (letter1 == null)
                    {
                        letter1 = 'a';
                    }
                    else
                    {
                        letter1++;
                    }
                }
                letter2++;
            }
            return value.ToString(Format) + letter1 + letter2;
        }
    }
}