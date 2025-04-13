using System;
using Microsoft.CommandPalette.Extensions.Toolkit;
using RandomPasswordGeneratorExtension.Enums;

namespace RandomPasswordGeneratorExtension.Commands;

public partial class GeneratePasswordCommand(int passwordLength, PasswordGenerationFlags selectedCharsets) : InvokableCommand
{
    public override string Name => $"Generate a new {passwordLength}-letter random password. [{selectedCharsets}]";
    public override IconInfo Icon => new("\uE8A7");

    public override CommandResult Invoke()
    {
        var validChars = GetValidChars(selectedCharsets);
        if (string.IsNullOrEmpty(validChars))
            return CommandResult.ShowToast("No valid characters selected");
        var passwordChars = new char[passwordLength];
        var random = new Random();
        for (var i = 0; i < passwordLength; i++)
        {
            passwordChars[i] = validChars[random.Next(validChars.Length)];
        }
        
        ClipboardHelper.SetText(new string(passwordChars));
        return CommandResult.ShowToast(new ToastArgs
        {
            Message = "Generated Password copied to clipboard",
            Result = CommandResult.Dismiss()
        });
    }

    /// <summary>
    /// Gets the valid password characters based on the selected flags.
    /// </summary>
    /// <param name="flags">The selected flags</param>
    /// <returns>A string containing all valid character sets</returns>
    private static string GetValidChars(PasswordGenerationFlags flags)
    {
        var validChars = string.Empty;
        if (flags.HasFlag(PasswordGenerationFlags.LowerCaseAlphabet))
            validChars += "abcdefghijklmnopqrstuvwxyz";
        if (flags.HasFlag(PasswordGenerationFlags.UpperCaseAlphabet))
            validChars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        if (flags.HasFlag(PasswordGenerationFlags.Numbers))
            validChars += "0123456789";
        if (flags.HasFlag(PasswordGenerationFlags.SpecialCharacters))
            validChars += "$%'@€\"/\\{}[](){}|;:,.<>?`~!#^&*+-_";
        
        return validChars;
    }
}
