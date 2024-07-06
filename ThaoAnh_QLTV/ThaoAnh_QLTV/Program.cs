using ThaoAnh_QLTV.Data;
using QLTV.UseCases.PluginInterfaces.DataStore;
using QLTV.DataStore.SQL.Dapper.Helpers;
using QLTV.DataStore.SQL.Dapper;
using QLTV.UseCases;
using QLTV.UseCases.SreachBookScreen;
using QLTV.CoreBusiness.Services;
using QLTV.CoreBusiness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using QLTV.CoreBusiness.Services.interfaces;
using QLTV.UseCase.BookSheftScreen.interfaces;
using QLTV.UseCases.BookSheftScreen;
using QLTV.UseCases.ShoppingCartScreen;
using QLTV.UseCase.PlugginInterfaces.DataStore;
using QLTV.UseCase.PlugginInterfaces.UI;
using QLTV.BookSheft.LocalStorage;
using QLTV.UseCases.PluginInterfaces.StateStore;
using QLTV.StateStore.DI;
using QLTV.UseCase.SreachBookScreen.interfaces;

var builder = WebApplication.CreateBuilder(args);

// Đọc cấu hình từ tệp appsettings.json
builder.Configuration.AddJsonFile("appsettings.json");

// Đăng ký DbContext để làm việc với cơ sở dữ liệu
builder.Services.AddDbContext<BookDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")),
    ServiceLifetime.Scoped);

// Đăng ký các dịch vụ cần thiết
builder.Services.AddTransient<IDataAccess>(sp =>
    new DataAccess(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IBookRespository, BookRespository>();
builder.Services.AddTransient<IViewBookUseCase, ViewBookUseCase>();
builder.Services.AddScoped<IBookSheft, BookSheft>(); // Đăng ký BookSheft là Scoped service
builder.Services.AddScoped<IBookSheftStateStore, BookSheftStateStore>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBorrowService, BorrowService>();
builder.Services.AddTransient<IDeleteBookUseCase, DeleteBookUseCase>();
builder.Services.AddTransient<IUpdateQuantityUseCase, UpdateQuantityUseCase>();
builder.Services.AddTransient<ISreachBookUseCase, SreachBookUseCase>();
builder.Services.AddTransient<IViewBookSheftUseCase, ViewBookSheftUseCase>();
builder.Services.AddTransient<IBorrowrepository, BorrowRepository>();

// Đăng ký chính sách cho phép truy cập dành riêng cho Admin
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
});

// Đăng ký dịch vụ cho xác thực
builder.Services.AddAuthentication("Library.CookieAuth")
    .AddCookie("Library.CookieAuth", config =>
    {
        config.Cookie.Name = "Library.CookieAuth";
        config.LoginPath = "/authenticate";
    });

// Đăng ký Razor Pages và Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Cấu hình pipeline cho HTTP request
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Map các controller và Blazor hub
app.MapControllers();
app.MapBlazorHub();

// Mặc định fallback đến trang _Host.cshtml trong Razor Pages
app.MapFallbackToPage("/_Host");

app.Run();
