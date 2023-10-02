using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class ContactCategory
    {
        public int ContactCategoryId { get; set; }
        public string ContactCategoryName { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}
