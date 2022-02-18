using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NLayerApp.BLL_.Interfaces;
using NLayerApp.BLL_.Services;
using NLayerApp.DAL_.EF;
using NLayerApp.DAL_.Interfaces;
using NLayerApp.DAL_.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MazeDbContext>(options =>
    options.UseSqlServer(connectionString));


builder.Services.AddScoped<IUnitOfWork>(container =>
new EFUnitOfWork(container.GetService<MazeDbContext>())
);

builder.Services.AddScoped<IMazeService>(container => 
new MazeService(container.GetService<IMapper>(), container.GetService<IUnitOfWork>())
);;

builder.Services.AddScoped<IUserService>(container =>
new UserService(container.GetService<IUnitOfWork>())
);

builder.Services.AddScoped<IHeroService>(container =>
new HeroService(container.GetService<IMapper>(), container.GetService<IUnitOfWork>())
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
                .AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();