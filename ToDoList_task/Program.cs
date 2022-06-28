using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using ToDoList_task.GraphQL.GraphQLSchema;
using Repositories.IRepositories;
using Repositories.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.Extensions.Configuration;
using ToDoList_task.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string conn = builder.Configuration.GetConnectionString("ConnectionString");
string xmlCateg = builder.Configuration.GetConnectionString("XMLCateg");
string xmlToDo = builder.Configuration.GetConnectionString("XMLToDo");

builder.Services.AddTransient<IToDoRepository>(provider => {
    switch (FlagValue.Values[FlagValue.CurrValue])
    {
        case "SQL":
        default:
           return new SQLToDoRepository(conn);
        case "XML":
            return new XMLToDoRepository(xmlToDo);
    }
});
builder.Services.AddTransient<ICategoryRepository>(provider => {
    switch (FlagValue.Values[FlagValue.CurrValue])
    {
        case "SQL":
        default:
            return new SQLCategoryRepository(conn);
        case "XML":
            return new XMLCategoryRepository(xmlCateg);
            builder.Services.AddTransient<ICategoryRepository, XMLCategoryRepository>(provider => new XMLCategoryRepository(xmlCateg));
    }
});

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AppSchema>();
builder.Services.AddGraphQL()
        .AddSystemTextJson()
        .AddGraphTypes(typeof(AppSchema), ServiceLifetime.Scoped);

builder.Services.AddControllers()
    .AddNewtonsoftJson(o => o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthorization();

app.UseGraphQL<AppSchema>();
app.UseGraphQLPlayground(options: new PlaygroundOptions());

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ToDo}/{action=Index}/{id?}");

app.Run();