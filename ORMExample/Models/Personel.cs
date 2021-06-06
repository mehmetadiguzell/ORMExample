
using ORMExample.Abstract;

namespace ORMExample.Models
{
    public class Personel : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
