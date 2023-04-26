using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;


namespace backend.Utils;

public interface IEncode
{
  string Encriptar(string textoQueEncriptaremos);
  string Desencriptar(string textoEncriptado);
}

public class AES256 : IEncode
{

  private readonly IConfiguration _configuration;
  public AES256(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  #region PublicMethods
  public string Encriptar(string textoQueEncriptaremos)
  {
    string? key = _configuration["EncryptKeys:key"];
    if (key == null) throw new Exception("No se encontro la llave dentro de las variables de sistema");
    try
    {
      bool textIsValid = "" != textoQueEncriptaremos.Trim();
      if (!textIsValid) throw new Exception("Debe ingresar un texto Valido");

      bool keyIsValid = "" != key.Trim();
      if (!keyIsValid) throw new Exception("No se encontro la llave dentro de las variables de sistema");

      return Encrypt(textoQueEncriptaremos, key);
    }
    catch (Exception err)
    {
      return err.Message;
    }
  }

  public string Desencriptar(string textoEncriptado)
  {
    string? key = _configuration["EncryptKeys:key"];
    if (key == null) throw new Exception("No se encontro la llave dentro de las variables de sistema");
    try
    {
      bool textIsValid = "" != textoEncriptado.Trim();
      if (!textIsValid) throw new Exception("Debe ingresar un texto Valido");

      bool keyIsValid = "" != key.Trim();
      if (!keyIsValid) throw new Exception("No se encontro la llave dentro de las variables de sistema");

      return Decrypt(textoEncriptado, key);
    }
    catch (Exception err)
    {
      return err.Message;
    }
  }
  #endregion


  #region PrivateMethods
  private string Encrypt(string plainText, string keyString)
  {
    byte[] cipherData;
    Aes aes = Aes.Create();
    aes.Key = GetHashedKey(keyString);
    aes.GenerateIV();
    aes.Mode = CipherMode.CBC;
    ICryptoTransform cipher = aes.CreateEncryptor(aes.Key, aes.IV);

    using (MemoryStream ms = new MemoryStream())
    {
      using (CryptoStream cs = new CryptoStream(ms, cipher, CryptoStreamMode.Write))
      using (StreamWriter sw = new StreamWriter(cs))
      {
        sw.Write(plainText);
      }
      cipherData = ms.ToArray();
    }

    byte[] combinedData = new byte[aes.IV.Length + cipherData.Length];
    Array.Copy(aes.IV, 0, combinedData, 0, aes.IV.Length);
    Array.Copy(cipherData, 0, combinedData, aes.IV.Length, cipherData.Length);
    return Convert.ToBase64String(combinedData);
  }


  public string Decrypt(string combinedString, string keyString)
  {
    string plainText;
    byte[] combinedData = Convert.FromBase64String(combinedString);
    Aes aes = Aes.Create();
    aes.Key = GetHashedKey(keyString);
    byte[] iv = new byte[aes.BlockSize / 8];
    byte[] cipherText = new byte[combinedData.Length - iv.Length];
    Array.Copy(combinedData, iv, iv.Length);
    Array.Copy(combinedData, iv.Length, cipherText, 0, cipherText.Length);
    aes.IV = iv;
    aes.Mode = CipherMode.CBC;
    ICryptoTransform decipher = aes.CreateDecryptor(aes.Key, aes.IV);

    using (MemoryStream ms = new MemoryStream(cipherText))
    {
      using (CryptoStream cs = new CryptoStream(ms, decipher, CryptoStreamMode.Read))
      using (StreamReader sr = new StreamReader(cs))
      {
        plainText = sr.ReadToEnd();
      }
      return plainText;
    }
  }

  private byte[] GetHashedKey(string passwordText)
  {
    string? salt = _configuration["EncryptKeys:Salt"];
    if (salt == null) throw new Exception("No se encontro la llave salt dentro de las variables de sistema");
    var argon2id = new Argon2id(Encoding.UTF8.GetBytes(passwordText))
    {
      Salt = Encoding.UTF8.GetBytes(salt),
      DegreeOfParallelism = 8, // four cores
      MemorySize = 512, // 512kb  0.5mb
      Iterations = 2,
    };

    return argon2id.GetBytes(32);
  }
  #endregion
}