using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ApiAuth.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiAuth.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet]
    [Route("anonymous")]
    [AllowAnonymous]
    public string Anonymous() => "Anonymous";

    [HttpGet]
    [Route("autheticated")]
    [Authorize]
    public string Autheticated() => String.Format("Authenticated: {0}", User.Identity.Name);

    [HttpGet]
    [Route("employee")]
    [Authorize(Roles = "employee,manager")]
    public string Employee() => "employee";

    [HttpGet]
    [Route("manager")]
    [Authorize(Roles = "manager")]
    public string Manager() => "manager";
}
