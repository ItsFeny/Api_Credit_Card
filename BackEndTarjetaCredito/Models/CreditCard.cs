using System.ComponentModel.DataAnnotations;

namespace BackEndTarjetaCredito.Models
{
    public class CreditCard
    {
        //definicion de propiedades
        
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public string Fecha { get; set; }

        [Required]
        public string Cvv { get; set; }



    }
}
