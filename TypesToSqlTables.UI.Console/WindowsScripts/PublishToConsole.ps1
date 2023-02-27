param(
	[parameter(
        Position=0, 
        Mandatory=$true, 
        ValueFromPipeline=$true,
        ValueFromPipelineByPropertyName=$true)]
	[String] $AssemblyPath,

    [parameter(
        Position=0, 
        Mandatory=$true, 
        ValueFromPipeline=$true,
        ValueFromPipelineByPropertyName=$true)]
	[String] $SchemaName
    ) 

& ../TypesToSqlTables.UI.ConsoleCli.exe "$AssemblyPath" "$SchemaName"
