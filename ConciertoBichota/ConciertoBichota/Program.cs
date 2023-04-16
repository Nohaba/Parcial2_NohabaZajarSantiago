using ConciertoBichota.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Se llama al seeder 
builder.Services.AddTransient<SeederDb>();

var app = builder.Build();

//SeederData(); 

//void SeederData()
//{
//    IServiceScopeFactory? scopeFactory = app.Services.GetService<IServiceScopeFactory>();   

//    using (IServiceScope? scope = scopeFactory.CreateScope())
//    {
//        SeederDb? service = scope.ServiceProvider.GetService<SeederDb>();
//        service.SeedAsync().Wait();
//    }
//}

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
