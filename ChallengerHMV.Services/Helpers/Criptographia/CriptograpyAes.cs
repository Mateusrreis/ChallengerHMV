using System.Security.Cryptography;
using System.Text;

namespace ChallengerHMV.Services.Helpers.Criptographia
{
    public static class CriptograpyAes
    {
        public static string Key { get; set; }
        public static string StartVector { get; set; }
        private static Aes CreateInstanceAes()
        {
            string key = Key;
            string vetorInicializacao = StartVector;
            if (!(key != null &&
                  (key.Length == 16 ||
                   key.Length == 24 ||
                   key.Length == 32)))
            {
                throw new Exception("Key criptograpy need have 16 or 24, 32 character");
            }

            if (vetorInicializacao == null || vetorInicializacao.Length != 16)
                throw new Exception("The vector of started need have 16 character");

            Aes algoritmo = Aes.Create();
            algoritmo.Key = Encoding.ASCII.GetBytes(key);
            algoritmo.IV = Encoding.ASCII.GetBytes(vetorInicializacao);
            return algoritmo;
        }

        public static string Encriptar(
            string textDefault)
        {
            if (string.IsNullOrWhiteSpace(textDefault))
                throw new Exception("Encrypted context cannot empty string");


            using (Aes algoritmo = CreateInstanceAes())
            {
                ICryptoTransform encryptor = algoritmo.CreateEncryptor(algoritmo.Key, algoritmo.IV);

                using (MemoryStream streamResult =
                       new MemoryStream())
                {
                    using (CryptoStream csStream = new CryptoStream(streamResult, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter writer = new StreamWriter(csStream))
                            writer.Write(textDefault);
                    }
                    return ArrayBytesToHexString(streamResult.ToArray());
                }
            }
        }

        private static string ArrayBytesToHexString(byte[] context)
        {
            string[] arrayHex = Array.ConvertAll(context, b => b.ToString("X2"));
            return string.Concat(arrayHex);
        }

        public static string Decriptar(string textEncrypted)
        {
            if (string.IsNullOrWhiteSpace(textEncrypted))
                throw new Exception("Encrypted context cannot empty string");

            if (textEncrypted.Length % 2 != 0)
                throw new Exception("Encrypted context invalid string");

            using (Aes algoritmo = CreateInstanceAes())
            {
                ICryptoTransform decryptor = algoritmo.CreateDecryptor(algoritmo.Key, algoritmo.IV);

                string textDecrypto = null;
                using (MemoryStream streamTextoEncriptado = new MemoryStream(HexStringToArrayBytes(textEncrypted)))
                {
                    using (CryptoStream csStream = new CryptoStream(streamTextoEncriptado, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(csStream))
                            textDecrypto = reader.ReadToEnd();
                    }
                }
                return textDecrypto;
            }
        }

        private static byte[] HexStringToArrayBytes(string context)
        {
            int qtdBytesEncripted = context.Length / 2;
            byte[] arrayConteudoEncripted = new byte[qtdBytesEncripted];
            for (int i = 0; i < qtdBytesEncripted; i++)
            {
                arrayConteudoEncripted[i] = Convert.ToByte(context.Substring(i * 2, 2), 16);
            }
            return arrayConteudoEncripted;
        }
    }
}
