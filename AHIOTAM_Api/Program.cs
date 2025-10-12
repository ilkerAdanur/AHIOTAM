using AHIOTAM_Api.Models.Context;
using AHIOTAM_Api.Repositories.CategoryRepositories;
using AHIOTAM_Api.Repositories.ContactRepository;
using AHIOTAM_Api.Repositories.GalleryRepositories;
using AHIOTAM_Api.Repositories.HomePageAboutRepository;
using AHIOTAM_Api.Repositories.MenuDetailRepositories;
using AHIOTAM_Api.Repositories.MenuIngredientRepositories;
using AHIOTAM_Api.Repositories.MenuRepository;
using AHIOTAM_Api.Repositories.StatisticsRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<Context>();
builder.Services.AddTransient<IHomePageAboutRepository,HomePageAboutRepository>();
builder.Services.AddTransient<IMenuRepository, MenuRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
builder.Services.AddTransient<IGalleryRepository, GalleryRepository>();
builder.Services.AddTransient<IContactRepository, ContactRepository>();
builder.Services.AddTransient<IMenuDetailRepository, MenuDetailRepository>();
builder.Services.AddTransient<IMenuIngredientRepository, MenuIngredientRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
