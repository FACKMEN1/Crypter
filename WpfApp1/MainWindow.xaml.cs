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
using System.Windows.Media.Animation;
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
            Option.ItemsSource = new List<string>() { "Расшифровать", "Зашифровать" };
            model = new Model();
            DataContext = model;
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool check = model.Save(Cryption_text.Text);
                if (check)
                    MessageBox.Show("Файл успешно сохранён");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void Option_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Option.SelectedItem.ToString() == "Расшифровать")
            {
                Save_btn.IsEnabled = true;
                Cryption_text.IsReadOnly = true;
                Cryption_text.Text = "";
            }
            else if (Option.SelectedItem.ToString() == "Зашифровать")
            {
                Save_btn.IsEnabled = false;
                Cryption_text.IsReadOnly = false;
            }
        }

        private void Run_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Option.Text == "Расшифровать")
            {
                if (!string.IsNullOrWhiteSpace(Key.Text) && !string.IsNullOrWhiteSpace(Key.Text))
                {
                    try
                    {
                        model.Decrypt(Key.Text);
                        Cryption_text.Text = model.Text;

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
            else if (Option.Text == "Зашифровать")
            {
                if (!string.IsNullOrEmpty(Cryption_text.Text) && !string.IsNullOrWhiteSpace(Cryption_text.Text))
                {
                    if (!string.IsNullOrWhiteSpace(Key.Text) && !string.IsNullOrWhiteSpace(Key.Text))
                    {
                        if (Cryption_text.Text.Length > Key.Text.Length)
                        {

                            try
                            {
                                bool check = model.Encrypt(Cryption_text.Text, Key.Text);
                                if (check)
                                    MessageBox.Show("Файл успешно сохранён");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка: " + ex.Message);
                            }
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
    }
}

