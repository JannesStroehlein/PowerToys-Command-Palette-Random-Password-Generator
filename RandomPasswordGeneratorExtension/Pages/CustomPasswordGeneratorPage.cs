// Copyright (c) Microsoft Corporation
// The Microsoft Corporation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Microsoft.CommandPalette.Extensions;
using Microsoft.CommandPalette.Extensions.Toolkit;
using RandomPasswordGeneratorExtension.Commands;
using RandomPasswordGeneratorExtension.Enums;

namespace RandomPasswordGeneratorExtension.Pages;

/// <remarks>
/// Unused but planed for future use.
/// </remarks>
internal sealed partial class CustomPasswordGeneratorPage : ListPage
{
    public override IListItem[] GetItems()
    {                                                               
        return [
            new ListItem(new GeneratePasswordCommand(12, PasswordGenerationFlags.All))
            {
                Title = "Generate a new random password. [a-zA-Z0-9$%']"
            }
        ];
    }
}
