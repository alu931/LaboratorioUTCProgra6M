using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IUsuarioService
    {
        Task<UsuarioEntity> Login(UsuarioEntity entity);
        Task<DBEntity> Registrar(UsuarioEntity entity);
    }

    public class UsuarioService : IUsuarioService
    {

        private readonly IDataAccess sql;

        public UsuarioService(IDataAccess _sql)
        {
            sql = _sql;
        }

        public async Task<UsuarioEntity> Login(UsuarioEntity entity)
        {
            try
            {
                var result = await sql.QueryFirstAsync<UsuarioEntity>("Login", new
                {

                    entity.Usuario,
                    entity.Contrasena

                });

                return result;


            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<DBEntity> Registrar(UsuarioEntity entity)
        {
            try
            {
                var result = await sql.ExecuteAsync("UsuarioRegistrar", new
                {

                    entity.Usuario,
                    entity.Nombre,
                    entity.Contrasena

                });

                return result;


            }
            catch (Exception ex)
            {

                throw;
            }


        }
    }
}
