using Countdown.Model;
using System.Net;
using System.Net.Sockets;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddSingleton<DownTimer>();
builder.Services.AddSingleton<Information>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

Console.WriteLine("Countdown Host is created.");

IHostApplicationLifetime lifetime = app.Lifetime;
lifetime.ApplicationStarted.Register(() => LogAddresses(app));

app.Run();

// Called after configuration is complete
static void LogAddresses(WebApplication app)
{
    Information information = app.Services.GetRequiredService<Information>();
    IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
    foreach (var url in app.Urls)
    {
        Uri uri = new(url);
        if(uri.Host == "0.0.0.0" || uri.Host == "+" || uri.Host == "*" || uri.Host == "[::]")
        {
            foreach (var ip in host.AddressList)
            {
                if ((ip.AddressFamily == AddressFamily.InterNetwork || ip.AddressFamily == AddressFamily.InterNetworkV6) 
                    && !(ip.ToString().StartsWith("127") || ip.ToString() == "::1") )
                {
                    information.ApplicationUrl = $"{uri.Scheme}{Uri.SchemeDelimiter}{ip}:{uri.Port}";
                    Console.WriteLine($"Listening on address: {uri.Scheme}{Uri.SchemeDelimiter}{ip}:{uri.Port}");
                }
            }
        }
        else
        {
            information.ApplicationUrl = $"{uri.Scheme}{Uri.SchemeDelimiter}{uri.Host}:{uri.Port}";
            Console.WriteLine($"Listening on address: {uri.Scheme}{Uri.SchemeDelimiter}{uri.Host}:{uri.Port}");
        }
    }
}
