using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EasyPOS.Modules
{
    class SysLicenseModule
    {
        public static String GetSerialNumber()
        {
            try
            {
                String serialNumber;
                String diskLetter = "C";

                ManagementObject disk = new ManagementObject("win32_logicaldisk.deviceid=\"" + diskLetter + ":\"");
                disk.Get();

                serialNumber = disk["VolumeSerialNumber"].ToString();

                return serialNumber;
            }
            catch
            {
                return "Error drive";
            }
        }

        public static String EncryptSerialNumberToLicenseCode(String serialNumber)
        {
            try
            {
                String encryptionKey = "easypos";
                byte[] bytesBuff = Encoding.Unicode.GetBytes(serialNumber);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(bytesBuff, 0, bytesBuff.Length);
                            cs.Close();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public static String DecryptLicenseCodeToSerialNumber(String licenseCode)
        {
            try
            {
                String encryptionKey = "easypos";
                byte[] cipherBytes = Convert.FromBase64String(licenseCode);

                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        return Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch
            {
                return "Invalid license.";
            }
        }
    }
}
