using Microsoft.AspNetCore.Mvc;

namespace LifetimeDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LifetimeController(
    TransientService transient1,
    TransientService transient2,
    ScopedService scoped1,
    ScopedService scoped2,
    SingletonService singleton1,
    SingletonService singleton2) : ControllerBase
{
    [HttpGet]
    public object Get()
    {
        return new
        {
            Transient1 = transient1.Id,
            Transient2 = transient2.Id,
            Scoped1 = scoped1.Id,
            Scoped2 = scoped2.Id,
            Singleton1 = singleton1.Id,
            Singleton2 = singleton2.Id
        };
    }
}
