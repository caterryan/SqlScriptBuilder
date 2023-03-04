using NodaTime;
using System.CommandLine;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using TypesToSqlTables.Library;

namespace TypesToSqlTables.UI.ConsoleCli;

public class Program
{
    static int Main(string[] args)
    {

        #region Commands

        RootCommand rootCommand = new RootCommand
        {
            Name = "SqlScriptBuilder.exe",
            Description = "Utility for creating SQL scripts for initializing and manage database schemas.",
            IsHidden = false,
            TreatUnmatchedTokensAsErrors = true
        };

        Command convertCommand = new(name: "build")
        {
            Description = "Converts the Types in a .NET .dll Assembly to a SQL script that creates Postgresql tables, fields, and foreign keys.",
            IsHidden = false,
            TreatUnmatchedTokensAsErrors = true
        };
        rootCommand.AddCommand(convertCommand);


        #endregion

        #region Options

        Option<FileInfo> assemblyPathOption = new(name: "--assembly")
        {
            Description = "The relative or absolute path to the .dll assembly",
            ArgumentHelpName = "path",
            AllowMultipleArgumentsPerToken = false,
            IsHidden = false,
            IsRequired = true
        };
        assemblyPathOption.AddAlias("-a");
        convertCommand.AddOption(assemblyPathOption);

        Option<string> schemaNameOption = new(name: "--schema")
        {
            Description = "The name of the existing PostgreSQL schema",
            ArgumentHelpName = "schemaName",
            AllowMultipleArgumentsPerToken = false,
            IsHidden = false,
            IsRequired = true
        };
        schemaNameOption.AddAlias("-s");
        convertCommand.AddOption(schemaNameOption);


        #endregion

        #region Handlers

        convertCommand.SetHandler(ConvertHandler.GetHandle(), assemblyPathOption, schemaNameOption);


        #endregion

        return rootCommand.InvokeAsync(args).Result;
    }
}

