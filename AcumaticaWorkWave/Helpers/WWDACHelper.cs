using AcumaticaWorkWave.API.Domain.Orders;
using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.DAC;
using PX.Data;
using PX.Objects.SO;
using System.Collections.Generic;
using System.Linq;

namespace AcumaticaWorkWave.Helpers
{
    public static class WWDACHelper
    {
        public static string GetWWTerritoryID(this WWCarrierTerritory wwCarrierTerritory)
        {
            return wwCarrierTerritory.WWTerritoryID.ToString();
        }

        public static bool IsShipmentNotAssignedState(this SOShipment shipment)
        {
            return shipment.Status == WWShipmentStatus.RoutePlanning
                && shipment.GetExtension<WWSOShipmentExt>().UsrWWStatus == WWOrderStatus.TBS;
        }

        public static bool IsShipmentWorkWaveCarrier(this SOShipment shipment)
        {
            return shipment.GetExtension<WWSOShipmentExt>().UsrIsWorkWave.GetValueOrDefault();
        }

        public static OrderIds Init(this OrderIds orderIds, List<WWOrder> wwOrders)
        {
            orderIds.Ids.AddRange(wwOrders.Select(w => w.WWOrderID));
            return orderIds;
        }

        public static OrderList Init(this OrderList orderList, OrderInput orderInput)
        {
            orderList.Orders.AddRange(orderInput.Orders);

            return orderList;
        }

        public static OrderList InitIds(this OrderList orderList, List<WWOrder> wwOrders)
        {
            foreach (var wwOrder in wwOrders)
            {
                var item = orderList.Orders.FirstOrDefault(o => o.Name == wwOrder.WWOrderName);
                if (item != null)
                {
                    item.Id = wwOrder.WWOrderID;
                }
            }

            return orderList;
        }

        public static bool RowsAreIdentical(this WWCarrierTerritory row, WWCarrierTerritory newRow)
        {            
            if (row.WWTerritoryID != null && newRow.WWTerritoryID != null)
            {
                if (row.WWWarehouseID == newRow.WWWarehouseID
                 && row.WWBranchID == newRow.WWBranchID
                 && row.WWCompanyID == newRow.WWCompanyID)
                    return true;

                if (row.WWWarehouseID != null && newRow.WWWarehouseID != null
                 && row.WWWarehouseID == newRow.WWWarehouseID
                 && row.WWBranchID != newRow.WWBranchID
                 && row.WWCompanyID == newRow.WWCompanyID)
                    return true;

                if (row.WWWarehouseID == null && newRow.WWWarehouseID == null
                 && row.WWBranchID == newRow.WWBranchID
                 && row.WWCompanyID == newRow.WWCompanyID)
                    return true;

                if (row.WWWarehouseID == newRow.WWWarehouseID
                 && row.WWBranchID == null && newRow.WWBranchID == null
                 && row.WWCompanyID == newRow.WWCompanyID)
                    return true;

                if (row.WWWarehouseID == null && newRow.WWWarehouseID == null
                 && row.WWBranchID == null && newRow.WWBranchID == null
                 && row.WWCompanyID == newRow.WWCompanyID)
                    return true;
            }

            return false;
        }
    }
}