using Judge_Backend.Data;
using Judge_Backend.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Services

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<JudgeDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JudgeDbContext"));
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config =>
    {
        config.Cookie.Name = "JS-UserAuthCookie";
        config.LoginPath = "/auth/login";
        config.LogoutPath = "/auth/logout";
    });
builder.Services.AddAuthorization();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<JudgeDbContext>();
    DataSeeder.SeedUsers(dbContext);
}

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.UseCors(policy =>
{
    policy.WithOrigins("http://localhost:5173")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials();
});

app.UseHttpsRedirection();
app.Run();