using System.CommandLine;

namespace Onur
{
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
                getDefaultValue: () => false);

            var fileOption = new Option<FileInfo?>(
                name: "--file",
                getDefaultValue: () => null,
                 description: "The file to use as single configuration.");

            var listArgument = new Argument<string>(
                name: "list",
                description: "List ofprojects.");

            rootCommand.AddGlobalOption(verboseOption);
            rootCommand.AddGlobalOption(fileOption);

            // COMMANDS
            var grabCommand = new Command("grab", "Grab all projects.");
            var archiveCommand = new Command("archive", "Archiving it  all.");
            archiveCommand.AddArgument(listArgument);

            rootCommand.AddCommand(grabCommand);
            grabCommand.SetHandler((file) =>
            {
                Grab(file!);
            }, fileOption);

            rootCommand.AddCommand(archiveCommand);
            archiveCommand.SetHandler((file, pjs) =>
            {
                Archive(file!, pjs);
            }, fileOption, listArgument);

            return rootCommand;
        }

        internal static void Grab(FileInfo file)
        {
            Console.WriteLine("Grabbing! \n using file: {file.FullName}");
        }

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
}
