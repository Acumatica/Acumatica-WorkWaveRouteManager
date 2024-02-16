using AcumaticaWorkWave.API.Domain;
using AcumaticaWorkWave.DAC;
using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Data.BQL.Fluent;
using PX.Objects.SO;
using System.Linq;

namespace AcumaticaWorkWave.BLC
{
    public class WWSyncMaint : PXGraph<WWSyncMaint, WWSync>
    {
        public SelectFrom<WWSync>.View WWSyncs;

        public void UpdateResponse(WWAsyncResponse response)
        {
            WWSync row;
            PXEntryStatus status;
            //Do not insert record with requestID == null;
            if (response.RequestId == null)
            {
                row = new WWSync
                {
                    WWSyncProcessed = true
                };
                status = PXEntryStatus.Notchanged;
            }
            else
            {
                var dbRow = GetWWSyncRow(response);
                row = dbRow.row;
                status = dbRow.status;
            }

            row.WWRequestID = response.RequestId;
            row.WWTerritoryID = response.TerritoryId;
            row.WWEvent = response.Event;
            row.WWData = response.Content;            
            row.WWAsyncProcessed = true;

            if (status == PXEntryStatus.Updated)
            {
                WWSyncs.Update(row);
            }

            Actions.PressSave();
            UpdateEntity(row);
        }

        public void UpdateResponse(WWSyncResponse response)
        {
            (WWSync row, PXEntryStatus status) = GetWWSyncRow(response);

            row.WWRequestID = response.RequestId;
            row.WWEntityID = response.EntityID;
            row.WWSyncProcessed = true;

            if (status == PXEntryStatus.Updated)
            {
                WWSyncs.Update(row);
            }

            Actions.PressSave();
            UpdateEntity(row);
        }

        private void UpdateEntity(WWSync row)
        {
            if (row.WWSyncProcessed != true || row.WWAsyncProcessed != true)
                return;

            using (var tr = new PXTransactionScope())
            {
                switch (row.WWEvent)
                {
                    case WWSyncEvents.ORDER_CHANGED:
                        WWISyncWWEntity graph = PXGraph.CreateInstance<SOShipmentEntry>()
                                                       .GetExtension<WWSOShipmentEntryExt>();
                        graph.SyncWWOrder(row);
                        break;
                        //TODO: Add code for different types of events
                    default:
                        break;
                }

                if (row.WWRequestID != null)
                {
                    row.WWEntityProcessed = true;
                    WWSyncs.Update(row);
                    Actions.PressSave();
                }
                
                tr.Complete();
            }
        }

        private (WWSync row, PXEntryStatus status) GetWWSyncRow(WWSyncResponse response)
        {
            var status = PXEntryStatus.Updated;
            var row = WWSyncs.Search<WWSync.wwRequestID>(response.RequestId)
                             .RowCast<WWSync>()
                             .FirstOrDefault();

            if (row == null)
            {
                row = WWSyncs.Insert();
                status = PXEntryStatus.Inserted;
            }

            return (row, status);
        }
    }
}