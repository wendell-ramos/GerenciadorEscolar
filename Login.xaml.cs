using GerenciamentoEscolarAPP.Data;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GerenciamentoEscolarAPP.Views
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnEntrar_Click(object sender, RoutedEventArgs e)
        {
            using (var context = DbHelper.CriarContexto())
            {
                var usuario = context.Usuarios
                    .FirstOrDefault(u => u.Email == txtEmail.Text && u.Senha == txtSenha.Password);

                if (usuario != null)
                {
                    if (usuario.Tipo == "Aluno")
                    {
                        var painelAluno = new PainelAluno(usuario);
                        painelAluno.Show();
                        this.Close();
                    }
                    else if (usuario.Tipo == "Professor")
                    {
                        var painelProfessor = new PainelProfessor(usuario);
                        painelProfessor.Show();
                        this.Close();
                    }
                }
                else
                {
                    txtMensagem.Text = "Email ou senha incorretos.";
                }
            }
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Cadastro cadastro = new Cadastro();
            cadastro.Show();
            this.Close();
        }
    }
}
