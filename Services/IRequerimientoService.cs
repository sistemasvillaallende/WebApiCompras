using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IRequerimientoService
    {
        public List<Requerimiento> read();
        public Requerimiento getByPk(int Id);
        public int insert(Requerimiento obj);
        public void update(Requerimiento obj);
        public void delete(Requerimiento obj);
    }
}

