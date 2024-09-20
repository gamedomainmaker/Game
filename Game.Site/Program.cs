var builder = WebApplication.CreateBuilder(args);

await Docfx.Dotnet.DotnetApiCatalog.GenerateManagedReferenceYamlFiles("docfx.json");
await Docfx.Docset.Build("docfx.json");

var app = builder.Build();

app.UseDefaultFiles()
    .UseStaticFiles();

app.Run();
