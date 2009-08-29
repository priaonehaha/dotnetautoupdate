using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace DotNetAutoUpdate.Tests
{
    [TestFixture]
    public class UpdateKeysFixture
    {
        [Test]
        public void Check_valid_signature()
        {
            var keyPair = UpdateKeys.FromStrongNameKey("Data\\TestKeyPair.snk");

            Assert.That(keyPair.IsValidSignature("Data\\TestFile.txt", "Data\\TestFile.txt.signature"), Is.True);
        }

        [Test]
        public void Check_invalid_signature()
        {
            var keyPair = UpdateKeys.FromStrongNameKey("Data\\TestKeyPair.snk");

            Assert.That(keyPair.IsValidSignature("Data\\TestFile.txt", "Data\\Invalid.signature"), Is.False);
        }

        [Test]
        public void Check_signing_file()
        {
            var keyPair = UpdateKeys.FromStrongNameKey("Data\\TestKeyPair.snk");
            var signatureFile = Path.GetTempFileName();

            keyPair.SignFile("Data\\TestFile.txt", signatureFile);
            var originalSignature = File.ReadAllBytes("Data\\TestFile.txt.signature");
            var newSignature = File.ReadAllBytes(signatureFile);

            Assert.That(newSignature, Is.EqualTo(originalSignature));
        }

        [Test]
        public void Check_public_key()
        {
            var keyPair = UpdateKeys.FromStrongNameKey("Data\\TestKeyPair.snk");

            var rawPublicKey = keyPair.PublicKey;
            var publicKey = UpdateKeys.FromPublicKey(rawPublicKey);

            Assert.That(publicKey.PublicKey, Is.EqualTo(keyPair.PublicKey));
        }
    }
}
