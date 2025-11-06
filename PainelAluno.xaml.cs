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
    /// Lógica interna para PainelAluno.xaml
    /// </summary>
    public partial class PainelAluno : Window
    {
        private readonly Usuario alunoLogado;

        public PainelAluno(Usuario aluno)
        {
            InitializeComponent();
            alunoLogado = aluno;
            lblNomeAluno.Text = $"Bem-vindo(a), {aluno.Nome}!";
            CarregarNotas();
        }

        private void CarregarNotas()
        {
            try
            {
                using (var context = DbHelper.CriarContexto())
                {
                    var notas = context.Notas
                        .Where(n => n.AlunoId == alunoLogado.Id)
                        .Select(n => new
                        {
                            Disciplina = n.Materia,   
                            Nota = n.Valor,           
                            Professor = "Professor Padrão" 
                        })
                        .ToList();

                    dgNotas.ItemsSource = notas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar notas: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            this.Close();
        }
    }
}
