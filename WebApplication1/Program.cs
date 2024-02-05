using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("BlogDbContext");
builder.Services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<ILoginRepository, LoginRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder.WithOrigins("http://localhost:5225", "http://localhost:3000")
                   .AllowAnyMethod()                     // Allow any HTTP method
                   .AllowAnyHeader();                    // Allow any header
        });
});

var firebaseOptions = new AppOptions
{
    Credential = GoogleCredential.FromFile("adminsdk.json"),
};
FirebaseApp.Create(firebaseOptions);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddJwtBearer(options =>
   {
       options.Authority = "https://securetoken.google.com/blogapp-fc7d4";
       options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
       {
           ValidateIssuer = true,
           ValidIssuer = "https://securetoken.google.com/blogapp-fc7d4",
           ValidateAudience = true,
           ValidAudience = "blogapp-fc7d4",
           ValidateLifetime = true,
       };
   });

builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseCors("AllowSpecificOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
