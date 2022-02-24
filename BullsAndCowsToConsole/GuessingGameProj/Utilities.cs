using System;

namespace UtilityMethods
{
    public class Utilities
    {
        public void InsertSpacesBetweenCharacters(ref string io_String)
        {
            string strTemp = null;

            if (io_String != null)
            {
                foreach (char singleChar in io_String)
                {
                    strTemp += singleChar;
                    strTemp += " ";
                }
            }

            io_String = strTemp;
        }
        public void SortByAlphabetic(ref string io_String)
        {
            if (io_String != null)
            {
                char[] arr = io_String.ToCharArray();

                Array.Sort(arr);
                io_String = string.Join(string.Empty, arr);
            }
        }

        public void ConvertToUpperCase(string i_GuessingStr, out string o_GuessingStr)
        {
            o_GuessingStr = null;
            if (i_GuessingStr != null)
            {
                foreach (char singleChar in i_GuessingStr)
                {
                    if ((singleChar >= 'a' && singleChar <= 'h') || singleChar == 'q')
                    {
                        o_GuessingStr += (char)(singleChar - ' ');
                    }
                    else
                    {
                        o_GuessingStr += (char)singleChar;
                    }
                }
            }
        }
    }
}