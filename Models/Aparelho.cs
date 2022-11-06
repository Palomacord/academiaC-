using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace  Academia.Models{
     [Table ("aparelhos")]
    public class Aparelho{
     [Key]
     public int AparelhosId { get; set; }
     public string Nome { get; set; }

     public string Link { get; set; }







}

}