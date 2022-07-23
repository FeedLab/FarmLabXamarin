using System;

namespace FarmLabDevice.Model
{
    public class FarmItem
    {
        public Guid ExternalFarmReference { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool IsConfirmedByEmail { get; set; }

        public DateTime TimeCreate { get; set; }
        public DateTime TimeModify { get; set; }
    }
}
