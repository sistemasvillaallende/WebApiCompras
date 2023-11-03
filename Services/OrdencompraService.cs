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
    public class OrdencompraService : IOrdencompraService
    {
        public OrdenCompra getByPk(int Id)
        {
            try
            {
                return OrdenCompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<OrdenCompra> read()
        {
            try
            {
                return OrdenCompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(OrdenCompra obj)
        {
            try
            {
                return OrdenCompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(OrdenCompra obj)
        {
            try
            {
                OrdenCompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(OrdenCompra obj)
        {
            try
            {
                OrdenCompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

