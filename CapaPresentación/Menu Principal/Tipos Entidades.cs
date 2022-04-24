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
    public partial class Tipos_Entidades : Form
    {
        N_TiposEntidades ntent=new N_TiposEntidades();
        private int xClick;
        private int yClick;

        private int id=0;
        public Tipos_Entidades()
        {
            InitializeComponent();

            CargarDatos();
            CargarComboBoxes();
        }

        private void CargarDatos(){
            grvGruposEntidades.DataSource=ntent.Listar();
        }

        private void CargarComboBoxes(){
            string[] grEnt=ntent.CargarGrEntidad();

            for (int i = 0; i < grEnt.Length; i++)
            {
                cmbGrEnt.Items.Add(grEnt[i]);
            }
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

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string desc = txtComment.Text;
            int grEnt = Convert.ToInt32(cmbGrEnt.Text);
            string comment = txtID.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if(desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                ntent.Insert(desc, grEnt, comment, status, noElim);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string desc = txtComment.Text;
            int grEnt = Convert.ToInt32(cmbGrEnt.Text);
            string comment = txtID.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if(desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                ntent.Update(id, desc, grEnt, comment, status, noElim);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int res=ntent.Delete(id);
            if(res==1){
                MessageBox.Show("Registro eliminado con exito\n"+ntent.rows.ToString()+" afectadas", "Registros eliminados");
                LimpiarCampos();
            }else if(res==3){
                MessageBox.Show("Se ha producido un error en la base de datos\n"+ntent.msg, "Error de SLQ detectado");
            }else if(res==4){
                MessageBox.Show("Se ha producido un error inesperado\n"+ntent.msg, "Error inesperado detectado");
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "000";
            txtComment.Text = "";
            txtDesc.Text = "";
            cmbGrEnt.SelectedIndex = 0;
            cmbGrEnt.SelectedIndex = 0;

            btnadd.Enabled = true;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string param = txtSearch.Text;

            if (param == "")
            {
                grvGruposEntidades.DataSource = ntent.Listar();
            }
            else
            {
                grvGruposEntidades.DataSource = ntent.Buscar(param);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id=Convert.ToInt32(grvGruposEntidades.CurrentRow.Cells[0].ToString());
            txtID.Text=grvGruposEntidades.CurrentRow.Cells[0].ToString();
            txtComment.Text=grvGruposEntidades.CurrentRow.Cells[1].ToString();
            cmbGrEnt.Text=grvGruposEntidades.CurrentRow.Cells[2].ToString();
            txtID.Text=grvGruposEntidades.CurrentRow.Cells[3].ToString();
            cmbStatus.Text=grvGruposEntidades.CurrentRow.Cells[4].ToString();
            chkNoElim.Checked = grvGruposEntidades.CurrentRow.Cells[5].ToString() == "1" ? true : false;

             btnadd.Enabled=false;
             btnupdate.Enabled=true;
             btndelete.Enabled=true;
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            grvGruposEntidades.DataSource = ntent.Listar();
        }
    }
}
