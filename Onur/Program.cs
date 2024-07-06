/*
* onur is free software: you can redistribute it and/or modify
* it under the terms of the GNU General Public License as published by
* the Free Software Foundation, either version 3 of the License, or
* (at your option) any later version.
*
* onur is distributed in the hope that it will be useful,
* but WITHOUT ANY WARRANTY; without even the implied warranty of
* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
* GNU General Public License for more details.
*
* You should have received a copy of the GNU General Public License
* along with onur. If not, see <https://www.gnu.org/licenses/>.
*/

namespace Onur;

using System.CommandLine;
using Onur.Commands;

class Program
{
    static int Main(string[] args)
    {
        RootCommand rootCommand = Options();

        return rootCommand.InvokeAsync(args).Result;
    }

    private static RootCommand Options()
    {
        var rootCommand = new RootCommand("Easily manage multiple FLOSS repositories.");

        // OPTIONS
        var verboseOption = new Option<bool>(
            name: "--verbose",
            description: "More information on command.",
            getDefaultValue: () => false
        );

        var fileOption = new Option<FileInfo?>(
            name: "--file",
            getDefaultValue: () => null,
            description: "The file to use as single configuration."
        );

        var listArgument = new Argument<string>(name: "list", description: "List of projects.");

        rootCommand.AddGlobalOption(verboseOption);
        rootCommand.AddGlobalOption(fileOption);

        // COMMANDS
        var grabCommand = new Command("grab", "Grab all projects.");
        var archiveCommand = new Command("archive", "Archiving it  all.");
        archiveCommand.AddArgument(listArgument);

        rootCommand.AddCommand(grabCommand);
        grabCommand.SetHandler(() =>
        {
            Grab();
        });

        rootCommand.AddCommand(archiveCommand);
        archiveCommand.SetHandler(
            (file, pjs) =>
            {
                Archive(file!, pjs);
            },
            fileOption,
            listArgument
        );

        return rootCommand;
    }

    internal static void Grab() => new Grab().Run();

    internal static void Archive(FileInfo file, string projectsList)
    {
        var names = projectsList.Split(',');

        Console.WriteLine("Archiving! Using file: {file}");

        foreach (var name in names)
        {
            Console.WriteLine(name);
        }
    }
}
