using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;

namespace TypesToSqlTables.UI.ConsoleCli
{
    public class CommandLineInputs
    {
		private RootCommand rootCmd = new();

        private ProgramInputs inputs = new();

        public ProgramInputs Inputs
        {
            get { return inputs; }
        }

        public CommandLineInputs()
		{
            rootCmd.Description = "Converts the Types in a .NET Assembly to Postgresql tables, fields, and foreign keys. Helps initialize databases and manage schemas.";
            rootCmd.IsHidden = false;
            rootCmd.TreatUnmatchedTokensAsErrors = true;

            Option<FileInfo> assemblyPathOption = new (name: "--assembly");
            assemblyPathOption.Description = "The relative or absolute path to the .dll assembly";
            assemblyPathOption.ArgumentHelpName = "Assembly Path";
            assemblyPathOption.AddAlias("-a");
            assemblyPathOption.AllowMultipleArgumentsPerToken = false;
            assemblyPathOption.IsHidden = false;
            assemblyPathOption.IsRequired = true;

            Option<string> schemaNameOption = new (name: "--schema");
            schemaNameOption.Description = "The name of the existing PostgreSQL schema";
            schemaNameOption.ArgumentHelpName = "Schema Name";
            schemaNameOption.AddAlias("-s");
            schemaNameOption.AllowMultipleArgumentsPerToken = false;
            schemaNameOption.IsHidden = false;
            schemaNameOption.IsRequired = true;

            rootCmd.Add(assemblyPathOption);
            rootCmd.Add(schemaNameOption);

            rootCmd.SetHandler(
                (assemblyPath, schemaName) =>
                {
                    if (!assemblyPath.Exists)
                    {
                        throw new ArgumentException("Invalid Input: assembly path does not exist");
                    }

                    inputs.AssemblyPath = assemblyPath.FullName;
                    inputs.SchemaName = schemaName;
                },
                assemblyPathOption, schemaNameOption);
        }
        public int GetInputs(string[] args)
        {
            return rootCmd.Invoke(args);
        }
    }

    public class ProgramInputs
    {
        private string? assemblyPath;

        public string? AssemblyPath
        {
            get { return assemblyPath; }
            set { assemblyPath = value; }
        }

        private string? schemaName;

        public string? SchemaName
        {
            get { return schemaName; }
            set { schemaName = value; }
        }

        public ProgramInputs()
        {

        }
    }
}