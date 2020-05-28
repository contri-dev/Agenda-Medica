using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AgendaMedica;

namespace FichaCriminal
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
			InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

		}

		private void btnRegistrar_Click(object sender, EventArgs e)
        {

			if (txtid.Text == "" || txtNome.Text == "" || txtAltura.Text == "" || txtNascimento.Text == "" || txtDiag.Text == "")
			{
				MessageBox.Show("Preencha todos os Campos");
			}
			else
			{
                decimal n;
                if (decimal.TryParse(txtid.Text, out n) && decimal.TryParse(txtAltura.Text, out n))
                {
                    DateTime MinhaData = DateTime.Parse(txtNascimento.Text);
                    MinhaData.ToString("yyyy-MM-dd");

                    SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = consultorio; Persist Security Info = True; User Id = sa; password = 123456");

                    SqlCommand cmd = con.CreateCommand();
                    con.Open();

                    String instruçao_sql;

                    instruçao_sql = "Insert into ficha values(" + txtid.Text + ", '" + txtNome.Text + "', " + txtAltura.Text + ",'" + txtDiag.Text + "','" + MinhaData + "');";

                    cmd = new SqlCommand(instruçao_sql, con);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Inserido com sucesso!");


					SqlCommand cmd2 = con.CreateCommand();



					instruçao_sql = "select * from ficha";
					cmd2 = new SqlCommand(instruçao_sql, con);

					SqlDataAdapter objadp = new SqlDataAdapter(cmd2);

					DataTable dtLista = new DataTable();

					objadp.Fill(dtLista);

					dgvDados.DataSource = dtLista;

					txtid.Clear();
					txtNome.Clear();
					txtAltura.Clear();
					txtAltura.Clear();
					txtNascimento.Clear();
					txtDiag.Clear();
					txtid.Focus();

				}
                else
                {
                    MessageBox.Show("Os campos CPF e Altura só aceitam números.");
                }
			}
        }

		private void btnDeletar_Click(object sender, EventArgs e)
		{
			if (txtid.Text == "")
			{
				MessageBox.Show("O campo ID esta vazio");
			}
			else
				if (MessageBox.Show("Você deseja delatar os dados do código inserido", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = consultorio; Persist Security Info = True;User Id = sa; password = 123456");

					SqlCommand cmd = con.CreateCommand();
					con.Open();

					String instruçao_sql;

					instruçao_sql = "Delete from ficha where cd_fic =" + txtid.Text;
					cmd = new SqlCommand(instruçao_sql, con);

					cmd.ExecuteNonQuery();
					MessageBox.Show("Dados deletados com sucesso");

					instruçao_sql = "select * from ficha";
					cmd = new SqlCommand(instruçao_sql, con);

					SqlDataAdapter objadp = new SqlDataAdapter(cmd);

					DataTable dtLista = new DataTable();

					objadp.Fill(dtLista);

					dgvDados.DataSource = dtLista;

					dgvDados.RowsDefaultCellStyle.ForeColor = Color.Black;
				txtid.Clear();
				txtNome.Clear();
				txtAltura.Clear();
				txtAltura.Clear();
				txtNascimento.Clear();
				txtDiag.Clear();
				txtid.Focus();
			}
		}

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtid.Clear();
            txtNome.Clear();
            txtAltura.Clear();
            txtAltura.Clear();
            txtNascimento.Clear();
			txtDiag.Clear();
			txtid.Focus();

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
			if (txtid.Text == "" || txtNome.Text == "" || txtAltura.Text == "" || txtNascimento.Text == "" || txtDiag.Text == "")
			{
				MessageBox.Show("Preencha todos os Campos para Atualizar");
			}
			else
			{
				if (MessageBox.Show("Você deseja atualizar os dados referentes a esse ID?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = consultorio; Persist Security Info = True; User Id = sa; password = 123456");

					SqlCommand cmd = con.CreateCommand();
					con.Open();

					String instruçao_sql;


					instruçao_sql = "update ficha set nm_fic = '" + txtNome.Text + "', alt_fic = '" + txtAltura.Text + "', nasc_fic = '" + txtNascimento.Text + "', diag_fic = '" + txtDiag.Text + "'where cd_fic =" + txtid.Text;
					cmd = new SqlCommand(instruçao_sql, con);

					cmd.ExecuteNonQuery();

					instruçao_sql = "select * from ficha";
					cmd = new SqlCommand(instruçao_sql, con);

					SqlDataAdapter objadp = new SqlDataAdapter(cmd);

					DataTable dtLista = new DataTable();

					objadp.Fill(dtLista);

					dgvDados.DataSource = dtLista;

					dgvDados.RowsDefaultCellStyle.ForeColor = Color.Black;
				}
			}
        }

		private void btnListar_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = consultorio; Persist Security Info = True; User Id = sa; password = 123456");

			SqlCommand cmd = con.CreateCommand();
			con.Open();

			String instruçao_sql;

			instruçao_sql = "select * from ficha";
			cmd = new SqlCommand(instruçao_sql, con);

			SqlDataAdapter objadp = new SqlDataAdapter(cmd);

			DataTable dtLista = new DataTable();

			objadp.Fill(dtLista);

			dgvDados.DataSource = dtLista;

			dgvDados.RowsDefaultCellStyle.ForeColor = Color.Black;
			txtid.Clear();
			txtNome.Clear();
			txtAltura.Clear();
			txtAltura.Clear();
			txtNascimento.Clear();
			txtDiag.Clear();
			txtid.Focus();

		}

		private void lblNascimento_Click(object sender, EventArgs e)
        {

        }

        private void lblAltura_Click(object sender, EventArgs e)
        {

        }

        private void lblNome_Click(object sender, EventArgs e)
        {

        }

        private void lblCodigo_Click(object sender, EventArgs e)
        {

        }

        private void lblAgendaMedica_Click(object sender, EventArgs e)
        {

        }

		private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtNascimento.Text);

        }
    }
}
