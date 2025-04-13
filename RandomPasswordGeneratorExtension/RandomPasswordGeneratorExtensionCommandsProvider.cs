// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using RandomPasswordGeneratorExtension.Commands;
using RandomPasswordGeneratorExtension.Enums;

namespace RandomPasswordGeneratorExtension;

public sealed partial class RandomPasswordGeneratorExtensionCommandsProvider : CommandProvider
{
    private static readonly int[] DefaultPasswordLengths = [8, 12, 16, 20, 24, 32];
    private readonly ICommandItem[] _commands;

    public RandomPasswordGeneratorExtensionCommandsProvider()
    {
        DisplayName = "Random Password Generator";
        Icon = IconHelpers.FromRelativePath("Assets\\StoreLogo.png");
        
        // Create a list of commands for each default password length and the custom password generator page
        var commands = new ICommandItem[DefaultPasswordLengths.Length];
        for (var i = 0; i < DefaultPasswordLengths.Length; i++)
        {
            var length = DefaultPasswordLengths[i];
            commands[i] = new CommandItem(new GeneratePasswordCommand(length, PasswordGenerationFlags.All))
            {
                Subtitle = $"Generate a new {length}-letter random password. [a-zA-Z0-9$%']",
                Icon = new IconInfo("\uE72E")
            };
        }
        
        _commands = commands;
    }

    public override ICommandItem[] TopLevelCommands()
    {
        return _commands;
    }

}
