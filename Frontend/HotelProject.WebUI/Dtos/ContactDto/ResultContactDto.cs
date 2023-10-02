﻿using HotelProject.EntityLayer.Concrete;

namespace HotelProject.WebUI.Dtos.ContactDto
{
    public class ResultContactDto
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public int ContactCategoryId { get; set; }
        public ContactCategory Category { get; set; }
    }
}
