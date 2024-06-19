﻿using System;
using System.IO;

using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto.IO;
using Mirror.BouncyCastle.Crypto.Parameters;
using Mirror.BouncyCastle.Crypto.Utilities;
using Mirror.BouncyCastle.Security;

namespace Mirror.BouncyCastle.Crypto.Operators
{
    public class Asn1CipherBuilderWithKey : ICipherBuilderWithKey
    {
        private readonly KeyParameter encKey;
        private AlgorithmIdentifier algorithmIdentifier;

        public Asn1CipherBuilderWithKey(DerObjectIdentifier encryptionOID, int keySize, SecureRandom random)
        {
            random = CryptoServicesRegistrar.GetSecureRandom(random);

            CipherKeyGenerator keyGen = CipherKeyGeneratorFactory.CreateKeyGenerator(encryptionOID, random);

            encKey = keyGen.GenerateKeyParameter();
            algorithmIdentifier = AlgorithmIdentifierFactory.GenerateEncryptionAlgID(encryptionOID, encKey.KeyLength * 8, random);
        }

        public object AlgorithmDetails
        {
            get { return algorithmIdentifier; }
        }

        public int GetMaxOutputSize(int inputLen)
        {
            throw new NotImplementedException();
        }

        public ICipher BuildCipher(Stream stream)
        {
            object cipher = CipherFactory.CreateContentCipher(true, encKey, algorithmIdentifier);

            //
            // BufferedBlockCipher
            // IStreamCipher
            //

            if (cipher is IStreamCipher)
            {
                cipher = new BufferedStreamCipher((IStreamCipher)cipher);
            }

            if (stream == null)
            {
                stream = new MemoryStream();
            }

            return new BufferedCipherWrapper((IBufferedCipher)cipher, stream);
        }

        public ICipherParameters Key
        {
            get { return encKey; }
        }
    }

    public class BufferedCipherWrapper : ICipher
    {
        private readonly IBufferedCipher bufferedCipher;
        private readonly CipherStream stream;

        public BufferedCipherWrapper(IBufferedCipher bufferedCipher, Stream source)
        {
            this.bufferedCipher = bufferedCipher;
            stream = new CipherStream(source, bufferedCipher, bufferedCipher);
        }

        public int GetMaxOutputSize(int inputLen)
        {
            return bufferedCipher.GetOutputSize(inputLen);
        }

        public int GetUpdateOutputSize(int inputLen)
        {
            return bufferedCipher.GetUpdateOutputSize(inputLen);
        }

        public Stream Stream
        {
            get { return stream; }
        }
    }
}
