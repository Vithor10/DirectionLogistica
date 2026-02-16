var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços para os Controllers e Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ativa o Swagger para podermos testar o Back-end
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); // Importante: liga as rotas dos controllers

// Redireciona a página inicial para o Swagger automaticamente
app.MapGet("/", () => Results.Redirect("/swagger"));

app.Run();