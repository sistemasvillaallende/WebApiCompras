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
        public Ordencompra getByPk(int Id)
        {
            try
            {
                return Ordencompra.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ordencompra> read()
        {
            try
            {
                return Ordencompra.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ordencompra obj)
        {
            try
            {
                return Ordencompra.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ordencompra obj)
        {
            try
            {
                Ordencompra.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ordencompra obj)
        {
            try
            {
                Ordencompra.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

