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

using System.Globalization;
using System.Text.Json;
using Onur.Domain;

/// <summary>
/// Description
/// </summary>
public class Repository
{
    /// <summary>
    /// List of all boxed configuration
    /// </summary>
    public IEnumerable<Config>? Multi()
    {
        var result = new List<Config>();

        var files = new Files();
        foreach (var filename in files.filenames())
        {
            var fileContent = File.ReadAllText(filename);

            // ignore empty files
            if (fileContent.Length == 0)
                continue;

            var parsedObject = Single(Path.GetFileName(filename), fileContent);
            if (parsedObject == null)
                break;

            var topicTitled = Path.GetFileNameWithoutExtension(filename);
            topicTitled = new CultureInfo(topicTitled, false).TextInfo.ToTitleCase(topicTitled);

            result.Add(new Config(topicTitled, parsedObject));
        }

        return result;
    }

    /// <summary>
    /// Box a single configuration
    /// </summary>
    private Dictionary<string, IEnumerable<Project>>? Single(string filename, string fileContent)
    {
        try
        {
            var fileDeserialized = JsonSerializer.Deserialize<
                Dictionary<string, IEnumerable<Project>>
            >(fileContent);

            if (fileDeserialized == null)
            {
                Console.WriteLine($"Error at parsing config {filename}!");
                return null;
            }

            // configuration with no listed projects
            foreach (var projects in fileDeserialized.Values)
            {
                if (!projects.Any())
                {
                    Console.WriteLine(
                        $"Error: Config {filename} has topics but not projects listed!"
                    );
                    return null;
                }
            }

            return fileDeserialized;
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Deserialization failed: {ex.Message}");
            return null;
            // Environment.Exit(1);
        }
    }
}
