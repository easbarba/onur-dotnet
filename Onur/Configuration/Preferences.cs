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

namespace Onur.Configuration;

///<Summary>
/// Checks and leverages user preferences
///</Summary>
public class Preferences
{
    /// summary
    /// User Home Directory
    ///
    public string Home { get; init; }

    /// summary
    /// User Configuration folder + "onur"
    ///
    public string OnurHome { get; init; }

    /// summary
    /// Go
    ///
    public Preferences()
    {
        Home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        var cfg = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        OnurHome = Path.Combine(cfg, "onur");
    }
}
