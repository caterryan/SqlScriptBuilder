namespace TypesToSqlTables.UI.ConsoleCli;

internal static class Helpers
{

    internal static (string assemblyPath, string schemaName) GetInputParameters(string[] args)
    {
        string assemblyPath;
        string schemaName;

        if (args.Length == 2)
        {
            assemblyPath = args.FirstOrDefault();
            schemaName = args[1];
        }
        else
        {
            Console.WriteLine(
                $"""
                Invalid number of input parameters.
                Number of parameters provided: {args.Length}
                
                Required Parameters: 
                  - Path to .dll Assembly
                  - Schema Name

                """);

            Console.Write("Assembly Path: ");
            assemblyPath = Console.ReadLine();

            Console.Write("Schema Name: ");
            schemaName = Console.ReadLine();
        }

        if (schemaName == "" || schemaName == null)
        {
            throw new ArgumentException("Invalid input: Schema Name cannot be empty or null");
        }

        return (assemblyPath, schemaName);
    }
}