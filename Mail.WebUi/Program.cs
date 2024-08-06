using Mail.BusinessLayer.Abstract;
using Mail.BusinessLayer.Concrete;
using Mail.DataAccessLayer.Abstract;
using Mail.DataAccessLayer.Context;
using Mail.DataAccessLayer.EntityFramework;
using Mail.EntityLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<MailContext>();

builder.Services.AddScoped<IMessageService , MessageManager>();
builder.Services.AddScoped<IMessageDal , EfMessageDal>();

builder.Services.AddScoped<IDraftService, DraftManager>();
builder.Services.AddScoped<IDraftDal , EfDraftDal>();

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<MailContext>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
