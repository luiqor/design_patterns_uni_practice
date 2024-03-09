using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAbstractFactory
{
    public static class Constants
    {
        public const string UkrAlphabet = "АБВГҐДЕЄЖЗИІЇЙКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        public const string EngAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }

    abstract class DecryptProducts
    {
        public abstract string DecryptLanguage(string message, int secretKey);
    }

    class DecryptUkrProduct : DecryptProducts
    {
        public override string DecryptLanguage(string message, int secretKey)
        {
            CaesarCipher cipher = new CaesarCipher();
            return cipher.Decrypt(message, secretKey, Constants.UkrAlphabet);
        }
    }

    class DecryptEngProduct : DecryptProducts
    {
        public override string DecryptLanguage(string message, int secretKey)
        { 
            CaesarCipher cipher = new CaesarCipher();
            return cipher.Decrypt(message, secretKey, Constants.EngAlphabet);
        }
    }

    abstract class EncryptProducts
    {
        public abstract string EncryptLanguage(string message, int secretKey);
    }

    class EncryptUkrProduct : EncryptProducts
    {
        public override string EncryptLanguage(string message, int secretKey)
        {
            CaesarCipher cipher = new CaesarCipher();
            return cipher.Encrypt(message, secretKey, Constants.UkrAlphabet);
        }
    }

    class EncryptEngProduct : EncryptProducts
    {
        public override string EncryptLanguage(string message, int secretKey)
        {
            CaesarCipher cipher = new CaesarCipher();
            return cipher.Encrypt(message, secretKey, Constants.EngAlphabet);
        }
    }



    abstract class CipherFactory
    {
        public abstract EncryptProducts CreateEncryptProducts();
        public abstract DecryptProducts CreateDecryptProducts();
    }
    class UkrFactory : CipherFactory
    {
        public override EncryptProducts CreateEncryptProducts()
        {
            return new EncryptUkrProduct();
        }
        public override DecryptProducts CreateDecryptProducts()
        {
            return new DecryptUkrProduct();
        }
    }
    class EngFactory : CipherFactory
    {
        public override EncryptProducts CreateEncryptProducts()
        {
            return new EncryptEngProduct();
        }
        public override DecryptProducts CreateDecryptProducts()
        {
            return new DecryptEngProduct();
        }
    }


    class Client
    {
        private DecryptProducts DecryptProducts;
        private EncryptProducts EncryptProducts;
        public Client(CipherFactory factory)
        {
            DecryptProducts = factory.CreateDecryptProducts();
            EncryptProducts = factory.CreateEncryptProducts();
        }
        public string EncryptLanguage(string message, int secretKey)
        {
            return EncryptProducts.EncryptLanguage(message, secretKey);
        }

        public string DecryptLanguage(string message, int secretKey)
        {
            return DecryptProducts.DecryptLanguage(message, secretKey);
        }
    }
    
}
