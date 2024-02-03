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

namespace Onur.Actions;

// using LibGit2Sharp;
using Onur.Domain;

///<Summary>
/// Grabs all repositories
///</Summary>
public class Klone
{
    ///<Summary>
    /// Grabs all repositories
    ///</Summary>
    public void Run(Project project, string root)
    {
        var arguments =
            $"clone --single-branch --depth=1 --quiet --branch={project.branch} {project.url} {root}";
        Utils.Exec(project, root, arguments);
    }
}
