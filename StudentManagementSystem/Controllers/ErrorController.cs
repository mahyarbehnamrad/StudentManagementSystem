using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        if (statusCode == 404)
        {
            ViewBag.ErrorMessage = "The page or record you requested could not be found.";
        }
        else
        {
            ViewBag.ErrorMessage = "An unexpected error occurred.";
        }

        ViewBag.StatusCode = statusCode;

        return View("StatusCode");
    }
}