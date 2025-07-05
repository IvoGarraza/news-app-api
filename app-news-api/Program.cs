using app_news_api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración de PostgreSQL
var connectionString = builder.Configuration.GetSection("PostgreSQL:ConnectionString").Value;
builder.Services.AddSingleton(new PostgreSQLConfiguration(connectionString));
builder.Services.AddScoped<app_news_api.Data.Repositories.INewsRepository, app_news_api.Data.Repositories.NewsRepository>();

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