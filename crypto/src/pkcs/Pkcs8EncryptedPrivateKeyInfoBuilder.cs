using System;
using System.IO;

using Mirror.BouncyCastle.Asn1.Pkcs;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Utilities;
using Mirror.BouncyCastle.Utilities.IO;

namespace Mirror.BouncyCastle.Pkcs
{
    public class Pkcs8EncryptedPrivateKeyInfoBuilder
    {
        private PrivateKeyInfo privateKeyInfo;

        public Pkcs8EncryptedPrivateKeyInfoBuilder(byte[] privateKeyInfo):  this(PrivateKeyInfo.GetInstance(privateKeyInfo))
        {
        }

        public Pkcs8EncryptedPrivateKeyInfoBuilder(PrivateKeyInfo privateKeyInfo)
        {
            this.privateKeyInfo = privateKeyInfo;
        }

        /// <summary>
        /// Create the encrypted private key info using the passed in encryptor.
        /// </summary>
        /// <param name="encryptor">The encryptor to use.</param>
        /// <returns>An encrypted private key info containing the original private key info.</returns>
        public Pkcs8EncryptedPrivateKeyInfo Build(ICipherBuilder encryptor)
        {
            try
            {
                MemoryStream bOut = new MemoryStream();
                ICipher cOut = encryptor.BuildCipher(bOut);

                using (var stream = cOut.Stream)
                {
                    privateKeyInfo.EncodeTo(stream);
                }

                return new Pkcs8EncryptedPrivateKeyInfo(
                    new EncryptedPrivateKeyInfo((AlgorithmIdentifier)encryptor.AlgorithmDetails, bOut.ToArray()));
            }
            catch (IOException)
            {
                throw new InvalidOperationException("cannot encode privateKeyInfo");
            }
        }
    }
}
