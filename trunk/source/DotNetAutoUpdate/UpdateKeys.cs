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

        protected static byte[] GetHashForFile(string inputFile)
        {
            using (var fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                return GetHashForStream(fileStream);
            }
        }

        protected static byte[] GetHashForStream(Stream input)
        {
            var sha1 = new SHA1Managed();
            return sha1.ComputeHash(input);
        }

        public bool IsValidSignature(Stream input, byte[] signature)
        {
            var signatureFormatter = new RSAPKCS1SignatureDeformatter(RSA);
            signatureFormatter.SetHashAlgorithm("SHA1");
            return signatureFormatter.VerifySignature(GetHashForStream(input), signature); 
        }

        public bool IsValidSignature(string inputFile, string signatureFile)
        {
            return IsValidSignature(inputFile, File.ReadAllBytes(signatureFile));
        }

        public bool IsValidSignature(string inputFile, byte[] signature)
        {
            using (var fileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                return IsValidSignature(fileStream, signature);
            }
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
