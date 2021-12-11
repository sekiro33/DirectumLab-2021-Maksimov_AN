using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using PlanPoker.Domain.Entities;
using PlanPoker.Domain.Repositories;

namespace PlanPoker.Domain.Services
{
  /// <summary>
  /// Сервис для работы с пользователями.
  /// </summary>
  public class UserService
  {
    private readonly IRepository<User> userRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Конструктор сервиса.
    /// </summary>
    /// <param name="userRepository">Репозиторий пользователей.</param>
    /// <param name="httpContextAccessor"></param>
    public UserService(IRepository<User> userRepository, IHttpContextAccessor httpContextAccessor)
    {
      this.httpContextAccessor = httpContextAccessor;
      this.userRepository = userRepository;
    }

    /// <summary>
    /// Аутентификация пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>Пользователь.</returns>
    public User Authenticate(string name)
    {
      var user = this.userRepository.GetAll().Where(user => user.Name.Equals(name, StringComparison.Ordinal)).FirstOrDefault();
      if (user is null)
        user = this.CreateUser(name);
      this.Login(name);
      return user;
    }

    /// <summary>
    /// Вход в систему.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task Login(string name)
    {
      var claim = new Claim(ClaimsIdentity.DefaultNameClaimType, name);
      var identity = new ClaimsIdentity(new[] { claim }, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
      return this.httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }

    /// <summary>
    /// Выход из системы.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task Logout()
    {
      return this.httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }

    /// <summary>
    /// Создать нового пользователя.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>Новый пользователь.</returns>
    private User CreateUser(string name)
    {
      var user = new User(name);
      this.userRepository.Save(user);
      return user;
    }
  }
}
