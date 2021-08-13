using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APIBancoBufunfa.Models
{
    public class Conta
    {   
        [Key]
        [Required]
        public int Id { get; set; }
        public double Saldo {  get; set; }
        [Required]
        public string Titular { get; set; }
        [Required]
        public string Tipo { get; set; } //Só pode ser 1 (para corrente) ou 2 (para poupança)
    }
}
