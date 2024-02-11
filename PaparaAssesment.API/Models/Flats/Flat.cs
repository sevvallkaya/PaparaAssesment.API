using PaparaAssesment.API.Models.Payments;
using PaparaAssesment.API.Models.Residents;
using PaparaAssesment.API.Models.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaparaAssesment.API.Models.Flats
{
    public class Flat
    {
        [Key]
        public int FlatId { get; set; }

        public bool IsAvailable { get; set; }

        public int Floor { get; set; }

        public int FlatNumber { get; set; }


       
        public int? ResidentId { get; set; } 
        [ForeignKey("ResidentId")]
        public Resident? Resident { get; set; }

    
        public int BlockId { get; set; }  
        [ForeignKey("BlockId")]
        public Block Block { get; set; }

       
        public int FlatTypeId { get; set; }
        [ForeignKey("FlatTypeId")]
        public FlatType FlatType { get; set; }

        public ICollection<Payment> Payments { get; set; }

        public Flat()
        {
            Payments = new HashSet<Payment>();
        }


    }
}
