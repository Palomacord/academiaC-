using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Academia.Models{
     [Table ("exercicios")]
    public class Exercicio{
     [Key]
     public int ExercicioId { get; set; }
     public string Descricao { get; set; }

     public int QdtSerie { get; set; }

     public int QdtRepeticoes { get; set; }

     public Double Tempo { get; set; }
     
       public int AparelhoId { get; set; }
     [ForeignKey("AparelhoId")]

     public virtual Aparelho Aparelho { get; set; }
}

}