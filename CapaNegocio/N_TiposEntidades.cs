using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_TiposEntidades
    {
        D_TiposEntidades dtent = new D_TiposEntidades();
        D_GruposEntidades dgent = new D_GruposEntidades();

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            msg = dtent.msg;
            return dtent.Listar();
        }

        public int Insert(string desc, int idGrEnt, string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;

            msg = dtent.msg;
            return dtent.Insert(desc, idGrEnt, comment, status, intNoElim);
        }

        public int Update(int id, string desc, int idGrEnt, string comment, string status, bool noElim)
        {
            int intNoElim=noElim? 1 : 0;
            msg = dtent.msg;
            return dtent.Update(id, desc, idGrEnt, comment, status, intNoElim);
        }

        public int Delete(int id)
        {
            msg = dtent.msg;
            return dtent.Delete(id);
        }

        public DataTable Buscar(string param)
        {
            msg = dtent.msg;
            return dtent.Buscar(param);
        }

        public string[] CargarGrEntidad(){
            DataTable tbTpEnt= dgent.Listar();
            int o=tbTpEnt.Rows.Count;
            string[] grEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                grEnt[i]=tbTpEnt.Rows[i][0].ToString();
            }

            return grEnt;
        }
    }
}
