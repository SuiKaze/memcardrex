//Shift-JIS converter class
//SuiKaze Raider 2017

using System;
using System.Collections.Generic;
using System.Text;

namespace MemcardRex
{
    class charConverter
    {
        //Convert SJIS characters to ASCII equivalent.
        public string convertSJIStoASCII(byte[] bData)
        {
            //Variables.
            string output = null;
            char[] chData;
            int tempValue;
            int i;

            //Conversion.
            try
            {
                //Converting Shift JIS to Unicode.
                chData = Encoding.GetEncoding(932).GetChars(bData);

                //Getting Game Name.
                for (i = 0; i < chData.Length; i++)
                {
                    //Getting Temporally Integer Value.
                    tempValue = chData[i];

                    //Converting 2Byte Chars To 1Byte Chars (Only Latin Alphabet)
                    if (tempValue >= 0xFF01 && tempValue <= 0xFF5E)
                    {
                        tempValue -= 0xFEE0;
                    }
                    else if (tempValue == 0x3000)
                    {
                        tempValue = (char)(0x20);
                    }

                    //Getting Final Char & End Of String.
                    if (tempValue != 0x00)
                    {
                        output += (char)(tempValue);
                    }
                    else
                    {
                        return output;
                    }
                }
            }
            catch (Exception) { }

            //Final Result.
            return output;
        }
    }
}
