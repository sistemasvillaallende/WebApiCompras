using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IOrdencompraService
    {
        public List<Ordencompra> read();
        public Ordencompra getByPk(int Id);
        public int insert(Ordencompra obj);
        public void update(Ordencompra obj);
        public void delete(Ordencompra obj);
    }
}

