using System.ComponentModel.DataAnnotations;

namespace Warehouse.Models.Entites
{
    public class ContactMessage
    {
        [Key]
        public int Message_RowID { get; set; }

        [Required]
        public Guid Contact_GUID { get; set; } = Guid.NewGuid();

       
        public string Contact_Name { get; set; }

    
        public string Contact_Email { get; set; } 

       
        public string Contact_Subject { get; set; }

        public string Contact_Message { get; set; } 

        public DateTime Contact_CreatedOn { get; set; } = DateTime.UtcNow; 
    }
}


