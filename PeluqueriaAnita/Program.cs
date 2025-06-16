using PeluqueriaAnita.Datos.Repositorios;
using PeluqueriaAnita.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ClienteRepositorio>();
builder.Services.AddScoped<ClienteServicio>();
builder.Services.AddScoped<AuthRepositorio>();
builder.Services.AddScoped<AuthServicio>();
builder.Services.AddScoped<CitaRepositorio>();
builder.Services.AddScoped<CitaServicio>();
builder.Services.AddScoped<AtencionRepositorio>();
builder.Services.AddScoped<AtencionServicio>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});
var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowReactApp");
app.MapControllers();

app.Run();
