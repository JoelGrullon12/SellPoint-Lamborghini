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
        private int id=0;
        public Entidades()
        {
            InitializeComponent();

            //CargarDatos();
            //CargarComboBoxes();
        }

        private void CargarDatos(){
            grvEntidades.DataSource=nent.Listar();
        }

        private void CargarComboBoxes(){
            string[] tpEnt=nent.CargarTpEntidad();
            string[] grEnt=nent.CargarGrEntidad();

            for (int i = 0; i < tpEnt.Length; i++)
            {
                cmbIdTpEnt.Items.Add(tpEnt[i]);
            }

            for (int i = 0; i < grEnt.Length; i++)
            {
                cmbIdTpEnt.Items.Add(grEnt[i]);
            }
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

        private void btnEdit_Click(object sender, EventArgs e)
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
                int intNoElim=noElim? 1 : 0;
                nent.Update(id, desc, dir, local, tpEnttxt, tpDoc, numeroDoc, tel, urlWeb, urlFB, urlIG, urlTW,
                urlTK, grEnt, tpEnt, limCred, usu, pass, rol, comment, status, intNoElim);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int res=nent.Delete(id);
            if(res==1){
                MessageBox.Show("Registro eliminado con exito\n"+nent.rows.ToString()+" afectadas", "Registros eliminados");
            }else if(res==3){
                MessageBox.Show("Se ha producido un error en la base de datos\n"+nent.msg, "Error de SLQ detectado");
            }else if(res==4){
                MessageBox.Show("Se ha producido un error inesperado\n"+nent.msg, "Error inesperado detectado");
            }
        }

        private void grvEntidades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id=Convert.ToInt32(grvEntidades.CurrentRow.Cells[0].ToString());
            txtID.Text=grvEntidades.CurrentRow.Cells[0].ToString();
            txtDesc.Text=grvEntidades.CurrentRow.Cells[1].ToString();
            txtDir.Text=grvEntidades.CurrentRow.Cells[2].ToString();
            txtLocal.Text=grvEntidades.CurrentRow.Cells[3].ToString();
            cmbTpEnt.Text=grvEntidades.CurrentRow.Cells[4].ToString();
            cmbTpDoc.Text=grvEntidades.CurrentRow.Cells[5].ToString();
            numDoc.Value=Convert.ToInt32(grvEntidades.CurrentRow.Cells[6]);
            txtTel.Text=grvEntidades.CurrentRow.Cells[7].ToString();
             txtWeb.Text=grvEntidades.CurrentRow.Cells[8].ToString();
             txtFB.Text=grvEntidades.CurrentRow.Cells[9].ToString();
             txtIG.Text=grvEntidades.CurrentRow.Cells[10].ToString();
             txtTW.Text=grvEntidades.CurrentRow.Cells[11].ToString();
             txtTK.Text=grvEntidades.CurrentRow.Cells[12].ToString();
             cmbIdGrEnt.Text=grvEntidades.CurrentRow.Cells[13].ToString();
             cmbIdTpEnt.Text=grvEntidades.CurrentRow.Cells[14].ToString();
            numCred.Value=Convert.ToInt32(grvEntidades.CurrentRow.Cells[15].ToString());
             txtUser.Text=grvEntidades.CurrentRow.Cells[16].ToString();
             txtPass.Text=grvEntidades.CurrentRow.Cells[17].ToString();
             cmbRol.Text=grvEntidades.CurrentRow.Cells[18].ToString();
             txtComment.Text=grvEntidades.CurrentRow.Cells[19].ToString();
             boxStatus.Text=grvEntidades.CurrentRow.Cells[20].ToString();
             NoEliminable.Checked=grvEntidades.CurrentRow.Cells[21].ToString()=="1"?true:false;

             btnAgregar.Enabled=false;
             btnEdit.Enabled=true;
             btnDelete.Enabled=true;
        }
    }
}
