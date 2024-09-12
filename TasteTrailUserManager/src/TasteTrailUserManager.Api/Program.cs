using TasteTrailUserManager.Api.Common.Extensions.ServiceCollection;
using TasteTrailUserManager.Api.Common.Extensions.WebApplication;
using TasteTrailUserManager.Api.Common.Extensions.WebApplicationBuilder;

var builder = WebApplication.CreateBuilder(args);

builder.SetupVariables();

builder.Services.InitDbContext(builder.Configuration);
builder.Services.InitAuth(builder.Configuration);
builder.Services.InitSwagger();
builder.Services.InitCors();


builder.Services.RegisterDependencyInjection();
builder.Services.RegisterBlobStorage(builder.Configuration);
builder.Services.AddMediatR();


builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UpdateDb();

await app.SetupRoles();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("AllowAllOrigins");

app.Run();

