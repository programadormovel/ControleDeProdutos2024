using ControleDeProdutos2024.Data;
using ControleDeProdutos2024.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BancoContext>(
    options => options.UseSqlServer(
            builder.Configuration.GetConnectionString("DataBase")
           ));

builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ILoginRepositorio, LoginRepositorio>();

builder.Services.AddRazorPages().AddMvcOptions(options =>
{
    options.MaxModelValidationErrors = 50;
    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(_ => "Este campo é obrigatório!");
});

// Habilita o MemoryCache
builder.Services.AddDistributedMemoryCache();
// Define configurações padrões de sessão
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".ControleDeProdutos2024.Session";
    options.IdleTimeout = TimeSpan.FromSeconds(99999);
    //options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
