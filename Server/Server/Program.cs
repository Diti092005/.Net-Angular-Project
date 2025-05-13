using Microsoft.EntityFrameworkCore;
using Server.Bll;
using Server.Bll.Interfaces;
using Server.Dal;
using Server.Dal.Interfaces;
using Server.Server.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AppProfile));

builder.Services.AddScoped<IGiftDal, GiftDal>();
builder.Services.AddScoped<IGiftService, GiftService>();
builder.Services.AddScoped<ICategoryDal, CategoryDal>();
builder.Services.AddScoped<ICatergoryService, CatergoryService>();
builder.Services.AddScoped<IDonorService, DonorService>();
builder.Services.AddScoped<IDonorDal, DonorDal>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

app.Run();
