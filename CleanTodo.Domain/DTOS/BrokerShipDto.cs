using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTodo.Domain.DTOS
{
    public class BrokerShipDto
    {
        public string Name { get; set; }
        public string Captain { get; set; }
        public int GoldCargo { get; set; }
        public int CrewSize { get; set; }
        public string createdBy { get; set; }
    }
}
