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

namespace Onur.Domain;

/// summary
/// Provide essential information to project
///
public record Project
{
    /// summary
    /// Project's name
    ///
    public required string name { get; init; }

    /// summary
    /// Project's Branch: defaults to master
    ///
    public string branch { get; init; } = "master";

    /// summary
    /// Project's full URI
    ///
    public required string url { get; init; }
}
