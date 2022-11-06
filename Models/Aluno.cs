using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Academia.Models{
 [Table ("alunos")]
    public class Aluno{
    [Key]
     public int AlunoId { get; set; }
     public string Nome { get; set; }

     public int Idade { get; set; }

     public Double Peso { get; set; }







}

}