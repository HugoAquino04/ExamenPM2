using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SI.Models;
using SQLite;

namespace SI.Controllers
{
    public class EmpleadosControllers
    {
        readonly SQLiteAsyncConnection _connection;


        // Constructor
        public EmpleadosControllers()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create |
                SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, "BDEMPLEADOS.db3"), extensiones);

            _connection.CreateTableAsync<Empleados>();
        }

        // CRUD - DML

        // CREATE  - UPDATE
        public async Task<int> GuardarEmpleado(Models.Empleados empleados)
        {
            if (empleados.Id == 0)
            {
                return await _connection.InsertAsync(empleados);
            }
            else
            {
                return await _connection.UpdateAsync(empleados);
            }
        }
        // GET
        public async Task<List<Models.Empleados>> GetListaempleados()
        {
            return await _connection.Table<Models.Empleados>().ToListAsync();
        }
            //GET
        public async Task<Models.Empleados> GetEmpleados(int pid)
        {
            return await _connection.Table<Models.Empleados>().Where(i => i.Id == pid).FirstOrDefaultAsync();
        }
        //DELETE
        public async Task<int> EliminarEmpleados(Models.Empleados empleados)
        {
            return await _connection.DeleteAsync(empleados);
        }
    }
}          