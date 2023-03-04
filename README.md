# TypesToSqlTablesApp
#### Converts .NET Types to Postgresql tables, fields, and foreign keys to help initialize databases and to manage schemas.


## Usage
Run "SqlScriptBuilder.exe --help" in a terminal for detailed usage.

Requires two input parameters
* Path to a .dll assembly 
* Schema name in postgresql database

The output is sent to the console, but it can be piped to a file. E.g. using powershell and the included TestClass.dll: 
```				
& .\SqlScriptBuilder.exe build --assembly .\TestClass.dll  --schema schemaname | Out-File -FilePath "output.sql"
```

Default type mapping is changed using typeMap in Constants.cs. If a KV pair of types is not found, a complex type is assumed, and a foreign key is created.

## Dependencies
Uses NodaTime for mapping time types to postgresql

https://nodatime.org/
