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
    /// Lógica interna para PainelProfessor.xaml
    /// </summary>
    public partial class PainelProfessor : Window
    {
        private Usuario _professor;

        public PainelProfessor(Usuario professor)
        {
            InitializeComponent();
            _professor = professor;
            lblNomeProfessor.Content = $"Bem-vindo, Professor {_professor.Nome}";
        }

        private void SalvarNota_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtAlunoId.Text, out int alunoId) || !double.TryParse(txtNota.Text, out double valor))
            {
                lblStatus.Content = "Campos inválidos!";
                lblStatus.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            using (var db = DbHelper.CriarContexto())
            {
                var aluno = db.Usuarios.FirstOrDefault(u => u.Id == alunoId && u.Tipo == "Aluno");

                if (aluno == null)
                {
                    lblStatus.Content = "Aluno não encontrado!";
                    lblStatus.Foreground = System.Windows.Media.Brushes.Red;
                    return;
                }

                var nota = new Nota
                {
                    AlunoId = aluno.Id,
                    Materia = txtMateria.Text,
                    Valor = valor
                };

                db.Notas.Add(nota);
                db.SaveChanges();

                lblStatus.Content = "Nota salva com sucesso!";
                lblStatus.Foreground = System.Windows.Media.Brushes.Green;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Cria uma nova instância da tela de login
            Login login = new Login();

            // Mostra a tela de login
            login.Show();

            // Fecha a tela atual (principal)
            this.Close();
        }
    }
}
