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
    public class SurtidoService : ISurtidoService
    {
        public Surtido getByPk(int Id)
        {
            try
            {
                return Surtido.getByPk(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Surtido> read()
        {
            try
            {
                return Surtido.read();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insert(Surtido obj)
        {
            try
            {
                return Surtido.insert(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void update(Surtido obj)
        {
            try
            {
                Surtido.update(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void delete(Surtido obj)
        {
            try
            {
                Surtido.delete(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

