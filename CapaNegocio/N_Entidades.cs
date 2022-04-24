using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;

namespace CapaNegocio
{
    public class N_Entidades
    {
        D_Entidades dent = new D_Entidades();

        public string msg;
        public int rows = 0;

        public DataTable Listar()
        {
            msg = dent.msg;
            return dent.Listar();
        }

        public int Insert(string desc, string direccion, string local, string typeEnt,
            string typeDoc, int numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
            string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
            string comment, string status, bool noElim)
        {
            int intNoElim = noElim ? 1 : 0;

            msg = dent.msg;
            return dent.Insert(desc, direccion, local, typeEnt, typeDoc, numDoc, tel, urlPag, urlFB,
                urlIG, urlTW, urlTK, idGrEnt, idTypeEnt, limCr, user, pass, rol, comment, status, intNoElim);
        }

        public int Update(int id, string desc, string direccion, string local, string typeEnt,
           string typeDoc, int numDoc, string tel, string urlPag, string urlFB, string urlIG, string urlTW,
           string urlTK, int idGrEnt, int idTypeEnt, float limCr, string user, string pass, string rol,
           string comment, string status, int noElim)
        {
            msg = dent.msg;
            return dent.Update(id, desc, direccion, local, typeEnt,
            typeDoc, numDoc, tel, urlPag, urlFB, urlIG, urlTW,
            urlTK, idGrEnt, idTypeEnt, limCr, user, pass, rol,
            comment, status, noElim);
        }

        public int Delete(int id)
        {
            msg = dent.msg;
            return dent.Delete(id);
        }

        public DataTable Buscar(string param)
        {
            msg = dent.msg;
            return dent.Buscar(param);
        }

        public string[] CargarTpEntidad(){
            DataTable tbEnt=dent.Listar();
            int o=tbEnt.Rows.Count;
            string[] tpEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                tpEnt[i]=tbEnt.Rows[i][14];
            }

            return tpEnt;
        }

        public string[] CargarGrEntidad(){
            DataTable tbEnt=dent.Listar();
            int o=tbEnt.Rows.Count;
            string[] grEnt=new string[o];

            for (int i = 0; i < o; i++)
            {
                grEnt[i]=tbEnt.Rows[i][13];
            }

            return grEnt;
        }
    }
}
