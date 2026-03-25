using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.OpenSsl;

namespace NT533.Q21._1_Lab2.SSHKey
{
    internal class SSHKeyGeneratorService
    {
        public static (string publicKey, string privateKey) GenerateKeyPair()
        {
            var keyGen = new RsaKeyPairGenerator();
            keyGen.Init(new KeyGenerationParameters(new SecureRandom(), 2048));
            var keyPair = keyGen.GenerateKeyPair();

            var rsa = (RsaKeyParameters)keyPair.Public;

            // ===== PUBLIC KEY =====
            string publicKey;
            using (var ms = new MemoryStream())
            {
                void Write(byte[] data)
                {
                    var len = BitConverter.GetBytes(System.Net.IPAddress.HostToNetworkOrder(data.Length));
                    ms.Write(len, 0, 4);
                    ms.Write(data, 0, data.Length);
                }

                byte[] exponent = Normalize(rsa.Exponent.ToByteArrayUnsigned());
                byte[] modulus = Normalize(rsa.Modulus.ToByteArrayUnsigned());

                Write(Encoding.ASCII.GetBytes("ssh-rsa"));
                Write(exponent);
                Write(modulus);

                string key = Convert.ToBase64String(ms.ToArray());
                publicKey = $"ssh-rsa {key} user@csharp";
            }

            // ===== PRIVATE KEY (PEM) =====
            string privateKey;
            using (var sw = new StringWriter())
            {
                var pemWriter = new PemWriter(sw);
                pemWriter.WriteObject(keyPair.Private);
                pemWriter.Writer.Flush();
                privateKey = sw.ToString();
            }

            return (publicKey, privateKey);
        }

        private static byte[] Normalize(byte[] data)
        {
            if (data[0] >= 0x80)
            {
                var temp = new byte[data.Length + 1];
                temp[0] = 0x00;
                Buffer.BlockCopy(data, 0, temp, 1, data.Length);
                return temp;
            }
            return data;
        }
    }
}
