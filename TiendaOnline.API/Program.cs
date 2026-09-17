var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios para los controladores
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Configurar la política de CORS (PermitirWasm)
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirWasm", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// 3. Configurar Swagger en modo desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 4. Activar CORS (Importante: debe ir antes de MapControllers)
app.UseCors("PermitirWasm");

app.UseAuthorization();
app.MapControllers();

app.Run();