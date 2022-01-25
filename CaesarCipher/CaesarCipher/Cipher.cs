using System;
using System.Collections.Generic;
using System.Text;

namespace CaesarCipher
{
    public class Cipher
    {
        private static char EncipherChar(char c, int key)
        {
            if (!char.IsLetter(c))
            {
                return c;
            }
            int offset = char.IsUpper(c) ? 'A' : 'a';
            return (char)((((c + key) - offset) % 26) + offset);
        }

        public static string Encipher(string input, int key, string direction)
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
    }
}
