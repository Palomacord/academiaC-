using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace  Academia.Models
{
    [Table ("treinoexercicio")]
    public class TreinoExercicio{
    
   
        [Key]
        public int TreinoExercicioId { get; set; }


        [ForeignKey("TreinoId")]
        public int TreinoId { get; set; }

        public virtual Treino Treino { get; set; }

        [ForeignKey("ExercicoId")]
        public int ExercicioId { get; set; }

        public virtual Exercicio Exercicio { get; set; }

        public Double TempoMax { get; set; }

    }
}