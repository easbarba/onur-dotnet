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


namespace Onur.Misc;

///<Summary>
/// List all globals variables
///</Summary>
public class Globals
{
    private static Globals? instance = null;
    private IDictionary<String, String> properties = new Dictionary<string, string>();

    private Globals()
    {
        this._defaultProperties();
    }

    /// summary
    /// returns a instance, either by creating one if does not exist
    /// or return existent (singleton pattern)
    ///
    public static Globals GetInstance
    {
        get
        {
            if (instance is null)
            {
                instance = new Globals();
            }

            return instance;
        }
    }

    /// summary
    /// add a new global key
    ///
    public void set(string key, string value)
    {
        properties[key] = value;
    }

    /// summary
    /// get a global key
    ///
    public String get(string key)
    {
        return properties[key];
    }

    private void _defaultProperties()
    {
        properties["home"] = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        properties["config"] = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        properties["onurHome"] = Path.Join(properties["config"], "onur");
        properties["projectsHome"] = Path.Join(properties["home"], "Projects");
    }
}
