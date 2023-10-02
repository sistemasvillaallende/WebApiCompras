using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IProveedorService
    {
        public List<Proveedor> read();
        public Proveedor getByPk(int Id);
        public int insert(Proveedor obj);
        public void update(Proveedor obj);
        public void delete(Proveedor obj);
    }
}

