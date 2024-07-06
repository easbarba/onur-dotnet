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

namespace Onur.Commands;

using Onur.Actions;
using Onur.Database;
using Onur.Misc;

///<Summary>
/// Grabs all repositories
///</Summary>
public class Grab
{
    ///<Summary>
    /// Grab by either cloning or pulling a existent repository updates
    ///</Summary>
    public void Run()
    {
        var globals = Globals.GetInstance;
        var klone = new Klone();
        var pull = new Pull();

        var repository = new Repository();
        var allConfigs = repository.Multi();
        if (allConfigs == null)
            return;

        foreach (var config in allConfigs)
        {
            Console.WriteLine($"\n{config.configName}");

            foreach (var topic in config.topics)
            {
                Console.WriteLine($"\n  {topic.Key}");
                foreach (var project in topic.Value)
                {
                    var projectPath = Path.Combine(
                        globals.get("projectsHome"),
                        config.configName.ToLower().ToString(),
                        topic.Key,
                        project.name
                    );

                    printInfo(project);

                    if (Directory.Exists(Path.Combine(projectPath, ".git")))
                        pull.Run(project, projectPath);
                    else
                        klone.Run(project, projectPath);
                }
            }
        }
    }

    private void printInfo(Domain.Project project)
    {
        var nameTruncated =
            project.name.Length <= 37 ? project.name : string.Concat(project.name.Take(37)) + "...";
        var urlTruncated =
            project.url.Length <= 50 ? project.url : string.Concat(project.url.Take(50)) + "...";
        Console.WriteLine($"{" ", 4}{nameTruncated, -45}{urlTruncated, -60}{project.branch}");
    }
}
