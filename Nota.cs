using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEscolarAPP.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public string? Materia { get; set; }
        public double Valor { get; set; }
        
        

        // Relacionamento
        public Usuario? Aluno { get; set; }
    }
}