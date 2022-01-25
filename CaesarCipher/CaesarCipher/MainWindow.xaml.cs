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

namespace CaesarCipher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private char EncipherChar(char c, int key)
        {
            if (!char.IsLetter(c))
            {
                return c;
            }
            int offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + key) - offset) % 26) + offset);
        }

        public string Encipher(string input, int key, string direction)
        {
            string output = "";
            switch (direction)
            {
                case "Right":
                    foreach (char c in input)
                    {
                        output += EncipherChar(c, key);
                    }
                    break;
                case "Left":
                    foreach (char c in input)
                    {
                        output += EncipherChar(c, 26 - key);
                    }
                    break;
            }
            return output;
        }
        private int ValidateKey(string input)
        {
            int key;
            bool success = int.TryParse(input, out key);
            if (!success || key < 1 || key > 25)
            {
                MessageBox.Show("Key should be a number between 1 and 25", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            return key;
        }

        //Encipher button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = textBox1.Text;
            int key = ValidateKey(textBox2.Text);
            if (key == -1)
            {
                return;
            }
            string direction = comboBox1.Text;

            var encryptedText = Encipher(input, key, direction);

            textBox3.Text = encryptedText;
        }

        //Decipher button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string input = textBox1.Text;
            int key = ValidateKey(textBox2.Text);
            if (key == -1)
            {
                return;
            }
            string direction = comboBox1.Text == "Left" ? "Right" : "Left";

            var decryptedText = Encipher(input, key, direction);

            textBox3.Text = decryptedText;
        }
    }
}
