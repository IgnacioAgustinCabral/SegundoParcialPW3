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

    public IActionResult Index(int? IdSucursal)
    {
        ViewBag.Sucursales = _sucursalService.GetSucursalesNoEliminadas();
        ViewBag.IdSucursalSeleccionada = IdSucursal;
        if (IdSucursal.HasValue)
        {
            var empleadosPorSucursal = _empleadoService.getEmpleadosPorSucursal(IdSucursal.Value);
            return View(empleadosPorSucursal);
        } else
        {
            var empleados = _empleadoService.getEmpleados();
            return View(empleados);
        }
        
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
        Console.WriteLine(empleado.IdSucursal);
        ViewBag.Sucursales = _sucursalService.GetSucursalesNoEliminadas();

        if (!ModelState.IsValid)
        {
            return RedirectToAction("Create");
        }
        _empleadoService.createEmpleado(empleado);

        return RedirectToAction("Index");
    }
}

