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
        var result = repository.All();
        if (result == null)
            return;

        foreach (var config in result)
        {
            Console.WriteLine($"\nTopic: {config.topic}");

            foreach (var project in config.projects.ToArray())
            {
                var projectPath = Path.Combine(
                    globals.get("projectsHome"),
                    config.topic.ToLower().ToString(),
                    project.name
                );

                Console.WriteLine(
                    $"""

name: {project.name}
branch: {project.branch}
url: {project.url}
path: {projectPath}
"""
                );

                if (Directory.Exists(Path.Combine(projectPath, ".git")))
                    pull.Run(project, projectPath);
                else
                    klone.Run(project, projectPath);
            }
        }
    }
}
