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
    /// Lógica interna para LancarNota.xaml
    /// </summary>
    public partial class LancarNota : Window
    {
        private readonly Usuario _professor;

        public LancarNota(Usuario professor)
        {
            InitializeComponent();
            _professor = professor;
            CarregarAlunos();
        }

        private void CarregarAlunos()
        {
            using (var context = DbHelper.CriarContexto ())
            {
                var alunos = context.Usuarios
                    .Where(u => u.Tipo == "Aluno")
                    .Select(u => new { u.Id, u.Nome })
                    .ToList();

                cmbAluno.ItemsSource = alunos;
                cmbAluno.DisplayMemberPath = "Nome";
                cmbAluno.SelectedValuePath = "Id";
            }
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAluno.SelectedValue == null || string.IsNullOrWhiteSpace(txtDisciplina.Text) || string.IsNullOrWhiteSpace(txtNota.Text))
            {
                txtMensagem.Text = "Preencha todos os campos!";
                txtMensagem.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            if (!double.TryParse(txtNota.Text, out double valorNota))
            {
                txtMensagem.Text = "Nota inválida!";
                txtMensagem.Foreground = System.Windows.Media.Brushes.Red;
                return;
            }

            using (var context = DbHelper.CriarContexto())
            {
                var novaNota = new Nota
                {
                    AlunoId = (int)cmbAluno.SelectedValue,
                    Materia = txtDisciplina.Text,
                    Valor = valorNota,
                    
                };

                context.Notas.Add(novaNota);
                context.SaveChanges();

                txtMensagem.Text = "Nota lançada com sucesso!";
                txtMensagem.Foreground = System.Windows.Media.Brushes.Green;

                txtDisciplina.Clear();
                txtNota.Clear();
                cmbAluno.SelectedIndex = -1;
            }
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            var painel = new PainelProfessor(_professor);
            painel.Show();
            this.Close();
        }
    }
}
