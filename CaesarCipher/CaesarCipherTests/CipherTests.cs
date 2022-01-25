using System;
using Xunit;
using CaesarCipher;

namespace CaesarCipherTests
{
    public class CipherTests
    {
        [Theory]
        [InlineData("test cipher", 3, Direction.Right, "whvw flskhu")]
        [InlineData("whvw flskhu", 3, Direction.Left, "test cipher")]
        [InlineData("abcdefghijklmnopqrstuvwxyz", 10, Direction.Right, "klmnopqrstuvwxyzabcdefghij")]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 20, Direction.Left, "GHIJKLMNOPQRSTUVWXYZABCDEF")]
        public void CanEncryptTheory(string input, int key, Direction direction, string expected)
        {
            string encryptedText = Cipher.Encipher(input, key, direction);

            Assert.Equal(expected, encryptedText);
        }
    }
}
