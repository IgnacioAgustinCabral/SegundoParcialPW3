using Microsoft.AspNetCore.Mvc;
using SegundoParcial.Entities.EF;
using SegundoParcial.Logica.Servicios;

namespace SegundoParcial.Web.Controllers;

public class EmpleadoController : Controller
{
    private readonly IEmpleadoService _empleadoService;
    private readonly ISucursalService _sucursalService;

    public EmpleadoController(IEmpleadoService empleadoService, ISucursalService sucursalService)
    {
        _empleadoService = empleadoService;
        _sucursalService = sucursalService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Sucursales = _sucursalService.GetSucursalesNoEliminadas();
        return View("CreateEmpleado");
    }

    [HttpPost]
    public IActionResult Create(Empleado empleado)
    {
        Console.WriteLine(empleado);
        if (!ModelState.IsValid)
        {
            return RedirectToAction("CreateEmpleado");
        }
        _empleadoService.createEmpleado(empleado);

        return RedirectToAction("Index");
    }
}

