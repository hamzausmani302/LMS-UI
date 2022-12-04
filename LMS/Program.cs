using LMS.Services.Announcements;
using LMS.Services.ClassesService;
using LMS.Services.AssignmentsService;
using LMS.Services.Login;
using System.Text.Json.Serialization;
using System.Reflection.PortableExecutable;
using LMS.Authorization;
using LMS.Services.Courses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ILoginService, LoginService>();


builder.Services.AddSingleton<IClassService, ClassService>();
builder.Services.AddSingleton<IAnnouncementService, AnnouncementService>();
builder.Services.AddSingleton<IAssignmentService, AssignmentService>();
builder.Services.AddSingleton<ICourseService, CourseService>();
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

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
app.UseAuthorization();


app.UseMiddleware<JWTMiddleWare>();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");





app.Run();
