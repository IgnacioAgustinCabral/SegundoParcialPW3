using SegundoParcial.Entities.EF;

namespace SegundoParcial.Logica.Servicios;

public class SucursalService : ISucursalService
{
    private readonly _2doParcialContext _context;

    public SucursalService(_2doParcialContext context)
    {
        _context = context;
    }

    public List<Sucursal> GetSucursalesNoEliminadas()
    {
        return _context.Sucursals
            .Where(s => !s.Eliminada)
            .OrderBy(s => s.Direccion)
            .ToList();
    }
}

public interface ISucursalService
{
    List<Sucursal> GetSucursalesNoEliminadas();
}