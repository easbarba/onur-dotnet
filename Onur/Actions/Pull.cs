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

using Onur.Domain;

// using LibGit2Sharp;

///<Summary>
/// Pull latest update of repository
///</Summary>
public class Pull
{
    ///<Summary>
    /// Go!
    ///</Summary>
    public void Run(Project project, string root)
    {
        // var repo = new Repository(root);
        // var pullOptions = new PullOptions();
        // var fetchOptions = new FetchOptions();
        // Commands.Fetch(repo, "origin", new string[0], fetchOptions, null);
        Utils.Exec(project, root, $"-C {root} pull");
    }
}
