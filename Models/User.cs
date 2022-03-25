using System.Collections.Generic;

namespace workoholicshop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }

        public List<Order> Orders { get; set; }
    

   
    
    }
}
