using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext configuration
builder.Services.AddDbContext<BootcampProjectContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository registrations
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IInstructorRepository, EfInstructorRepository>();
builder.Services.AddScoped<IApplicantRepository, EfApplicantRepository>();
builder.Services.AddScoped<IEmployeeRepository, EfEmployeeRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Database migration
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BootcampProjectContext>();
    context.Database.EnsureCreated(); 
}

app.Run();