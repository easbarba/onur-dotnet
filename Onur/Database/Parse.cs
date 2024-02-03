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
public class Parse
{
    /// <summary>
    /// Description
    /// </summary>
    public IEnumerable<Config>? All()
    {
        var result = new List<Config>();

        var files = new Files();
        foreach (var file in files.all())
        {
            var fileContent = File.ReadAllText(file);
            if (fileContent.Length == 0)
            {
                Console.WriteLine("Dang Empty!");
                break;
            }

            var fileDeserialized = Single(fileContent);
            if (fileDeserialized == null)
                break;

            var topic = Path.GetFileNameWithoutExtension(file);
            topic = new CultureInfo(topic, false).TextInfo.ToTitleCase(topic);

            result.Add(new Config(topic, fileDeserialized));
        }

        foreach (var config in result)
        {
            Console.WriteLine($"\nTopic: {config.topic}");
            foreach (var project in config.projects.ToArray())
            {
                Console.WriteLine(
                    $"""

name: {project.name}
branch: {project.branch}
url: {project.url}
"""
                );
            }
        }

        return result;
    }

    /// <summary>
    /// Description
    /// </summary>
    private IEnumerable<Project>? Single(string fileContent)
    {
        IEnumerable<Project>? fileDeserialized = JsonSerializer.Deserialize<IEnumerable<Project>>(
            fileContent
        );

        return fileDeserialized?.ToArray();
    }
}
