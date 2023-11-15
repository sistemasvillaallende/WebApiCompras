using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public interface IDetalleRequerimientoService
    {
        public List<DetalleRequerimiento> read();
        public DetalleRequerimiento getByPk(int Id);
        public int insert(DetalleRequerimiento obj);
        public void update(DetalleRequerimiento obj);
        public void delete(DetalleRequerimiento obj);
        public List<DetalleRequerimiento> getByIdRequerimiento(int idRequerimiento);
    }
}

