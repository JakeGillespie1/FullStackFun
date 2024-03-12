using APIFun.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors stands for cross origin resource sharing
builder.Services.AddCors();

builder.Services.AddDbContext<FoodContext>(options =>
    options.UseSqlite(builder.Configuration["ConnectionStrings:FoodConnection"])
);

//We need to create an entry here for the context file to setup the repository pattern
//This will do the following: every time a user gets onto the server, go and give them a generic IFood Repo (that applies to all EFFood Repo instances)
//and create an instance of an EFFood Repo (so the client can access the data
builder.Services.AddScoped<IFoodRepository, EFFoodRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//C#, you can communicate with this location
app.UseCors(p => p.WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
