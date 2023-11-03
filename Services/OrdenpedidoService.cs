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
    public class OrdenpedidoService : IOrdenpedidoService
    {
        public Ordenpedido getByPk(int Id)
        {
            try
            {
                return Ordenpedido.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Ordenpedido> read()
        {
            try
            {
                return Ordenpedido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Ordenpedido obj)
        {
            try
            {
                return Ordenpedido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Ordenpedido obj)
        {
            try
            {
                Ordenpedido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Ordenpedido obj)
        {
            try
            {
                Ordenpedido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

