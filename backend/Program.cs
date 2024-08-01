using Microsoft.EntityFrameworkCore;
using Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CoursesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyDbConnection")
    ?? throw new InvalidOperationException("Connection string 'MyDbConnection' not found.")));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// TODO: replace with <ISemesterService, SemesterService> when I'm done with it!!!!
builder.Services.AddScoped<SemesterService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<AssignmentService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

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
