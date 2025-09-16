using Microsoft.AspNetCore.Mvc;

namespace LifetimeDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LifetimeController : ControllerBase
{
    private readonly TransientService _transient1;
    private readonly TransientService _transient2;
    private readonly ScopedService _scoped1;
    private readonly ScopedService _scoped2;
    private readonly SingletonService _singleton1;
    private readonly SingletonService _singleton2;

    public LifetimeController(
        TransientService transient1,
        TransientService transient2,
        ScopedService scoped1,
        ScopedService scoped2,
        SingletonService singleton1,
        SingletonService singleton2)
    {
        _transient1 = transient1;
        _transient2 = transient2;
        _scoped1 = scoped1;
        _scoped2 = scoped2;
        _singleton1 = singleton1;
        _singleton2 = singleton2;
    }

    [HttpGet]
    public object Get()
    {
        return new
        {
            Transient = new[] { _transient1.Id, _transient2.Id },
            Scoped = new[] { _scoped1.Id, _scoped2.Id },
            Singleton = new[] { _singleton1.Id, _singleton2.Id }
        };
    }
}
