using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Academia.Models{
     [Table ("treinos")]


    public class Treino{
     [Key]
     public int TreinoId { get; set; }

    
     public int ExercicioId { get; set; }
      [ForeignKey("ExercicioId")]

     public virtual Exercicio Exercicio { get; set; }

    [Required]
     public string Descricao { get; set; }
       


}

}