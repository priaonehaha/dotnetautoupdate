using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Security;
using System.IO;
using System.Security.Cryptography;

namespace DotNetAutoUpdate
{
    /// <summary>
    /// Update keys used to verify update signatures and if loaded with private key details, sign files.
    /// </summary>
    public class UpdateKeys
    {
        public UpdateKeys(RSA rsa)
        {
            RSA = rsa;
        }

        public RSA RSA { get; private set; }

        protected byte[] GetHashForFile(string inputFile)
        {
            return GetHashForBytes(File.ReadAllBytes(inputFile));
        }

        protected byte[] GetHashForBytes(byte[] inputBytes)
        {
            var sha1 = new SHA1Managed();
            return sha1.ComputeHash(inputBytes);
        }

        public bool IsValidSignature(byte[] inputBytes, byte[] signature)
        {
            var signatureFormatter = new RSAPKCS1SignatureDeformatter(RSA);
            signatureFormatter.SetHashAlgorithm("SHA1");
            return signatureFormatter.VerifySignature(GetHashForBytes(inputBytes), signature); 
        }

        public bool IsValidSignature(string inputFile, string signatureFile)
        {
            return IsValidSignature(File.ReadAllBytes(inputFile), File.ReadAllBytes(signatureFile));
        }

        public void SignFile(string inputFile, string signatureFile)
        {
            var signatureFormatter = new RSAPKCS1SignatureFormatter(RSA);
            signatureFormatter.SetHashAlgorithm("SHA1");

            var hash = GetHashForFile(inputFile);
            var signature = signatureFormatter.CreateSignature(hash);
            
            File.WriteAllBytes(signatureFile, signature);
        }

        /// <summary>
        /// Loads the update keys from a strong name key files (.snk).
        /// </summary>
        /// <param name="fileName">The file to load.</param>
        /// <returns>The update keys.</returns>
        public static UpdateKeys FromStrongNameKey(string fileName)
        {
            var strongName = new StrongName(File.ReadAllBytes(fileName));
            return new UpdateKeys(strongName.RSA);
        }
    }
}
