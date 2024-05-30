using ExamenFInalProgra1.Data.Models;
using ExamenFInalProgra1.Data.DataAccess;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ExamenFInalProgra1
{
    public partial class forma1 : Form
    {
        PaisesBD Clscone = new PaisesBD();
        IngresoPaises ingpaises = new IngresoPaises();
        private PaisesBD paisesbase;

        public forma1()
        {
            InitializeComponent();
            paisesbase = new PaisesBD();
        }

        private void btcargar_Click(object sender, EventArgs e)
        {
            // Implementar lógica para cargar datos si es necesario
        }

        private void tbcargar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = paisesbase.LeerCatalogo();
                datagridviewfunda.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btprobar_Click(object sender, EventArgs e)
        {
            try
            {
                if (paisesbase.PruebaConexion())
                {
                    MessageBox.Show("La conexión se ha establecido correctamente");
                }
                else
                {
                    MessageBox.Show("Error: la base de datos no está conectada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al probar la conexión: " + ex.Message);
            }
        }

        private void btInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                ingpaises.Id1 = int.Parse(tbids.Text);
                ingpaises.Pais = tbnombrepais.Text;
                ingpaises.Capital = tbcapitals.Text;
                ingpaises.Continente = tbcontient.Text;
                ingpaises.Poblacion = int.Parse(tbpobla.Text);
                ingpaises.FechaFundacion = DateTime.Now;
                ingpaises.IdiomaOficial = tbidiomaoficial.Text;
                Clscone.Insertar(ingpaises);
                datagridviewfunda.DataSource = paisesbase.LeerCatalogo();
                MessageBox.Show("Insertado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar: " + ex.Message);
            }
        }

        private void btupdate_Click(object sender, EventArgs e)
        {
            try
            {
                ingpaises.Id1 = int.Parse(tbids.Text);
                ingpaises.Pais = tbnombrepais.Text;
                ingpaises.Capital = tbcapitals.Text;
                ingpaises.Continente = tbcontient.Text;
                ingpaises.Poblacion = int.Parse(tbpobla.Text);
                ingpaises.FechaFundacion = DateTime.Now;
                ingpaises.IdiomaOficial = tbidiomaoficial.Text;
                Clscone.Actualizar(ingpaises);
                datagridviewfunda.DataSource = paisesbase.LeerCatalogo();
                MessageBox.Show("Actualizado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message);
            }
        }

        private void btdelete_Click(object sender, EventArgs e)
        {
            try
            {
                ingpaises.Id1 = int.Parse(tbids.Text);
                Clscone.Eliminar(ingpaises);
                datagridviewfunda.DataSource = paisesbase.LeerCatalogo();
                MessageBox.Show("Eliminado con éxito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void BuscarPorId()
        {
            try
            {
                int idPaisBuscar = int.Parse(tbids.Text);
                DataTable paisEncontrado = paisesbase.BuscarPaisPorId(idPaisBuscar);
                if (paisEncontrado.Rows.Count > 0)
                {
                    string nombre = paisEncontrado.Rows[0]["pais"].ToString();
                    string capital = paisEncontrado.Rows[0]["capital"].ToString();
                    string continente = paisEncontrado.Rows[0]["continente"].ToString();
                    int poblacion = int.Parse(paisEncontrado.Rows[0]["poblacion"].ToString());
                    DateTime fechafundacion = Convert.ToDateTime(paisEncontrado.Rows[0]["fecha_fundacion"].ToString());
                    string idiomaOficial = paisEncontrado.Rows[0]["idioma_oficial"].ToString();

                    tbnombrepais.Text = nombre;
                    tbcapitals.Text = capital;
                    tbcontient.Text = continente;
                    tbpobla.Text = poblacion.ToString();
                    dateTimePickerfunda.Value = fechafundacion;
                    tbidiomaoficial.Text = idiomaOficial;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar por ID: " + ex.Message);
            }
        }

        private void btbuscar_Click(object sender, EventArgs e)
        {
            try
            {
                BuscarPorId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }

        private void btlimpiar_Click(object sender, EventArgs e)
        {
            tbids.Clear();
            tbnombrepais.Clear();
            tbcapitals.Clear();
            tbcontient.Clear();
            tbpobla.Clear();
            dateTimePickerfunda.Value = DateTime.Now;
            tbidiomaoficial.Clear();
        }
    }
}
