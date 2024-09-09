// Create a WebApplicationBuilder object, which is responsible for configuring the web application
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Build the application after all the services and configurations have been set up
var app = builder.Build();

// Configure the HTTP request pipeline. Handle exceptions for non development environments
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();      // Use HTTTPS by default
app.UseStaticFiles();           // Allows app to serve static files from the 'wwwroot' folder

app.UseRouting();               // Enable routing

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();                  // Listen for HTTP requests
