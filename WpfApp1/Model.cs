using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    public class Model
    {
        private string text;
        public string Text { get { return text; } }
        private string key;
        public string Key { get { return key; } set { key = value; } }
        private Cryption cryption;
        public Model()
        {
            cryption = new Cryption();
        }

        public void Decrypt(string key)
        {

            var open = new OpenFileDialog();
            open.Filter = "Text files (*.txt)|*.txt";
            try
            {
                open.ShowDialog();
                if (string.IsNullOrEmpty(open.FileName))
                    return;
                string fileText = "";
                var fileStream = open.OpenFile();

                using (StreamReader reader = new StreamReader(fileStream, Encoding.GetEncoding(1251)))
                {
                    fileText = reader.ReadToEnd();
                }
                fileStream.Close();
                this.text = cryption.Decryption(fileText, key);
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public bool Encrypt(string text, string key)
        {
            this.text = cryption.Encryption(text, key);
            return Save(this.text);
        }

        public bool Save(string text)
        {
            var save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt";
            try
            {
                save.ShowDialog();
                if (string.IsNullOrEmpty(save.FileName))
                    return false;
                using (StreamWriter writer = new StreamWriter(save.FileName, false, Encoding.GetEncoding(1251)))
                {
                    writer.Write(text);
                }
                return true;
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
