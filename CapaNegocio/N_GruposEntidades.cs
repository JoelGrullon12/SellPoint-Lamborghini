using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_GruposEntidades
    {
        D_GruposEntidades dgent = new D_GruposEntidades();

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            msg = dgent.msg;
            return dgent.Listar();
        }

        public int Insert(string desc, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;

            msg = dgent.msg;
            return dgent.Insert(desc, comment, status, intNoElim);
        }

        public int Update(int id, string desc, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;
            msg = dgent.msg;
            return dgent.Update(id, desc, comment, status, intNoElim);
        }

        public int Delete(int id)
        {
            msg = dgent.msg;
            return dgent.Delete(id);
        }

        public DataTable Buscar(string param)
        {
            msg = dgent.msg;
            return dgent.Buscar(param);
        }
    }
}
