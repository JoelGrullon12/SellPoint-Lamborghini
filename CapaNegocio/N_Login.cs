using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class N_Login
    {
        static D_Login lg = new D_Login();
        //DataTable dt;
        public static string msg;
        public static string err;

        public static int Login(string user, string pass)
        {
            int acc = lg.Log(user, pass);

            switch (acc)
            {
                case 1:
                    return 1;

                case 0:
                    return 0;

                case 3:
                    err = "Error al conectarse a la Base de Datos";
                    msg = lg.errMsg;
                    return 3;

                case 4:
                    err = "Error inesperado de la aplicacion";
                    msg = lg.errMsg;
                    return 4;

                default:
                    return 45;
            }
        }
    }
}
