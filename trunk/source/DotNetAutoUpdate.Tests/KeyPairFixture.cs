using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace DotNetAutoUpdate.Tests
{
    [TestFixture]
    public class KeyPairFixture
    {
        [Test]
        public void Check_valid_signature()
        {
            var keyPair = new KeyPair("Data\\TestKeyPair.snk");

            Assert.That(keyPair.IsValidSignature("Data\\TestFile.txt", "Data\\TestFile.txt.signature"), Is.True);
        }

        [Test]
        public void Check_invalid_signature()
        {
            var keyPair = new KeyPair("Data\\TestKeyPair.snk");

            Assert.That(keyPair.IsValidSignature("Data\\TestFile.txt", "Data\\Invalid.signature"), Is.False);
        }

        [Test]
        public void Check_signing_file()
        {
            var keyPair = new KeyPair("Data\\TestKeyPair.snk");
            var signatureFile = Path.GetTempFileName();

            keyPair.SignFile("Data\\TestFile.txt", signatureFile);
            var originalSignature = File.ReadAllBytes("Data\\TestFile.txt.signature");
            var newSignature = File.ReadAllBytes(signatureFile);

            Assert.That(newSignature, Is.EqualTo(originalSignature));
        }
    }
}
