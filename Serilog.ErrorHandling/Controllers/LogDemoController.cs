using Microsoft.AspNetCore.Mvc;
using SerilogTimings;

namespace Serilog.ErrorHandling.Controllers;

[ApiController]
[Route("[controller]")]
public class LogDemoController : ControllerBase
{
    private readonly ILogger<LogDemoController> logger;

    public LogDemoController(ILogger<LogDemoController> logger)
    {
        this.logger = logger;
    }

    [HttpGet]
    public string Ping()
    {
        logger.LogInformation("Inside of PING");
        return "Pong";
    }

    [HttpGet("customers/{id}")]
    public string CreateCustomer(int id)
    {
        logger.LogInformation($"Creating customer {id}");

        using (Operation.Time("Do some DB Query"))
        {
            Thread.Sleep(500);
        }
        return "something";
    }

    [HttpPost("person")]
    public Person AddPerson([FromBody] Person person)
    {
        logger.LogInformation("Inside of AddPerson()");
        return person;
    }
}

public record Person(int Id, string Name);