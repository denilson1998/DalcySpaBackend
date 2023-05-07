

using Domain_Layer.Persistence.Repositories;
using Infrastructure_Layer;
using Infrastructure_Layer.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("connectionDb"));
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPersonRepository, PersonRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseCors();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
