using System.Reflection;
using TypesToSqlTables.Library;

namespace TypesToSqlTables.UI.ConsoleCli;

public class Program
{
    static int Main(string[] args)
    {
        int exitCode = 0;
        Assembly assembly;
        //(string assemblyPath, string schemaName) = Helpers.GetInputParameters(args);
        CommandLineInputs inputs = new CommandLineInputs();
        int inputsExitCode = inputs.GetInputs(args);
        
        if (inputsExitCode != 0)
        {
            return inputsExitCode;
        }

        try
        {
            assembly = Assembly.LoadFrom(inputs.Inputs.AssemblyPath);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Invalid input for .dll assembly: {inputs.Inputs.AssemblyPath}", e);
        }
        
        TypeTables typeTables = new TypeTables(assembly, inputs.Inputs.SchemaName);

        foreach (string script in typeTables.ScriptsCreateTable)
        {
            Console.WriteLine(script);
        }

        foreach (string script in typeTables.ScriptsAddForeignKey)
        {
            Console.WriteLine(script);
        }


        return exitCode;
    }
}

