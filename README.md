# TypesToSqlTablesApp
#### Converts .NET Types to Postgresql tables, fields, and foreign keys to help initialize databases and to manage schemas.


## Usage
Requires two input parameters from the console
* Path to .dll assembly
* Schema name in postgresql database

Windows Powershell scripts are included as usage examples. To use them, be sure to build the .NET project first, then run the powershell scripts located in the build folder. They will not work from the source files. 

The scripts can also be used as part of a CI/CD or build workflow by piping in the parameters and piping the output to something like a file.

Also included is a TestClass.cs for testing functionality. Just run the app, pass in the path to TestClass.dll, and provide a Schema Name. 

Default type mapping is changed using typeMap in Constants.cs. If a KV pair of types is not found, a complex type is assumed, and a foreign key is created.

## Dependencies
Uses NodaTime for mapping time types to postgresql

https://nodatime.org/
