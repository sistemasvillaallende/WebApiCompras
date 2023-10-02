using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCompras.Entities;
namespace WebApiCompras.Services
{
    public interface IInsumosService
    {
        public List<Insumos> read();
        public Insumos getByPk(int Id);
        public int insert(Insumos obj);
        public void update(Insumos obj);
        public void delete(Insumos obj);
    }
}

