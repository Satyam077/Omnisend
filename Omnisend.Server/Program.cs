using Microsoft.Extensions.Options;
using Omnisend.Server;
using Omnisend.Server.Services;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
builder.WebHost.UseUrls($"http://*:{port}");

builder.Services.AddHealthChecks();

// Add services to the container.
builder.Services.Configure<OmnisendConfig>(builder.Configuration.GetSection("Omnisend"));
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<OmnisendConfig>>().Value);

builder.Services.AddHttpClient<OmnisendService>();
builder.Services.AddScoped<OmnisendService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // This line is correct, no changes needed here

//builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("https://localhost:64421") // Angular dev URL or frontend URL
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.MapHealthChecks("/health");

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
