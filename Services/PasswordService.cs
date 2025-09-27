using System.Security.Cryptography;
using System.Text;

namespace PwdGen.Services;

public class PasswordService
{
    private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
    private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string DigitChars = "0123456789";
    private const string SpecialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

    public string GeneratePassword(PasswordOptions options)
    {
        if (options.Length < 1 || options.Length > 128)
            throw new ArgumentException("Password length must be between 1 and 128 characters.");

        var charset = BuildCharset(options);
        if (string.IsNullOrEmpty(charset))
            throw new ArgumentException("At least one character type must be selected.");

        var password = new StringBuilder();
        
        // Ensure at least one character from each selected type
        if (options.IncludeLowercase)
            password.Append(GetRandomChar(LowercaseChars));
        if (options.IncludeUppercase)
            password.Append(GetRandomChar(UppercaseChars));
        if (options.IncludeDigits)
            password.Append(GetRandomChar(DigitChars));
        if (options.IncludeSpecialChars)
            password.Append(GetRandomChar(SpecialChars));

        // Fill the rest with random characters from the full charset
        while (password.Length < options.Length)
        {
            password.Append(GetRandomChar(charset));
        }

        // Shuffle the password to randomize positions
        return ShuffleString(password.ToString());
    }

    private string BuildCharset(PasswordOptions options)
    {
        var charset = new StringBuilder();
        
        if (options.IncludeLowercase)
            charset.Append(LowercaseChars);
        if (options.IncludeUppercase)
            charset.Append(UppercaseChars);
        if (options.IncludeDigits)
            charset.Append(DigitChars);
        if (options.IncludeSpecialChars)
            charset.Append(SpecialChars);

        return charset.ToString();
    }

    private char GetRandomChar(string charset)
    {
        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[4];
        rng.GetBytes(bytes);
        var value = BitConverter.ToUInt32(bytes, 0);
        return charset[(int)(value % (uint)charset.Length)];
    }

    private string ShuffleString(string input)
    {
        var array = input.ToCharArray();
        using var rng = RandomNumberGenerator.Create();
        
        for (int i = array.Length - 1; i > 0; i--)
        {
            var bytes = new byte[4];
            rng.GetBytes(bytes);
            var j = (int)(BitConverter.ToUInt32(bytes, 0) % (uint)(i + 1));
            (array[i], array[j]) = (array[j], array[i]);
        }
        
        return new string(array);
    }
}

public class PasswordOptions
{
    public int Length { get; set; } = 12;
    public bool IncludeLowercase { get; set; } = true;
    public bool IncludeUppercase { get; set; } = true;
    public bool IncludeDigits { get; set; } = true;
    public bool IncludeSpecialChars { get; set; } = false;
}