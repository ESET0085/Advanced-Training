using College_App.Model.Mylogger;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;



namespace College_App.Controllers { 

[Route("api/[controller]")]
[ApiController]

    public class logme : ControllerBase
    {
    private readonly IMylogger _mylogger;


    public logme(IMylogger mylogger)
    {
        _mylogger = mylogger;
    }


    [HttpGet]
    public ActionResult index()
    {
        _mylogger.Log("index method started");


        return Ok();
    }

    }

}



