using Meth3;
using Newtonsoft.Json;

namespace WebGame.Controllers;
using System.Web.Helpers;
using Microsoft.AspNetCore.Mvc;

public class HomeController
{
    private readonly IWebHostEnvironment _appEnvironment;
    private readonly DataAccessLayer.UnitOfWork _unitOfWork;
    private readonly BLService _service;

    public HomeController(IWebHostEnvironment appEnvironment)
    {
        _appEnvironment = appEnvironment; 
        _unitOfWork = new DataAccessLayer.UnitOfWork();
        _service = new BLService();
    }

    [HttpPost]
    public JsonResult FindSame()
    {
        var result = _service.FindUsersWithSameGames();
        var stringr = JsonConvert.SerializeObject(result);
        return Json.Decode(stringr);
    }
}