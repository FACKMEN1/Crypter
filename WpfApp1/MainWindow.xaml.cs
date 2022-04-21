using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model model;
        public MainWindow()
        {
            InitializeComponent();
            model = new Model();
            DataContext = model;
        }

        private void Decrypt_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Key_Decr.Text) && !string.IsNullOrWhiteSpace(Key_Decr.Text))
            {
                try 
                {
                    model.Decrypt(Key_Decr.Text);
                    Decryption_text.Text = model.Text;
                    Save_decr_btn.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
                
            }
            else
            {
                MessageBox.Show("Введите ключ");
            }
        }

        private void Encrypt_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(Encryption_text.Text) && !string.IsNullOrWhiteSpace(Encryption_text.Text))
            {
                if (!string.IsNullOrWhiteSpace(Key_Encr.Text) && !string.IsNullOrWhiteSpace(Key_Encr.Text))
                {
                    if (Encryption_text.Text.Length > Key_Encr.Text.Length)
                    {
                        try
                        {
                            model.Encrypt(Encryption_text.Text, Key_Encr.Text);
                            MessageBox.Show("Файл успешно сохранён");
                        }catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка: " + ex.Message);
                        }
                        
                        
                    }
                    else
                        MessageBox.Show("Длина ключа должна быть меньше длины текста");
                }
                else
                    MessageBox.Show("Введите ключ");
            }
            else
            {
                MessageBox.Show("Введите текст для шифрования");
            }
        }

        private void Save_decr_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                model.Save(Decryption_text.Text);
                MessageBox.Show("Файл успешно сохранён");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
