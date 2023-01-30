using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;

static string GetMD5Password(string str)
{
    string strMD5Password = String.Empty;
    MD5 md5 = MD5.Create();
    byte[] byteArray = md5.ComputeHash(Encoding.Unicode.GetBytes(str));
    // for (int i = 0; i < byteArray.Length; i++)
    // {
    //     strMD5Password += byteArray[i].ToString("x");
    // }
    return Convert.ToBase64String(byteArray);
}
static string GetSHA512Password(string str)
{
    byte[] data = Encoding.UTF8.GetBytes(str);
    byte[] result;
    SHA512 shaM = SHA512.Create();
    result = shaM.ComputeHash(data);
    // string hash = string.Empty;
    // for (int i = 0; i < result.Length; i++)
    // {
    //     hash += result[i];
    // }
    // return hash;
    return Convert.ToBase64String(result);
}

static string GetSHA256Password(string str)
{
    byte[] data = Encoding.UTF8.GetBytes(str);
    byte[] result;
    SHA256 shaM = SHA256.Create();
    result = shaM.ComputeHash(data);
    // string hash = string.Empty;
    // for (int i = 0; i < result.Length; i++)
    // {
    //     hash += result[i];
    // }
    // return hash;
    return Convert.ToBase64String(result);
}

static string GetSHA1Password(string str)
{
    byte[] data = Encoding.UTF8.GetBytes(str);
    byte[] result;
    SHA1 shaM = SHA1.Create();
    result = shaM.ComputeHash(data);
    // string hash = string.Empty;
    // for (int i = 0; i < result.Length; i++)
    // {
    //     hash += result[i];
    // }
    // return hash;
    return Convert.ToBase64String(result);
}

// static string GenerateSalt()
// {
//     string chars = "ABCDEFGHIJKLMNOPQRSTUWVXYZ0123456789abcdefghijklmnopqrstuvwxyz";
//     StringBuilder salt = new StringBuilder("");
//     for (var i = 0; i < 4; i++)
//     {
//         salt.Append(new Random());
//     }
//     return salt.ToString();
// }

// System.Console.WriteLine(GenerateSalt());
Console.WriteLine(GetMD5Password("1"));
Console.WriteLine("SHA1: " + GetSHA1Password("1"));
Console.WriteLine("SHA1: " + GetSHA1Password("1"));
Console.WriteLine("SHA1: " + GetSHA1Password("22asd5646s5ad65asd654ads456as65d4654sda456asd456sad546das465sda56sad6544sa56d645asd654asd564asd456asd45665asd654asd654ads645345"));
Console.WriteLine(GetSHA256Password("1"));
Console.WriteLine(GetSHA512Password("1"));
