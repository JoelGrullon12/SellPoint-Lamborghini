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
            //CargarComboBoxes();
        }

        private void CargarDatos(){
            dataGridView1.DataSource=ntent.Listar();
        }

        private void CargarComboBoxes(){
            string[] grEnt=ntent.CargarGrEntidad();

            for (int i = 0; i < grEnt.Length; i++)
            {
                comboBox1.Items.Add(grEnt[i]);//NOMBRE AQUI
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
            string desc = textBox4.Text;
            int tpEnt = 1;//IMPORTANTE, ESO ES MIENTRAS TANTO, 
            //PONGAN OTRO COMBOBOX PARA EL ID ENTIDAD Y DESPUES PONEN 
            //EL VALOR DEL TEXTO A ESA VARIABLE Y DESCOMENTAN EL CODIGO DE LA LINEA 24
            //DESPUES CAMBIAN EL NOMBRE DEL combobox1 DE LA LINEA 36
            string comment = textBox1.Text;
            string status = comboBox1.Text;
            bool noElim = checkBox1.Checked;

            if(desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                ntent.Insert(desc, tpEnt, comment, status, noElim);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string desc = textBox4.Text;
            int tpEnt = 1;//IMPORTANTE, ESO ES MIENTRAS TANTO, 
            //PONGAN OTRO COMBOBOX PARA EL ID ENTIDAD Y DESPUES PONEN 
            //EL VALOR DEL TEXTO A ESA VARIABLE Y DESCOMENTAN EL CODIGO DE LA LINEA 24
            //DESPUES CAMBIAN EL NOMBRE DEL combobox1 DE LA LINEA 36
            string comment = textBox1.Text;
            string status = comboBox1.Text;
            bool noElim = checkBox1.Checked;

            if(desc==""){
                MessageBox.Show("Todos los campos terminados en asterisco (*) son requeridos\ndebe rellenar al menos los siguientes campos:" +
                    "\nDescripcion","Debe rellenar todos los campos requeridos");
            }else{
                ntent.Update(id, desc, tpEnt, comment, status, noElim);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            int res=ntent.Delete(id);
            if(res==1){
                MessageBox.Show("Registro eliminado con exito\n"+ntent.rows.ToString()+" afectadas", "Registros eliminados");
            }else if(res==3){
                MessageBox.Show("Se ha producido un error en la base de datos\n"+ntent.msg, "Error de SLQ detectado");
            }else if(res==4){
                MessageBox.Show("Se ha producido un error inesperado\n"+ntent.msg, "Error inesperado detectado");
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string param = "";
            //UTEDE TAN BURLAO, Y EL TEXTBOX BUSCAR XDDDDDD, BUENO, CREENLO Y AGREGEN EL TEXTO A ESA VARIABLE

            if (param == "")
            {
                dataGridView1.DataSource = ntent.Listar();
            }
            else
            {
                dataGridView1.DataSource = ntent.Buscar(param);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id=Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].ToString());
            //txtID.Text=dataGridView1.CurrentRow.Cells[0].ToString();
            textBox4.Text=dataGridView1.CurrentRow.Cells[1].ToString();
             //cmbIdTpEnt.Text=dataGridView1.CurrentRow.Cells[2].ToString();
             textBox1.Text=dataGridView1.CurrentRow.Cells[3].ToString();
             comboBox1.Text=dataGridView1.CurrentRow.Cells[4].ToString();
             checkBox1.Checked=dataGridView1.CurrentRow.Cells[5].ToString()=="1"?true:false;

             btnadd.Enabled=false;
             btnupdate.Enabled=true;
             btndelete.Enabled=true;
        }
    }
}
