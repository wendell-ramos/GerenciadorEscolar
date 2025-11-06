using GerenciamentoEscolarAPP.Data;
using GerenciamentoEscolarAPP.Models;
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
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        public Cadastro()
        {
            InitializeComponent();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            using (var context = DbHelper.CriarContexto())
            {
                if (context.Usuarios.Any(u => u.Email == txtEmail.Text))
                {
                    txtMensagem.Text = "Esse email já está cadastrado!";
                    txtMensagem.Foreground = System.Windows.Media.Brushes.Red;
                    return;
                }

                var novoUsuario = new Usuario
                {
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    Senha = txtSenha.Password,
                    Tipo = (cmbTipo.SelectedItem as ComboBoxItem)?.Content.ToString()
                };

                context.Usuarios.Add(novoUsuario);
                context.SaveChanges();

                txtMensagem.Text = "Cadastro realizado com sucesso!";
                txtMensagem.Foreground = System.Windows.Media.Brushes.Green;
            }
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
