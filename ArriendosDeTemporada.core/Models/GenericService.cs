using System;
using System.Collections.Generic;
using System.Text;

namespace ArriendosDeTemporada.core.Models
{
    public class GenericService
    {
        public int ID { get; set; }
        public int idDepartamento { get; set; }
        public bool HasWifi { get; set; }
        public bool AllowsPets { get; set; }
        public bool HasAC { get; set; }
        public bool HasElevator { get; set; }
        public bool HasParking { get; set; }
        public bool IsWheelchairAccessible { get; set; }
        public bool HasPool { get; set; }
        public bool AllowsChildren { get; set; }
        public List<string> OtherServices { get; set; }

        public void SetDefaults()
        {
            OtherServices = new List<string>();
            HasWifi = false;
            AllowsPets = false;
            HasAC = false;
            IsWheelchairAccessible = false;
            HasParking = false;
            HasElevator = false;
            HasPool = false;
            AllowsChildren = false;
        }
    }
}
