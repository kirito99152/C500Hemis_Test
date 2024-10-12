using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<C500Hemis.Models.HemisContext>(options =>
//    options.UseSqlServer("Server=tcp:c500.database.windows.net,1433;Database=dbHemisC500;User Id=c500;Password=@Abc1234"));
builder.Services.AddDbContext<C500Hemis.Models.HemisContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("C500")));


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TbDeAnDuAnChuongTrinhs}/{action=Index}/{id?}");

app.Run();
