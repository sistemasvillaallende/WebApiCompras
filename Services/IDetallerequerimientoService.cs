using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IDetallerequerimientoService
    {
        public List<Detallerequerimiento> read();
        public Detallerequerimiento getByPk(int Id);
        public int insert(Detallerequerimiento obj);
        public void update(Detallerequerimiento obj);
        public void delete(Detallerequerimiento obj);
    }
}

