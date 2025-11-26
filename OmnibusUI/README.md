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
- In your sql server copy your server name from the SqlSever Login Page
- In the appsettings.json file, on the third line on DefaultConnection
- replace the server name with your local
- "Server=CAULDRON\\SQLEXPRESS;Database=PROJ4402;Trusted_Connection=True;TrustServerCertificate=True"
to
- "Server=yourserver;Database=PROJ4402;Trusted_Connection=True;TrustServerCertificate=True"

## Import Data .bak file
- attached to this repo is a bak file
- please copy the bak file and paste it in File Explorer to the following path: C:\Users\Public\Downloads
- in sql server right click on 'Databases' right below your server name
- select 'Restore Database'
- for source, select 'Device'
- select the '...' on the far right
- select 'File' for backup media type
- select 'Add' and go to the file path: C:\Users\Public\Downloads by pasting it in 'Back File Location'
- select 'PROJ4402.bak'
- select 'OK' --> 'OK' --> 'OK'

  ### Troubleshooting Data Import
- If Restore fails its b/c PROJ4402 already exist
- Resolve by querying: drop database PROJ4402

- If you could not find the .bak file in C:\Users\Public\Downloads
- Resolve by checking if it was added properly in Public\Downloads
- else, try pasting the .bak file in this path and try again C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup 
