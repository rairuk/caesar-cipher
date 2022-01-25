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

        private int ParseKey(string input)
        {
            if (!int.TryParse(input, out int key) || key < 1 || key > 25)
            {
                MessageBox.Show("Shift should be a number between 1 and 25", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return -1;
            }
            return key;
        }
        private Direction? ParseDirection(string input)
        {
            if (!Enum.TryParse(input, out Direction direction))
            {
                MessageBox.Show("Direction should be left or right", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
            return direction;
        }

        //Encipher button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string input = textBox1.Text;
            int key = ParseKey(textBox2.Text);
            var direction = ParseDirection(comboBox1.Text);

            if(direction == null || key == -1)
            {
                return;
            }

            var encryptedText = Cipher.Encipher(input, key, direction.Value);

            textBox3.Text = encryptedText;
        }

        //Decipher button
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string input = textBox1.Text;
            int key = ParseKey(textBox2.Text);
            var direction = ParseDirection(comboBox1.Text);

            if (direction == null || key == -1)
            {
                return;
            }

            direction = direction == Direction.Right ? Direction.Left : Direction.Right;

            var decryptedText = Cipher.Encipher(input, key, direction.Value);

            textBox3.Text = decryptedText;
        }
    }
}
