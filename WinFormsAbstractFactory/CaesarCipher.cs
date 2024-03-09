using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAbstractFactory
{
    public class CaesarCipher
    {
        private string CodeEncode(string text, int k, string alphabet)
        {
            //додаємо до алфавіту малі літери
            var fullalphabet = alphabet + alphabet.ToLower();
            var letterQty = fullalphabet.Length;
            var retVal = "";
            for (int i = 0; i < text.Length; i++)
            {
                var c = text[i];
                var index = fullalphabet.IndexOf(c);
                if (index < 0)
                {
                    //якщо літеру не знайдено, додаємо її незмінною
                    retVal += c.ToString();
                }
                else
                { //Encrypt(mn) = (Q + mn + k) % Q; де m - відкритий текст, k - ключ шифрування, Q - кількість символів в алфавіті, c - зашифрований текст.
                    var codeIndex = (letterQty + index + k) % letterQty;
                    retVal += fullalphabet[codeIndex];
                }
            }

            return retVal;
        }

        //шифрування тексту
        public string Encrypt(string plainMessage, int key, string alphabet)
            => CodeEncode(plainMessage, key, alphabet);

        //дешифрування тексту
        public string Decrypt(string encryptedMessage, int key, string alphabet)
            => CodeEncode(encryptedMessage, -key, alphabet);
    }
}
