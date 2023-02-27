using System.Reflection;
using TypesToSqlTables.Library;

namespace TypesToSqlTables.UI.ConsoleCli;

public class Program
{
    static void Main(string[] args)
    {
        string assemblyPath = args.FirstOrDefault();
        string schemaName = args[1];

        var assembly = Assembly.LoadFrom(assemblyPath);

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

