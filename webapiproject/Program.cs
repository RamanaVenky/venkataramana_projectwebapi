

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddXmlDataContractSerializerFormatters();

// Swagger
builder.Services.AddSwaggerGen();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
