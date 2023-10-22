using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eventos.Classes
{
    [Table("tb_local")]
    class Local
    {
        [Key]
        public int IdLocal { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int Capacidade { get; set; }
        public List<Evento> Eventos { get; set; }

    }
}
