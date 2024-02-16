using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Log;
using WorkWaveIntegrationQA.Tests.Wrappers;

namespace WorkWaveIntegrationQA.Tests.Extensions
{
    public class ShipmentGeneric : SO3020PL_PXGenericInqGrph
    {
        public c_filter_form FilterForm => base.Filter_form;
        public c_results_grid ResultsGrid => base.Results_grid;

        public bool SearchShipment(string shipmentNumber)
        {
            Log.Information($"Search a shipment by number: {shipmentNumber}");
            OpenScreen();
            ResultsGrid.ResetColumnFilters();
            ResultsGrid.Columns.SOShipment_shipmentNbr.Contains(shipmentNumber);
            var rows = ResultsGrid.AllPageData().ToList();
            if (rows.Any())
            {
                Log.Information("Record is found");
                return true;
            }
            Log.Information("Record is not found");
            return false;
        }
    }
}
