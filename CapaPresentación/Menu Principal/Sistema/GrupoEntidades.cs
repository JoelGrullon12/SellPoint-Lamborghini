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

namespace CapaPresentación.Menu_Principal.Sistema
{
    public partial class GrupoEntidades : Form
    {
        N_GruposEntidades ngent=new N_GruposEntidades();
        private int xClick;
        private int yClick;

        private int id = 0;

        public GrupoEntidades()
        {
            InitializeComponent();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
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

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
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

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string desc = txtComment.Text;
            string comment = txtID.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if (desc == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion", "Debe rellenar todos los campos requeridos");
            }
            else
            {
                ngent.Update(id, desc, comment, status, noElim);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string param = txtSearch.Text;

            if (param == "")
            {
                MessageBox.Show("Por favor digite el id");
                grvGruposEntidades.DataSource = ngent.Listar();
            }
            else
            {
                grvGruposEntidades.DataSource = ngent.Buscar(param);

            }
            
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            string desc = txtComment.Text;
            string comment = txtID.Text;
            string status = cmbStatus.Text;
            bool noElim = chkNoElim.Checked;

            if (desc == "")
            {
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion", "Debe rellenar todos los campos requeridos");
            }
            else
            {
                ngent.Insert(desc, comment, status, noElim);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int res = ngent.Delete(id);
            if (res == 1)
            {
                MessageBox.Show("Registro eliminado con exito\n" + ngent.rows.ToString() + " afectadas", "Registros eliminados");
                LimpiarCampos();
            }
            else if (res == 3)
            {
                MessageBox.Show("Se ha producido un error en la base de datos\n" + ngent.msg, "Error de SLQ detectado");
            }
            else if (res == 4)
            {
                MessageBox.Show("Se ha producido un error inesperado\n" + ngent.msg, "Error inesperado detectado");
            }
        }

        private void LimpiarCampos()
        {
            txtID.Text = "000";
            txtComment.Text = "";
            txtDesc.Text = "";
            cmbStatus.SelectedIndex = 0;

            btnadd.Enabled = true;
            btndelete.Enabled = false;
            btnupdate.Enabled = false;
        }

        private void grvGruposEntidades_CellCongentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(grvGruposEntidades.CurrentRow.Cells[0].ToString());
            txtID.Text = grvGruposEntidades.CurrentRow.Cells[0].ToString();
            txtDesc.Text = grvGruposEntidades.CurrentRow.Cells[1].ToString();
            txtComment.Text = grvGruposEntidades.CurrentRow.Cells[3].ToString();
            cmbStatus.Text = grvGruposEntidades.CurrentRow.Cells[4].ToString();
            chkNoElim.Checked = grvGruposEntidades.CurrentRow.Cells[5].ToString() == "1" ? true : false;

            btnadd.Enabled = false;
            btnupdate.Enabled = true;
            btndelete.Enabled = true;
        }

        private void btnrefrescar_Click(object sender, EventArgs e)
        {
            grvGruposEntidades.DataSource = ngent.Listar();
        }
    }
}
