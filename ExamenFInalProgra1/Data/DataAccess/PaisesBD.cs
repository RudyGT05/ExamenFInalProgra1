using System;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;
using ExamenFInalProgra1.Data.Models;
using System.Data.SqlClient;
using static ExamenFInalProgra1.Data.Models.IngresoPaises;

namespace ExamenFInalProgra1.Data.DataAccess
{
    internal class PaisesBD
    {
        private string connectionString = "Server=Localhost;Database=db_universida;Uid=root;Pwd=rudygt2024";

        public bool PruebaConexion()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public void Insertar(IngresoPaises ingpaises)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "INSERT INTO paises (id, pais, capital, continente, poblacion, fecha_fundacion, idioma_oficial) VALUES (@Id, @Pais, @Capital, @Continente, @Poblacion, @FechaFundacion, @IdiomaOficial)";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", ingpaises.Id1);
                    cmd.Parameters.AddWithValue("@Pais", ingpaises.Pais);
                    cmd.Parameters.AddWithValue("@Capital", ingpaises.Capital);
                    cmd.Parameters.AddWithValue("@Continente", ingpaises.Continente);
                    cmd.Parameters.AddWithValue("@Poblacion", ingpaises.Poblacion);
                    cmd.Parameters.AddWithValue("@FechaFundacion", ingpaises.FechaFundacion);
                    cmd.Parameters.AddWithValue("@IdiomaOficial", ingpaises.IdiomaOficial);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al agregar el registro: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public void Actualizar(IngresoPaises ingpaises)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "UPDATE paises SET pais = @Pais, capital = @Capital, continente = @Continente, poblacion = @Poblacion, fecha_fundacion = @FechaFundacion, idioma_oficial = @IdiomaOficial WHERE id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", ingpaises.Id1);
                    cmd.Parameters.AddWithValue("@Pais", ingpaises.Pais);
                    cmd.Parameters.AddWithValue("@Capital", ingpaises.Capital);
                    cmd.Parameters.AddWithValue("@Continente", ingpaises.Continente);
                    cmd.Parameters.AddWithValue("@Poblacion", ingpaises.Poblacion);
                    cmd.Parameters.AddWithValue("@FechaFundacion", ingpaises.FechaFundacion);
                    cmd.Parameters.AddWithValue("@IdiomaOficial", ingpaises.IdiomaOficial);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el registro: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataTable LeerCatalogo()
        {
            DataTable paisesCatalogo = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM paises";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(paisesCatalogo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer el catálogo: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return paisesCatalogo;
        }

        public void Eliminar(IngresoPaises ingpaises)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string query = "DELETE FROM paises WHERE id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Id", ingpaises.Id1);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public DataTable BuscarPaisPorId(int id)
        {
            DataTable paisesbase = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM paises WHERE id = @id";
                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@id", id);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            adapter.Fill(paisesbase);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar el país por ID: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return paisesbase; 
        }
    }
}
