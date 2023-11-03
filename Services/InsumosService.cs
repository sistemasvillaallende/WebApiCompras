using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using WebApiCompras.Entities;

namespace WebApiCompras.Services
{
    public class InsumosService : IInsumosService
    {
        public Insumos getByPk(int Id)
        {
            try
            {
                return Insumos.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Insumos> read()
        {
            try
            {
                return Insumos.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Insumos obj)
        {
            try
            {
                return Insumos.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Insumos obj)
        {
            try
            {
                Insumos.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Insumos obj)
        {
            try
            {
                Insumos.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

