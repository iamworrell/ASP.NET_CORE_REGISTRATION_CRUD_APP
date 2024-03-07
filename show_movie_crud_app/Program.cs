using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using show_movie_crud_app.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Add ApplicationDbContext to Services
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    //Connect Application to Database
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

//
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

//Change Login Path
builder.Services.ConfigureApplicationCookie(configure =>
{
    configure.LoginPath = "/Login";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
