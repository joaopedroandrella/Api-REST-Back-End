using JPCadastro;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureDbContext(builder.Configuration.GetConnectionString("MyConnection"));
builder.Services.ConfigureUnitOfWork();
builder.Services.ConfigureRepository();
builder.Services.ConfigureMediatorJPCadastroOperacional();
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod() // Get, Post, Put, Delete, etc...
    .AllowAnyHeader());

app.MapControllers();

app.Run();
