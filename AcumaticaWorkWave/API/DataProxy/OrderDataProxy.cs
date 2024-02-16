using PX.Objects.SO;
using PX.Objects.CR;
using System.Collections.Generic;
using AcumaticaWorkWave.Plugin;
using PX.Objects.IN;
using AcumaticaWorkWave.API.Domain.Orders;

namespace AcumaticaWorkWave.API.DataProxy
{
    public class OrderDataProxy
    {
        public WorkWaveCarrier Service { get; set; }
        public SOShipment Shipment { get; set; }
        public SOShipmentContact DeliveryContact { get; set; }
        public SOShipmentAddress DeliveryAddress { get; set; }
        public SOOrder Order { get; set; }
        public List<SOPackageDetailEx> Packages { get; set; }
        public INSite Warehouse { get; internal set; }
        public Contact PickUpContact { get; set; }
        public Address PickUpAddress { get; set; }
        public string WarehouseNotes { get; internal set; }
        public string ShipmentNotes { get; internal set; }
        public List<TimeWindow> TimeWindows { get; set; }
        public List<WWCustomFieldMapping> CustomFieldMappings { get; set; }
    }
}