using ContractManagementBL;
using ContractManagementDAL.DB;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IContractManagementData, ContractManagementData>();
builder.Services.AddTransient<IContractManagementRepository, ContractManagementRepository>();
builder.Services.AddTransient<IContractManagementValidator, ContractManagementValidator>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => {
        options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                       });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
