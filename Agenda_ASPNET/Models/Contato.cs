using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_ASPNET.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Display(Description = "Id")]
        [Column("Id_Usuario")]
        public int Id
        {
            get; set;
        }

        [Display(Description = "Nome do Usuário")]
        [Column("Nome")]
        public string Nome
        {
            get; set;
        }

        [Display(Description = "Email")]
        [Column("Email")]
        public string Email
        {
            get; set;
        }

        [Display(Description = "Telefone")]
        [Column("Telefone")]
        public string Telefone
        {
            get; set;
        }
    }
}
