using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace Proyecto_FinalP2.Menu_Principal
{
    public partial class Entidades : Form
    {
        N_Entidades nent = new N_Entidades();

        private int xClick;
        private int yClick;
        public Entidades()
        {
            InitializeComponent();
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Cerrar_MouseHover(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Red;
        }

        private void Cerrar_MouseLeave(object sender, EventArgs e)
        {
            Cerrar.BackColor = Color.Transparent;
        }

        private void Minimizar_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.FromArgb(60, Color.White);
            Minimizar.BackColor = color;
        }

        private void Minimizar_MouseLeave(object sender, EventArgs e)
        {
           Minimizar.BackColor = Color.Transparent;
        }

        private void panelPrincipal_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            { xClick = e.X; yClick = e.Y; }
            else
            { this.Left = this.Left + (e.X - xClick); this.Top = this.Top + (e.Y - yClick); }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string desc = txtDesc.Text;
            string dir = txtDir.Text;
            string local = txtLocal.Text;
            string tpEnttxt = cmbTpEnt.Text;
            string tpDoc = cmbTpDoc.Text;
            int numeroDoc = (int)numDoc.Value;
            string tel = txtTel.Text;
            string urlWeb = txtWeb.Text;
            string urlFB = txtFB.Text;
            string urlIG = txtIG.Text;
            string urlTW = txtTW.Text;
            string urlTK = txtTK.Text;
            int grEnt = Convert.ToInt32(cmbIdGrEnt.Text);
            int tpEnt = Convert.ToInt32(cmbIdTpEnt.Text);
            int limCred = (int)numCred.Value;
            string usu = txtUser.Text;
            string pass = txtPass.Text;
            string rol = cmbRol.Text;
            string comment = txtComment.Text;
            string status = boxStatus.Text;
            bool noElim = NoEliminable.Checked;

            if (desc == "" || dir == "" || local == "" || numeroDoc == 0
                || tel == "" || usu == "" || pass == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion\nDireccion\nLocalidad\nNumero de Documento\nTelefonos\nUsuario\nContraseña",
                    "Debe rellenar todos los campos requeridos");
            }
            else
            {
                nent.Insert(desc, dir, local, tpEnttxt, tpDoc, numeroDoc, tel, urlWeb, urlFB, urlIG, urlTW,
                urlTK, grEnt, tpEnt, limCred, usu, pass, rol, comment, status, noElim);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string param = txtBuscar.Text;

            if (param == "")
            {
                grvEntidades.DataSource = nent.Listar();
            }
            else
            {
                grvEntidades.DataSource = nent.Buscar(param);
            }
        }

        private void grvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //txtDesc.Text=grvEntidades.CurrentRow.Cells[1];
            //string dir = txtDir.Text;
            //string local = txtLocal.Text;
            //string tpEnttxt = cmbTpEnt.Text;
            //string tpDoc = cmbTpDoc.Text;
            //int numeroDoc = (int)numDoc.Value;
            //string tel = txtTel.Text;
            //string urlWeb = txtWeb.Text;
            //string urlFB = txtFB.Text;
            //string urlIG = txtIG.Text;
            //string urlTW = txtTW.Text;
            //string urlTK = txtTK.Text;
            //string grEnt = cmbIdGrEnt.Text;
            //string tpEnt = cmbIdTpEnt.Text;
            //int limCred = (int)numCred.Value;
            //string usu = txtUser.Text;
            //string pass = txtPass.Text;
            //string rol = cmbRol.Text;
            //string comment = txtComment.Text;
            //string status = boxStatus.Text;
            //bool noElim = NoEliminable.Checked;
        }
    }
}
