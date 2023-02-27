param(
	[parameter(Mandatory=$true)]
	[String] $AssemblyName
	[String] $SchemaName
)

& ../ExploreAssemblies.exe "../$AssemblyName.dll"
