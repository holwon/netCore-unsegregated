using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;




public static class PasswordDerivedBytesExample
{

    [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
    static extern int memcmp(byte[] b1, byte[] b2, long count);
    // 比较数组是否相等
    static bool ByteArrayCompare(this byte[] b1, byte[] b2)
    {
        return b1.Length == b2.Length && memcmp(b1, b2, b1.Length) == 0;
    }

    public static void Main(String[] args)
    {
        // 不知是如何解密的, 可能是无法解密,因为密码的加密要不可逆才安全.

        // Get a password from the user.
        Console.WriteLine("Enter a password to produce a key:");

        // byte[] pwd = Encoding.Unicode.GetBytes(Console.ReadLine());
        // byte[] pwd2 = Encoding.Unicode.GetBytes(Console.ReadLine()); 
        byte[] pwd = Encoding.Unicode.GetBytes("qwe");
        byte[] pwd2 = Encoding.Unicode.GetBytes("qwe");
        byte[] salt = CreateRandomSalt(7);

        pwd.ByteArrayCompare(pwd2);

        // Create a TripleDESCryptoServiceProvider object.
        TripleDES tdes = TripleDES.Create();
        TripleDES tdes2 = TripleDES.Create();
        // TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

        try
        {
            Console.WriteLine("Creating a key with PasswordDeriveBytes...");

            // Create a PasswordDeriveBytes object and then create
            // a TripleDES key from the password and salt.
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(pwd, salt);
            PasswordDeriveBytes pdb2 = new PasswordDeriveBytes(pwd2, salt);


            // Create the key and set it to the Key property
            // of the TripleDESCryptoServiceProvider object.
            // This example uses the SHA1 algorithm.
            // Due to collision problems with SHA1, Microsoft recommends SHA256 or better.
            // tdes.Key = pdb.CryptDeriveKey("TripleDES", "SHA1", 192, tdes.IV);
            tdes.Key = pdb.CryptDeriveKey("TripleDES", "SHA256", 192, tdes.IV);
            tdes2.Key = pdb2.CryptDeriveKey("TripleDES", "SHA256", 192, tdes.IV);

            var pwdtoDb1 = Convert.ToBase64String(tdes.Key);
            var pwdtoDb2 = Convert.ToBase64String(tdes.IV);

            var dePwdtoDb1 = Convert.FromBase64String(pwdtoDb1);


            Console.WriteLine("Operation complete.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            // Clear the buffers
            ClearBytes(pwd);
            ClearBytes(salt);

            // Clear the key.
            tdes.Clear();
        }

        // Console.ReadLine();
    }

    //////////////////////////////////////////////////////////
    // Helper methods:
    // CreateRandomSalt: Generates a random salt value of the
    //                   specified length.
    //
    // ClearBytes: Clear the bytes in a buffer so they can't
    //             later be read from memory.
    //////////////////////////////////////////////////////////

    public static byte[] CreateRandomSalt(int length)
    {
        // Create a buffer
        byte[] randBytes;

        if (length >= 1)
        {
            randBytes = new byte[length];
        }
        else
        {
            randBytes = new byte[1];
        }

        // Create a new RNGCryptoServiceProvider.
        RandomNumberGenerator rand = RandomNumberGenerator.Create();
        // RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

        // Fill the buffer with random bytes.
        rand.GetBytes(randBytes);

        // return the bytes.
        return randBytes;
    }

    public static void ClearBytes(byte[] buffer)
    {
        // Check arguments.
        if (buffer == null)
        {
            throw new ArgumentException("buffer");
        }

        // Set each byte in the buffer to 0.
        for (int x = 0; x < buffer.Length; x++)
        {
            buffer[x] = 0;
        }
    }
}