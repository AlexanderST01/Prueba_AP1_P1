using System.ComponentModel.DataAnnotations;

namespace Prueba_AP1_P1.Models
{
    public class Ingresos
    {
        [Key]
        public int IngresosId { get; set; }
        [Required (ErrorMessage ="El campo fecha es requirido")]
        public DateTime Fecha { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "El campo concepto es requirido")]
        [StringLength(100, ErrorMessage ="El campo concepto no debe pasar de 100 caracteres")]
        public string? Concepto { get; set; }
        [Required(ErrorMessage ="El compo monto es requierido")]
        public decimal Monto { get; set; }
    }
}
