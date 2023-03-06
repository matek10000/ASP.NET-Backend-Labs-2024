using ApplicationCore.Interfaces.Repository;
using BackendLab01;
using Infrastructure.Memory;
using Infrastructure.Memory.Repository;

var builder = WebApplication.CreateBuilder(args);
var quizRepo = new MemoryGenericRepository<Quiz, int>();
var itemRepo = new MemoryGenericRepository<QuizItem, int>();
var answerRepo = new MemoryGenericRepository<QuizItemUserAnswer, string>();

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IGenericRepository<Quiz, int>>(provider => quizRepo);
builder.Services.AddSingleton<IGenericRepository<QuizItem, int>>(provider => itemRepo);
builder.Services.AddSingleton<IGenericRepository<QuizItemUserAnswer, string>>(provider => answerRepo);
builder.Services.AddSingleton<IQuizUserService, QuizUserService>();
builder.Services.AddSingleton<IQuizAdminService, QuizAdminService>();

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

app.UseAuthorization();

app.MapRazorPages();
app.Seed();
app.Run();