var builder = WebApplication.CreateBuilder(args);
//configure database connection
Eurasia.DataAccess.DbSession.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
//add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//configure the HTTP request pipeline
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
