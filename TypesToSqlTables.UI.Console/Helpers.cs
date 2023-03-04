using System.Reflection;
using TypesToSqlTables.Library;

namespace TypesToSqlTables.UI.ConsoleCli;

internal static class Helpers
{
    public static Action<FileInfo, string> GetConvertHandle()
    {
        return (assemblyPath, schemaName) =>
        {
            if (!assemblyPath.Exists)
            {
                throw new ArgumentException("Invalid Input: assembly path does not exist");
            }

            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFrom(assemblyPath.FullName);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Invalid input for .dll assembly: {assemblyPath.FullName}", e);
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
        };

    }
}