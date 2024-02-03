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
    public IEnumerable<string> all() =>
        Directory
            .GetFiles(globals.get("onurHome"), "*.json")
            .ToList()
            .Where(f => File.Exists(new FileInfo(f).FullName))
            .Where(f =>
            {
                // ignore broken simbolic links
                var fileInfo = new FileInfo(f);
                return fileInfo.LinkTarget is null
                    && !File.Exists(fileInfo.ResolveLinkTarget(true)?.FullName);
            })
            .Where(f => File.ReadAllText(f).Length != 0) // ignore empty files
            .Order();
}
