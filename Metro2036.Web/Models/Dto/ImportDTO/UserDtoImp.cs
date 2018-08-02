namespace Metro2036.Web.Models.DTO.ImportDTO
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;

    public class UserDtoImp
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string TravelCardId { get; set; }
    }
}
