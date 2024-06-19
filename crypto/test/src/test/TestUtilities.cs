using System;
using System.Collections.Generic;

using Mirror.BouncyCastle.Asn1;
using Mirror.BouncyCastle.Asn1.X509;
using Mirror.BouncyCastle.Crypto;
using Mirror.BouncyCastle.Crypto.Operators;
using Mirror.BouncyCastle.Math;
using Mirror.BouncyCastle.Security;
using Mirror.BouncyCastle.Security.Certificates;
using Mirror.BouncyCastle.X509;
using Mirror.BouncyCastle.X509.Extension;

namespace Mirror.BouncyCastle.Tests
{
	/**
	 * Test Utils
	 */
	internal class TestUtilities
	{
		/**
		 * Create a random 1024 bit RSA key pair
		 */
		public static AsymmetricCipherKeyPair GenerateRsaKeyPair()
		{
			IAsymmetricCipherKeyPairGenerator kpGen = GeneratorUtilities.GetKeyPairGenerator("RSA");

			kpGen.Init(new KeyGenerationParameters(new SecureRandom(), 1024));

			return kpGen.GenerateKeyPair();
		}

        public static X509Certificate GenerateRootCert(
            AsymmetricCipherKeyPair pair)
        {
            Asn1SignatureFactory signatureFactory = new Asn1SignatureFactory("SHA256WithRSAEncryption", pair.Private, null);

            X509V1CertificateGenerator certGen = new X509V1CertificateGenerator();
            certGen.SetSerialNumber(BigInteger.One);
            certGen.SetIssuerDN(new X509Name("CN=Test CA Certificate"));
            certGen.SetNotBefore(DateTime.UtcNow.AddSeconds(-50));
            certGen.SetNotAfter(DateTime.UtcNow.AddSeconds(50));
            certGen.SetSubjectDN(new X509Name("CN=Test CA Certificate"));
            certGen.SetPublicKey(pair.Public);
            return certGen.Generate(signatureFactory);
        }

        public static X509Certificate GenerateIntermediateCert(
			AsymmetricKeyParameter	intKey,
			AsymmetricKeyParameter	caKey,
			X509Certificate			caCert)
		{
			X509V3CertificateGenerator certGen = new X509V3CertificateGenerator();

			certGen.SetSerialNumber(BigInteger.One);
			certGen.SetIssuerDN(caCert.SubjectDN);
			certGen.SetNotBefore(DateTime.UtcNow.AddSeconds(-50));
			certGen.SetNotAfter(DateTime.UtcNow.AddSeconds(50));
			certGen.SetSubjectDN(new X509Name("CN=Test Intermediate Certificate"));
			certGen.SetPublicKey(intKey);

			certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(caCert));
			certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(intKey));
			certGen.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(0));
			certGen.AddExtension(X509Extensions.KeyUsage, true, new KeyUsage(KeyUsage.DigitalSignature | KeyUsage.KeyCertSign | KeyUsage.CrlSign));

			return certGen.Generate(new Asn1SignatureFactory("SHA256WithRSAEncryption", caKey, null));
		}

		public static X509Certificate GenerateEndEntityCert(
			AsymmetricKeyParameter entityKey,
			AsymmetricKeyParameter caKey,
			X509Certificate caCert)
		{
			X509V3CertificateGenerator certGen = new X509V3CertificateGenerator();

			certGen.SetSerialNumber(BigInteger.One);
			certGen.SetIssuerDN(caCert.SubjectDN);
			certGen.SetNotBefore(DateTime.UtcNow.AddSeconds(-50));
			certGen.SetNotAfter(DateTime.UtcNow.AddSeconds(50));
			certGen.SetSubjectDN(new X509Name("CN=Test End Certificate"));
			certGen.SetPublicKey(entityKey);

			certGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(caCert));
			certGen.AddExtension(X509Extensions.SubjectKeyIdentifier, false, new SubjectKeyIdentifierStructure(entityKey));
			certGen.AddExtension(X509Extensions.BasicConstraints, true, new BasicConstraints(false));
			certGen.AddExtension(X509Extensions.KeyUsage, true, new KeyUsage(KeyUsage.DigitalSignature | KeyUsage.KeyEncipherment));

			return certGen.Generate(new Asn1SignatureFactory("SHA256WithRSAEncryption", caKey, null));
		}

		public static X509Crl CreateCrl(
			X509Certificate			caCert,
			AsymmetricKeyParameter	caKey,
			BigInteger				serialNumber)
		{
			X509V2CrlGenerator	crlGen = new X509V2CrlGenerator();
			DateTime			now = DateTime.UtcNow;

			crlGen.SetIssuerDN(caCert.SubjectDN);

			crlGen.SetThisUpdate(now);
			crlGen.SetNextUpdate(now.AddSeconds(100));

			crlGen.AddCrlEntry(serialNumber, now, CrlReason.PrivilegeWithdrawn);

			crlGen.AddExtension(X509Extensions.AuthorityKeyIdentifier, false, new AuthorityKeyIdentifierStructure(caCert));
			crlGen.AddExtension(X509Extensions.CrlNumber, false, new CrlNumber(BigInteger.One));

			return crlGen.Generate(new Asn1SignatureFactory("SHA256WithRSAEncryption", caKey, null));
		}
	}
}
