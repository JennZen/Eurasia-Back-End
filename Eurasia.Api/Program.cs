using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
//configure database connection
Eurasia.DataAccess.DbSession.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("meow-meow-MEOW-MEOW-meow-meow-MEOW-MEOW-meow")),
            ValidateIssuer = true,
            ValidIssuer = "EurasiaApi",
            ValidateAudience = true,
            ValidAudience = "EurasiaClient",
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

//configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthentication();   
app.UseAuthorization();
app.MapControllers();

app.Run();