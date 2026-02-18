var builder = WebApplication.CreateBuilder(args);

// Configuração de CORS para liberar o acesso do Angular
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa o CORS antes das rotas
app.UseCors("AllowAngular");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Comentado para evitar erro de certificado SSL no teste local
// app.UseHttpsRedirection(); 

app.MapControllers();

app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();