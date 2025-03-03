using HomeLib.DataAccess;
using HomeLib.DataAccess.Book;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebAppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WebAppDbContext"))
);

builder.Services.AddScoped<IBookService, BookService>();

// Add services to the container.
var mvcBuilder = builder.Services.AddRazorPages();

if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields =
        HttpLoggingFields.RequestProperties
        | HttpLoggingFields.RequestHeaders
        | HttpLoggingFields.ResponseHeaders
        | HttpLoggingFields.RequestBody
        | HttpLoggingFields.ResponseBody;
    logging.RequestHeaders.Add("Authorization");
    logging.ResponseHeaders.Add("Authorization");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseHttpLogging();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseStatusCodePagesWithReExecute("/Troubles", "?statusCode={0}");
app.MapRazorPages().WithStaticAssets();

app.Run();
