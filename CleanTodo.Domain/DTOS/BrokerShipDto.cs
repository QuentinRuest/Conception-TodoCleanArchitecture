using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
    public class BrokerShipDto
    {
        public string name { get; set; }
        public int goldCargo { get; set; }
        public DateTime createdAt { get; set; }
        public string captain { get; set; }
        public string status { get; set; }
        public int crewSize { get; set; }
        public string createdBy { get; set; }
        public DateTime lastModified { get; set; }
    }
}
