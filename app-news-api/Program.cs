using app_news_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de PostgreSQL
var connectionString = builder.Configuration.GetSection("PostgreSQL:ConnectionString").Value;
builder.Services.AddSingleton(new PostgreSQLConfiguration(connectionString));

// Registrar el contexto de base de datos
object value = builder.Services.AddNpgsql<PostgreSQLConfiguration>(connectionString);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();