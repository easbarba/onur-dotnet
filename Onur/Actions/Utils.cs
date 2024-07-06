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

using System.Diagnostics;
using Onur.Domain;

/// <summary>
/// Additional Git handling process
/// </summary>
public class Utils
{
    /// <summary>
    /// Execute Git Final command as shell
    /// </summary>
    public static void Exec(Project project, string root, string arguments)
    {
        var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "git",
                Arguments = arguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };

        proc.Start();
        var result = proc.StandardOutput.ReadToEnd();

        //         Console.WriteLine(
        //             $"""

        // -- Output --

        // {result}
        // -- Output --
        // """
        //         );

        proc.WaitForExit();
    }
}
