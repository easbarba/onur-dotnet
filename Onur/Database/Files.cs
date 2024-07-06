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

namespace Onur.Database;

using Onur.Misc;

///<Summary>
/// List all configuration files
///</Summary>
public class Files
{
    private Globals globals { get; }

    /// <summary>
    /// Yup, same as before
    /// </summary>
    public Files() => globals = Globals.GetInstance;

    /// <summary>
    /// List of all files by some criteria
    /// </summary>
    public IEnumerable<string> filenames()
    {
        var cfgs = Directory
            .GetFiles(globals.get("onurHome"), "*.json")
            .ToList()
            .Where(f => File.Exists(new FileInfo(f).FullName))
            .Where(f =>
            {
                // ignore broken simbolic links

                var fileInfo = new FileInfo(f);

                // symbolic link cannot be resolved
                if (fileInfo is null)
                    return true;

                var targetFile = fileInfo.ResolveLinkTarget(true);

                // not a symbolic link
                if (targetFile is null)
                    return true;

                // target file exist
                if (File.Exists(targetFile.FullName))
                    return true;

                return false;
            })
            .Where(f => File.ReadAllText(f).Length != 0) // ignore empty files
            .Order();

        Console.Write($"Configs: ({cfgs.Count()}) [ ");

        foreach (var cfg in cfgs)
            Console.Write($" {cfg} ");

        Console.WriteLine(" ]");

        // Environment.Exit(0);
        return cfgs;
    }
}
