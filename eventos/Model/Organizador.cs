using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Classes
{
    [Table("tb_organizador")]
    class Organizador
    {
        [Key]
        public int IdOrganizador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Evento> EventosOrganizados { get; set; }

        
    }
}
