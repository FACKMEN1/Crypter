using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cursach
{
    public class Cryption
    {
        private char[] letters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                                'э', 'ю', 'я'};

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
                    if (char.IsUpper(symbol))
                        result += char.ToUpper(letters[newLetter]);
                    else
                        result += letters[newLetter];
                    keyIndex++;
                }
            }
            return result;
        }
    }
}
