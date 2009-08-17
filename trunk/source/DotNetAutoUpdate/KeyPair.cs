using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Security;
using System.IO;
using System.Security.Cryptography;

namespace DotNetAutoUpdate
{
    public class KeyPair
    {
        public KeyPair(string fileName)
        {
            StrongName = new StrongName(File.ReadAllBytes(fileName));
        }

        public StrongName StrongName { get; private set; }

        public RSA RSA { get { return StrongName.RSA; } }

        protected byte[] GetHashForFile(string inputFile)
        {
            var inputBytes = File.ReadAllBytes(inputFile);
            var sha1 = new SHA1Managed();
            return sha1.ComputeHash(inputBytes);
        }

        public bool IsValidSignature(string inputFile, string signatureFile)
        {
            var signatureFormatter = new RSAPKCS1SignatureDeformatter(RSA);
            signatureFormatter.SetHashAlgorithm("SHA1");

            var hash = GetHashForFile(inputFile);
            var signature = File.ReadAllBytes(signatureFile);
            return signatureFormatter.VerifySignature(hash, signature);            
        }

        public void SignFile(string inputFile, string signatureFile)
        {
            var signatureFormatter = new RSAPKCS1SignatureFormatter(RSA);
            signatureFormatter.SetHashAlgorithm("SHA1");

            var hash = GetHashForFile(inputFile);
            var signature = signatureFormatter.CreateSignature(hash);
            
            File.WriteAllBytes(signatureFile, signature);
        }
    }
}
