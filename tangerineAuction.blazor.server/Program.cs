using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using tangerineAuction.blazor.server.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<GeneratorStub>();
builder.Services.AddSingleton<MailSenderService>();
builder.Services.AddSingleton<AuctionService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

