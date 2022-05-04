using Microsoft.AspNetCore.Authentication.Negotiate;
using Radzen;
using RegionReports.Services;
using RegionReports.Data;
using RegionReports.Data.Interfaces;
using RegionReports.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
   .AddNegotiate();

builder.Services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according to the default policy.
    options.FallbackPolicy = options.DefaultPolicy;
});

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<RegionReportsContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<IDbAccessor, DbAccessor>();
builder.Services.AddHttpContextAccessor();

//Radzen services
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();


builder.Services.AddTransient<UserService>();
builder.Services.AddTransient<DistrictService>();
builder.Services.AddTransient<ReportRequestService>();
builder.Services.AddTransient<FileService>();
builder.Services.AddScoped<AssignmentService>();

builder.Services.AddTransient<SettingsService>();

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

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
