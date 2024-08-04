using Microsoft.EntityFrameworkCore;
using Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoursesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")
    ?? throw new InvalidOperationException("Connection string 'MyDbConnection' not found.")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddScoped<SemesterService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<AssignmentService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseCors("AllowReactApp");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => @"CourseTrace management API. Navigate to /swagger to open the Swagger test UI.");
app.Run();
