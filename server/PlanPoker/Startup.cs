using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;
using PlanPoker.Domain.Services;
using PlanPoker.Infrastructure.Repositories;

namespace PlanPoker
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
      var mvcBuilder = services.AddControllers();

      mvcBuilder.Services.Configure((MvcOptions options) =>
      {
        options.Filters.Add<ExceptionFilter>();
      });

      services
        .AddSingleton<IRepository<Discussion>, DiscussionRepository>()
        .AddTransient<DiscussionService>()
        .AddSingleton<IRepository<User>, UserRepository>()
        .AddTransient<UserService>()
        .AddSingleton<IRepository<Room>, RoomRepository>()
        .AddTransient<RoomService>()
        .AddSingleton<IRepository<Card>, CardRepository>()
        .AddSingleton<IRepository<CardDeck>, CardDeckRepository>()
        .AddTransient<CardDeckService>()
        .AddSwaggerGen();

      services
        .AddHttpContextAccessor()
        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(options => options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/api/Login"));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwaggerUI(x =>
        {
          x.SwaggerEndpoint("/swagger/v1/swagger.json", "PlanPoker");
          x.RoutePrefix = "swagger";
        });
      }

      app.UseSwagger();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
