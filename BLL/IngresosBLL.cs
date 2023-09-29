using Microsoft.EntityFrameworkCore;
using Prueba_AP1_P1.DAL;
using Prueba_AP1_P1.Models;
using System.Linq.Expressions;

namespace Prueba_AP1_P1.BLL
{
    public class IngresosBLL
    {
        private readonly Context _context;

        public IngresosBLL(Context context)
        {
            _context = context;
        }
        public bool Existe(int ingrsosId)
        {
            return _context.Ingresos.Any(I => I.IngresosId == ingrsosId);
        }
        public bool Insertar(Ingresos ingresos)
        {
            _context.Ingresos.Add(ingresos);
            return _context.SaveChanges() > 0;
        }
        public bool Modificar (Ingresos ingresos)
        {
            _context.Ingresos.Entry(_context.Ingresos.Find(ingresos.IngresosId)!)
            .State = EntityState.Detached;
            _context.Ingresos.Entry(ingresos)
            .State = EntityState.Modified;
            return _context.SaveChanges() > 0;
        }
        public bool Guardar (Ingresos ingresos)
        {
            if (Existe(ingresos.IngresosId))
                return Modificar(ingresos);

            else
                return Insertar(ingresos);         
        }
        public bool Eliminar (Ingresos ingresos)
        {
            _context.Entry(_context.Ingresos.Find(ingresos.IngresosId)!)
            .State = EntityState.Detached;
            _context.Entry(ingresos).State = EntityState.Deleted;
            return _context.SaveChanges() > 0;
        }
        public Ingresos? Buscar(int ingresosId)
        {
            return _context.Ingresos
                .Where(i => i.IngresosId == ingresosId)
                .AsNoTracking()
                .SingleOrDefault();
        }  
        public List<Ingresos> GetList(Expression <Func<Ingresos, bool>> criterio)
        {
            return _context.Ingresos
                .AsNoTracking()
                .Where(criterio)
                .ToList();
        }
    }
}
