using AssignmentPlanner.Server.Data;
using Microsoft.EntityFrameworkCore;
using AssignmentPlanner.Server.Model;
using AssignmentPlanner.Server.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Register Identity services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlite($"Data Source=assignmentplanner.db"); });

builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AutoMapperProfiles>();
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
