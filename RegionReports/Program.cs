using Microsoft.AspNetCore.Authentication.Negotiate;
using Radzen;
using RegionReports.Data;
using RegionReports.Data.Interfaces;
using RegionReports.Data.Repositories;
using RegionReports.Services;

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
builder.Services.AddDbContext<RegionReportsContext>(ServiceLifetime.Transient);
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
builder.Services.AddScoped<DocumentMergingService>();

builder.Services.AddTransient<SettingsService>();

builder.Services.AddHostedService<SchedulerService>();

builder.Services.AddSingleton<MailQueueMonitor>();
builder.Services.AddHostedService<QueuedHostedService>();
///Очередь ограничена рамками
builder.Services.AddSingleton<IBackgroundTaskQueue>(ctx =>
{
    if (!int.TryParse(builder.Configuration["QueueCapacity"], out var queueCapacity))
        queueCapacity = 50;
    return new BackgroundTaskQueue(queueCapacity);
});

//Неограниченная очередь
//builder.Services.AddSingleton<IBackgroundTaskQueue, BackgroundTaskQueue>();

builder.Services.AddScoped<MailerService>();

var app = builder.Build();

//Запускаю очередь почтовых почтовых отправлений сразу после старта программы
app.Services.GetService<MailQueueMonitor>()?.StartMonitorLoop();

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