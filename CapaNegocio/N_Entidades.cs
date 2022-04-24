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
    }
}
