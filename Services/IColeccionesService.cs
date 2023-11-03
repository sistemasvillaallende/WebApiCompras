using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IColeccionesService
    {
        public List<Colecciones> read();
        public Colecciones getByPk(int Id);
        public int insert(Colecciones obj);
        public void update(Colecciones obj);
        public void delete(Colecciones obj);
    }
}

