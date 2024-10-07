using System.Text;
using MudBlazor.Services;
using FESInvite11BE13.Components;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();



string filePath = Path.Combine(Directory.GetCurrentDirectory(), "CSV", "invite.csv");
if (!File.Exists(filePath))
{
    StringBuilder sb = new();
    sb.AppendLine("First Name,Last Name, His Email, EmailInstructor, Email Secondary Instructor(Optional)");
    File.WriteAllText(filePath, sb.ToString());
Console.WriteLine("CSV file created successfully!");
}
app.Run();
