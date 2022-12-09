using System.Reflection;
using Spectre.Console;

AnsiConsole.MarkupLine("Hello, :globe_showing_europe_africa:!");
AnsiConsole.MarkupLine("This project uses the following packages");
var table = new Spectre.Console.Table();
table.AddColumns("Package", "Version");
foreach(var package in Assembly.GetExecutingAssembly().GetCustomAttributes<AssemblyMetadataAttribute>().Where(attr => attr.Key == "PackageReferenceInfo")) {
    if (package.Value.Split('@', 2) is [var name, var version ]){
        table.AddRow(Markup.FromInterpolated($"[green]{name}[/]"), Markup.FromInterpolated($"[blue]{version}[/]"));
    }
}
AnsiConsole.Write(table);