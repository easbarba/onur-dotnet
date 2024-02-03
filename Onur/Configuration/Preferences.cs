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
    public Preferences()
    {
        Home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        Welcome = "Welcome";

        var cfg = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        OnurHome = Path.Combine(cfg, "onur");
    }

    public string Welcome { get; set; }
    public string Home { get; set; }
    public string OnurHome { get; set; }
}
