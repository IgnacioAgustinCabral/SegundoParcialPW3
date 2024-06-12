using Microsoft.EntityFrameworkCore;
using SegundoParcial.Entities.EF;

namespace SegundoParcial.Logica.Servicios;

public class EmpleadoService : IEmpleadoService
{
    private readonly _2doParcialContext _context;

    public EmpleadoService(_2doParcialContext context)
    {
        _context = context;
    }

    public void createEmpleado(Empleado empleado)
    {
        _context.Add(empleado);
        _context.SaveChanges();
    }

    public List<Empleado> getEmpleados()
    {
        return _context.Empleados.Include(e => e.IdSucursalNavigation).ToList();
    }

    public List<Empleado> getEmpleadosPorSucursal(int IdSucursal)
    {
        return _context.Empleados
            .Include(e => e.IdSucursalNavigation)
            .Where(e => e.IdSucursal == IdSucursal)
            .ToList();
    }
}

public interface IEmpleadoService
{
    void createEmpleado(Empleado empleado);
    List<Empleado> getEmpleados();
    List<Empleado> getEmpleadosPorSucursal(int value);
}
