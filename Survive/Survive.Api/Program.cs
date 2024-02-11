using Survive.Api.Auth;
using Survive.Api.Database;
using Survive.Api.Library.Products;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

AuthServices.Register(builder);
builder.AddNpgsqlDbContext<MainDbContext>("survive");

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

AuthApi.Register(app, builder);
ProductApi.Register(app, builder);


app.Run();
