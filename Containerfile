# onur is free software: you can redistribute it and/or modify
# it under the terms of the GNU General Public License as published by
# the Free Software Foundation, either version 3 of the License, or
# (at your option) any later version.
#
# onur is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.
#
# You should have received a copy of the GNU General Public License
# along with onur. If not, see <https://www.gnu.org/licenses/>.

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY Onur/Onur.csproj ./Onur/Onur.csproj
COPY Onur.Tests/Onur.Tests.csproj ./Onur.Tests/Onur.Tests.csproj
COPY Onur.sln .
RUN dotnet restore
RUN ./prepare.bash
COPY . .
ENTRYPOINT ["dotnet", "test"]
