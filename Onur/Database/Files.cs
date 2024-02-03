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

    public Files()
    {
        globals = Globals.GetInstance;
    }

    public IEnumerable<string> all() =>
        Directory
            .GetFiles(globals.get("onurHome"), "*.json")
            .ToList()
            .Where(c => File.Exists(new FileInfo(c).LinkTarget))
            .Where(c => File.ReadAllText(c).Length != 0);
}
