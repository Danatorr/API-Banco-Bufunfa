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
        public double Saldo {  get; private set; }
        [Required]
        public string Titular { get; private set; }
        [Required]
        public char Tipo { get; protected set; } //Só pode ser C (para corrente) e P (para poupança)
    }
}
