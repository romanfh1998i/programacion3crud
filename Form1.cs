using CapaNegocio;

namespace crudTarea4
{
    public partial class Form1 : Form
    {
        CN_Producto objectoCD= new CN_Producto();
        private string idProducto = null;
        private bool Editar = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void MostrarProducto()
        {
            CN_Producto objecto = new CN_Producto();
            dataGridView1.DataSource=objecto.MostrarProducto();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarProducto();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Editar==false)
            {
                try
                {
                    objectoCD.InsertarProducto(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, txtStock.Text);
                    MessageBox.Show("Se Inserto correctamente");
                    MostrarProducto();
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            if (Editar==true)
            {
                try
                {
                    objectoCD.EditarProducto(txtNombre.Text, txtDescripcion.Text, txtPrecio.Text, txtStock.Text,idProducto);
                    MessageBox.Show("Se Edito correctamente");
                    MostrarProducto();
                    Editar= false;
                    limpiarForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                Editar = true;
                txtNombre.Text = dataGridView1.CurrentRow.Cells["nombre"].Value.ToString();
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells["precio"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["Stock"].Value.ToString();
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Selecione la fila a Editar");
            }
        }
        private void limpiarForm()
        {
            txtDescripcion.Clear();
    
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                idProducto = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
                objectoCD.EliminarProducto(idProducto);
                MessageBox.Show("Se elimino correctamente");
                    MostrarProducto();


            }
            else
            {
                MessageBox.Show("Selecione una fila");
            }
        }
    }
}