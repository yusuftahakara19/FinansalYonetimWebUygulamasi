using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<BusinessLayer.Services.ExchangeRateService>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FinanceDbContext>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserDal, EfUserDal>();
builder.Services.AddScoped<IAccountService, AccountManager>();
builder.Services.AddScoped<IAccountDal, EfAccountDal>();
builder.Services.AddScoped<ITransactionService, TransactionManager>(); 
builder.Services.AddScoped<ITransactionDal, EfTransactionDal>(); 
builder.Services.AddScoped<ITransferService, TransferManager>(); 
builder.Services.AddScoped<ITransferDal, EfTransferDal>(); 


builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Set the default culture for the application
var defaultCulture = new CultureInfo("tr-TR");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
