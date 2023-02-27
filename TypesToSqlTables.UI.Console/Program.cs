using System.Reflection;
using TypesToSqlTables.Library;

namespace TypesToSqlTables.UI.ConsoleCli;

public class Program
{
    static void Main(string[] args)
    {
        Assembly assembly;
        (string assemblyPath, string schemaName) = Helpers.GetInputParameters(args);

        try
        {
            assembly = Assembly.LoadFrom(assemblyPath);
        }
        catch (Exception e)
        {
            throw new ArgumentException($"Invalid input for .dll assembly: {assemblyPath}", e);
        }
        
        TypeTables typeTables = new TypeTables(assembly, schemaName);

        foreach (string script in typeTables.ScriptsCreateTable)
        {
            Console.WriteLine(script);
        }

        foreach (string script in typeTables.ScriptsAddForeignKey)
        {
            Console.WriteLine(script);
        }
    }
}

