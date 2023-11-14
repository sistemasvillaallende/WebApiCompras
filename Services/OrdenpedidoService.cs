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
        public Ordenpedido getByPk(int id)
        {
            try
            {
                return Ordenpedido.getByPk(id);
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

        public Ordenpedido getByRequerimiento(int idRequerimiento)
        {
            try
            {
                return Ordenpedido.getByRequerimiento(idRequerimiento);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenpedido> getByDireccion(int idDireccion)
        {
            try
            {
                return Ordenpedido.getByDireccion(idDireccion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenpedido> getBySecretaria(int idSecretaria)
        {
            try
            {
                return Ordenpedido.getBySecretaria(idSecretaria);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenpedido> getByOficina(int idOficina)
        {
            try
            {
                return Ordenpedido.getByOficina(idOficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Ordenpedido> getByUsuario(int idUsuario)
        {
            try
            {
                return Ordenpedido.getByUsuario(idUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

