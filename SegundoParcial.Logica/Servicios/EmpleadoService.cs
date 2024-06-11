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
}

public interface IEmpleadoService
{
    void createEmpleado(Empleado empleado);
}
