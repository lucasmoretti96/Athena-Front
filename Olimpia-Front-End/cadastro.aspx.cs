using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.Sql;
using System.Configuration;

namespace Olimpia_Front_End
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            {
                if (txtEmail.Text == "" || txtUsuarioCadastro.Text == "" || txtSenhaCadastro.Text == "" ||
                    txtCNPJ.Text == "" || txtRazao.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Por favor preencha os campos necessários')", true);
                }
                else
                {
                    string strConn = ConfigurationManager.ConnectionStrings["MyDB"].ToString();
                    using (SqlConnection conn = new SqlConnection(strConn))
                    {
                        conn.Open();
                        
                        #region Inserindo dados Empresa

                        int idCompany;

                        using (SqlCommand cmd2 = new SqlCommand("INSERT INTO Company(TradingName, CompanyName, CNPJ, Email, PassAdmin, UserAdmin) " +
                                    "OUTPUT INSERTED.idCompany VALUES(@NomeFantasia, @RazaoSocial, @CNPJ, @Email, @SenhaAdmin, @UsuarioAdmin)", conn))
                        {
                           
                            cmd2.Parameters.AddWithValue("@NomeFantasia", txtNomeFantasia.Text);
                            cmd2.Parameters.AddWithValue("@RazaoSocial", txtRazao.Text);
                            cmd2.Parameters.AddWithValue("@CNPJ", txtCNPJ.Text);
                            cmd2.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd2.Parameters.AddWithValue("@SenhaAdmin", txtSenhaCadastro.Text);
                            cmd2.Parameters.AddWithValue("@UsuarioAdmin", txtUsuarioCadastro.Text);
                            
                            

                            idCompany = (int)cmd2.ExecuteScalar();

                            
                        }

                        #endregion

                        #region Inserindo Endereço


                        using (SqlCommand cmd1 = new SqlCommand("INSERT INTO Adress (Street, Number, AdressCompl, Neighborhood, State, City, ZipCode, idCompany)" +
                                        "OUTPUT INSERTED.idAdress VALUES (@Rua, @Numero, @Complemento, @Bairro, @UF, @Cidade, @CEP, @codEmpresa)", conn))
                        {
                           
                            cmd1.Parameters.AddWithValue("@Rua", txtRua.Text);
                            cmd1.Parameters.AddWithValue("@Numero", numEnd.Text);
                            cmd1.Parameters.AddWithValue("@Complemento", txtComplemento.Text);
                            cmd1.Parameters.AddWithValue("@Bairro", txtBairro.Text);
                            cmd1.Parameters.AddWithValue("@UF", txtUF.Text);
                            cmd1.Parameters.AddWithValue("@Cidade", txtCidade.Text);
                            cmd1.Parameters.AddWithValue("@CEP", txtCEP.Text);
                                                
                            cmd1.Parameters.AddWithValue("@codEmpresa", idCompany);

                            cmd1.ExecuteNonQuery();

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Usuario Cadastrado com Sucesso!!')", true);

                            Response.Redirect("login.aspx");
                        }
                        #endregion


                    }

                }
            }
        }
    }
}
