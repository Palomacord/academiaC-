using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Academia.Models{
 [Table ("aulas_aluno")]
    public class Aula{
    [Key]
     public int AulaId { get; set; }
     
    [ForeignKey("AlunoId")]
     public int AlunoId { get; set; }

      public virtual Aluno Aluno { get; set; }

    [ForeignKey("TreinoId")]
     public int TreinoId { get; set; }

     public virtual Treino Treino { get; set; }


     public DateTime  Data_aula { get; set; }


}

}