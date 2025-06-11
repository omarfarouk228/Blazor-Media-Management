using Blazored.LocalStorage;
using BlazorSuperApp;
using BlazorSuperApp.Components;
using BlazorSuperApp.Handlers;
using BlazorSuperApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Get BaseUrl from appsettings.json
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddTransient<AuthHeaderHandler>();

// builder.Services.AddAuthorization();
// builder.Services.AddAuthentication();


builder.Services.AddHttpClient<GroupService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);

}).AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<MediaService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
}).AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddHttpClient<AuthService>(client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
});


// Add scoped services
// builder.Services.AddScoped<GroupService>(sp =>
// {
//     var httpClient = sp.GetRequiredService<IHttpClientFactory>().CreateClient("GroupService");
//     var configuration = sp.GetRequiredService<IOptions<ApiSettings>>();
//     return new GroupService(httpClient, configuration);
// });
//builder.Services.AddScoped<MediaService>();
//builder.Services.AddScoped<AuthService>();

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

// app.UseSession();


app.UseHttpsRedirection();


// app.UseAuthentication();
// app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();