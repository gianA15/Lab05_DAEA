using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Data Source=LAB1504-30\\SQLEXPRESS;Initial Catalog=Neptuno3;User ID=garce;Password=123";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("usp_InsertarProductos", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", int.Parse(txtProducto.Text));
                    cmd.Parameters.AddWithValue("@nombreProducto", txtNombreProducto.Text);
                    cmd.Parameters.AddWithValue("@idProveedor", txtIdProveedor.Text);
                    cmd.Parameters.AddWithValue("@cantidadPorUnidad", txtCantidadPorUnidad.Text);
                    cmd.Parameters.AddWithValue("@precioUnidad", txtPrecioUnidad.Text);
                    cmd.Parameters.AddWithValue("@unidadesEnExistencia", txtUnidadesEnExistencia.Text);
                    cmd.Parameters.AddWithValue("@unidadesEnPedido", txtUnidadesEnPedido.Text);
                    cmd.Parameters.AddWithValue("@nivelNuevoPedido", txtNivelNuevoPedido.Text);
                    cmd.Parameters.AddWithValue("@categoriaProducto", txtCategoriaProducto.Text);
                    
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Producto ingresado correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ingresar el producto: " + ex.Message);
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
           
                MainWindow mainWindow2 = new MainWindow();
                mainWindow2.Show();
                this.Close();
           

        }
    }
}
