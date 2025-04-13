using System;

namespace RandomPasswordGeneratorExtension.Enums;

/// <summary>
/// Enum to select which characters are included in the password generation pool
/// </summary>
[Flags]
public enum PasswordGenerationFlags
{
    /// <summary>
    /// Use lower case letters in the password generation: [a-z]
    /// </summary>
    LowerCaseAlphabet = 0b0000_0001,
    /// <summary>
    /// Use upper case letters in the password generation: [A-Z]
    /// </summary>
    UpperCaseAlphabet = 0b0000_0010,
    
    /// <summary>
    /// Use numbers in password generation: [0-9]
    /// </summary>
    Numbers = 0b0000_0100,
    
    /// <summary>
    /// Include special characters in password generation
    /// </summary>
    SpecialCharacters = 0b0000_1000,
    
    /// <summary>
    /// Use all characters to generate the password
    /// </summary>
    All = 0b0000_1111
}
