using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextCleaner.BusinessLogic
{
    public static class Cleaner
    {
        const char spaceSymbol = ' ';

        /// <summary>
        /// Удаление символов из текста
        /// </summary>
        /// <param name="text"></param>
        public static string RemoveSpecialSymbols(string text, List<char> symbolsForRemove)
        {
            var sb = new StringBuilder();
            for (int j = 0; j < text.Length; j++)
            {
                if (!symbolsForRemove.Contains(text[j]))
                {
                    sb.Append(text[j]);
                }
            }
            return sb.ToString();
        }

        public static void RemoveStartSpaces(List<string> lStrings)
        {
            //определение количества лишних пробелов слева
            int spaceCount = 0;
            if (lStrings.Count > 0)
            {
                for (int i = 0; i < lStrings.First().Length; i++)
                {
                    if (lStrings.First()[i] != spaceSymbol)
                    {
                        spaceCount = i;
                        break;
                    }
                }
                //стирание лишних пробелов слева
                for (int i = 0; i < lStrings.Count; i++)
                {
                    var sb = new StringBuilder(lStrings[i]);
                    for (int j = 0; j < spaceCount; j++)
                    {
                        if (sb.Length > 0 && sb[0] == spaceSymbol)
                            sb.Remove(0, 1);
                        else
                            break;
                    }

                    lStrings[i] = sb.ToString();
                }
            }
        }

    }
}
