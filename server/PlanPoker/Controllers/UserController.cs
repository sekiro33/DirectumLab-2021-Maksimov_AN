using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlanPoker.Domain.Services;

namespace PlanPoker.Controllers
{
  /// <summary>
  /// Контроллер пользователей.
  /// </summary>
  [ApiController]
  [Route("api/[controller]/[action]")]
  public class UserController : ControllerBase
  {
    private readonly UserService userService;

    /// <summary>
    /// Конструктор контроллера.
    /// </summary>
    /// <param name="userService">Сервис для работы с пользователями.</param>
    public UserController(UserService userService)
    {
      this.userService = userService;  
    }

    /// <summary>
    /// Вход в систему.
    /// </summary>
    /// <param name="name">Имя пользователя.</param>
    /// <returns>Данные о пользователе.</returns>
    [HttpPost]
    public string SignIn(string name)
    {
      var user = this.userService.Authenticate(name);
      return JsonSerializer.Serialize(user);
    }

    /// <summary>
    /// Выход из системы.
    /// </summary>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    [HttpPost]
    public Task Logout()
    {
      return this.userService.Logout();
    }
  }
}
