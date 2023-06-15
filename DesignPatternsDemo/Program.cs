var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "composite",
    pattern: "{controller=Composite}/{action=Index}");

app.MapControllerRoute(
    name: "facade",
    pattern: "{controller=Facade}/{action=Index}");

app.MapControllerRoute(
    name: "builder",
    pattern: "{controller=RecursiveBuilder}/{action=Index}");

app.MapControllerRoute(
    name: "decorator",
    pattern: "{controller=DecoratorController}/{action=Index}");

app.MapControllerRoute(
    name: "cof",
    pattern: "{controller=ChainOfResponsibility}/{action=Index}");


app.MapControllerRoute(
    name: "composite_command",
    pattern: "{controller=CompositeCommand}/{action=Index}");

app.MapControllerRoute(
    name: "iterator",
    pattern: "{controller=Iterator}/{action=Index}");

app.MapControllerRoute(
    name: "mediator",
    pattern: "{controller=Mediator}/{action=Index}");

app.MapControllerRoute(
    name: "mediatorEB",
    pattern: "{controller=MediatorEventBroker}/{action=Index}");

app.MapControllerRoute(
    name: "Strategy",
    pattern: "{controller=Strategy}/{action=Index}");

app.MapControllerRoute(
    name: "NullObject",
    pattern: "{controller=NullObject}/{action=Index}");

app.MapControllerRoute(
    name: "Template",
    pattern: "{controller=Template}/{action=Index}");

app.MapControllerRoute(
    name: "TemplateCardGame",
    pattern: "{controller=TemplateCardGame}/{action=Index}");

app.MapControllerRoute(
    name: "Memento",
    pattern: "{controller=Memento}/{action=Index}");

app.MapControllerRoute(
    name: "StepWiseBuilder",
    pattern: "{controller=StepWiseBuilder}/{action=Index}");


app.Run();
