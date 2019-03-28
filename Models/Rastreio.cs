using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUsuarios.Models
{
    public class Rastreio
    {
        [Key]
        public int AcessoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Tarefa { get; set; }
    }
}
