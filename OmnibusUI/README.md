# OmnibusUI
# Members
- AppUI + Functions: Melanie Steiner
- Test Queries: Christian Frazier
- Enterprise Description: Conner
- Relation Diagram: Abdul
- ER Diagram: unknown

# About Our Software
Describe a little about what the project is about here.
## Platforms Tested on
- Windows specifically Visual Studio

# How to Run Dev and Test Environment
## Visual Studio IDE Needed
Please use the Visual Studio IDE as we havent tested this in other IDEs such as visual studio code

## NuGet Installed
- Check that you have the neccessary nugets installed
- In Visual Studio go to Tool >> Nuget Package Manager >> Manage Nuget Packages for Solution
- Ensure that you have the following installed:
- Microsoft.EntityFramework
- Microsoft.EntityFramework.SqlServer
- Microsoft.EntityFramework.Tools
- If not go to Browse and install all three

## Update Default Connection String
- In your sql server retrive your server name
- In the appsettings.json file, on the third line on DefaultConnection
- replace the server name with your local
- "Server=CAULDRON\\SQLEXPRESS;Database=PROJ4402;Trusted_Connection=True;TrustServerCertificate=True"
to
- "Server=yourserver;Database=PROJ4402;Trusted_Connection=True;TrustServerCertificate=True"

## Import Data to Database PROJ4402
- create a new database called 'PROJ4402' with: create database PROJ4402
