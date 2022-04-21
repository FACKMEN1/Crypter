using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cursach
{
    internal class Cryption
    {
        private char[] letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я'};
        private char[] digits = new char[] {  '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0'};
        public Cryption()
        {

        }

        public string Decryption(string text, string key)
        {
            //text = text.ToLower();
            string result = "";
            key = key.ToLower();
            int keyIndex = 0;
            foreach (char symbol in text)
            {
                if (!letters.Contains(char.ToLower(symbol)))
                {
                    result += symbol;
                }
                else
                {
                    if (keyIndex == key.Length)
                        keyIndex = 0;
                    int newLetter = (Array.IndexOf(letters, char.ToLower(symbol)) + letters.Length -
                          Array.IndexOf(letters, key[keyIndex])) % letters.Length;

                    result += letters[newLetter];
                    keyIndex++;
                }
            }
            return result;
        }

        //private string AutoGenerateKey(int length)
        //{
        //    string result = "";
        //    Random rand = new Random();
        //    length -= rand.Next(length - 1);
        //    for (int i = 0; i < length; i++)
        //        result += characters[rand.Next(0, characters.Length)];
        //    return result;
        //}

        public string Encryption(string text, string key)
        {
            string result = "";
            key = key.ToLower();
            int keyIndex = 0;
            foreach (char symbol in text)
            {
                if (!letters.Contains(char.ToLower(symbol)))
                {
                    result += symbol;
                }
                else
                {
                    if (keyIndex == key.Length)
                        keyIndex = 0;
                    int newLetter = (Array.IndexOf(letters, char.ToLower(symbol)) +
                          Array.IndexOf(letters, key[keyIndex])) % letters.Length;

                    result += letters[newLetter];
                    keyIndex++;
                }
            }
            return result;
        }
    }
}
