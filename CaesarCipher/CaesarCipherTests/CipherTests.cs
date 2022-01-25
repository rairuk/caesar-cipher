using System;
using Xunit;
using CaesarCipher;

namespace CaesarCipherTests
{
    public class CipherTests
    {
        [Theory]
        [InlineData("test cipher", 3, "Right", "whvw flskhu")]
        [InlineData("whvw flskhu", 3, "Left", "test cipher")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 10, "Right", "klmnopqrstuvwxyzabcdefghij")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 20, "Left", "GHIJKLMNOPQRSTUVWXYZABCDEF")]
        public void CanEncryptTheory(string input, int key, string direction, string expected)
        {
            string encryptedText = Cipher.Encipher(input, key, direction);

            Assert.Equal(expected, encryptedText);
        }
    }
}
