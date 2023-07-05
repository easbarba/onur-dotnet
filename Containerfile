FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY Onur/Onur.csproj ./Onur/Onur.csproj
COPY Onur.Tests/Onur.Tests.csproj ./Onur.Tests/Onur.Tests.csproj
COPY Onur.sln ./
RUN dotnet restore
COPY ./examples /root/.config/onur
COPY . ./
ENTRYPOINT ["dotnet", "test"]
