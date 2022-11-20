using System.ComponentModel.DataAnnotations;

namespace CustomerMicroservice.Data.Entities
{
    public class CustomerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }

    }
}
