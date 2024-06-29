using IdentityServer;
using IdentityServer4.Models;
using IdentityServer4.Test;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddIdentityServer()
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiResources(Config.ApiResources)   
    .AddInMemoryApiScopes(Config.ApiScopes) 
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddTestUsers(Config.TestUsers.ToList())
    .AddDeveloperSigningCredential();



var app = builder.Build();
app.UseStaticFiles();   

app.UseRouting();       
app.UseIdentityServer();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();
