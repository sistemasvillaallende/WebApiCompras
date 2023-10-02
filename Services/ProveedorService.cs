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
    public class ProveedorService : IProveedorService
    {
        public Proveedor getByPk(int Id)
        {
            try
            {
                return Proveedor.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Proveedor> read()
        {
            try
            {
                return Proveedor.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Proveedor obj)
        {
            try
            {
                return Proveedor.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Proveedor obj)
        {
            try
            {
                Proveedor.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Proveedor obj)
        {
            try
            {
                Proveedor.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

