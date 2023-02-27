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
	[String] $SchemaName,

    [parameter(
        Position=0, 
        Mandatory=$true, 
        ValueFromPipeline=$true,
        ValueFromPipelineByPropertyName=$true)]
	[String] $WritePath
    )

& ../TypesToSqlTables.UI.ConsoleCli.exe "$AssemblyPath" "$SchemaName" | Out-File -FilePath "$WritePath"
