using Microsoft.AspNetCore.Mvc;
namespace balance.Controllers;

[ApiController]
[Route("api/[controller]")]
public class dbController : ControllerBase
{
    BalanceContext db;

    public dbController(BalanceContext dataBase)
    {
        db = dataBase;
    }

    [HttpGet]
    public IActionResult dbCreated()
    {
        db.Database.EnsureCreated();
        return Ok();
    }



}