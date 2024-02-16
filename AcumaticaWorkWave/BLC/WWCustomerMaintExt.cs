using AcumaticaWorkWave.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;
using PX.Objects.CR;
using PX.Objects.CS;
using System;

namespace AcumaticaWorkWave.BLC
{
    public class WWCustomerMaintExt : PXGraphExtension<CustomerMaint>
    {
        #region IsActive
        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();
        #endregion IsActive       

        protected virtual void _(Events.FieldUpdated<Customer.defLocationID> e)
        {

            if (!(e.Row is Customer row)) return;

            DateTime? startSec = null;
            DateTime? endSec = null;

            var locationExt = base.Base.GetExtension<CustomerMaint.LocationDetailsExt>();
            var currentSTDLocation = locationExt.Locations.Current;
            if (currentSTDLocation?.LocationID > 0)
            {
                var currentLocation = new SelectFrom<Location>.
                    Where<Location.locationID.IsEqual<@P.AsInt>>.View(this.Base).SelectSingle(currentSTDLocation.LocationID);

                if (currentLocation != null)
                {
                    var currentLocationExt = currentLocation.GetExtension<WWLocationExt>();
                    if (currentLocationExt != null)
                    {
                        startSec = currentLocationExt.UsrWWStartSec;
                        endSec = currentLocationExt.UsrWWEndSec;
                    }
                }
            }

            if (startSec.HasValue) e.Cache.SetValueExt<WWCustomerExt.usrWWStartSec>(row, startSec);

            if (endSec.HasValue) e.Cache.SetValueExt<WWCustomerExt.usrWWEndSec>(row, endSec);
        }

        protected virtual void _(Events.RowInserted<Customer> e)
        {
            if (!(e.Row is Customer row)) return;

            UpdateTimeFields(e.Cache, row);
        }

        protected virtual void _(Events.FieldUpdated<Customer.customerClassID> e)
        {
            if (!(e.Row is Customer row)) return;

            UpdateTimeFields(e.Cache, row);
        }

        private void UpdateTimeFields(PXCache cache, Customer row)
        {
            DateTime? startSec = null;
            DateTime? endSec = null;

            CustomerClass customerClass = base.Base.CustomerClass.SelectSingle();
            var customerClassExtension = customerClass.GetExtension<WWCustomerClassExt>();
            if (customerClassExtension != null)
            {
                startSec = customerClassExtension.UsrWWStartSec;
                endSec = customerClassExtension.UsrWWEndSec;
            }

            cache.SetValueExt<WWCustomerExt.usrWWStartSec>(row, startSec);

            cache.SetValueExt<WWCustomerExt.usrWWEndSec>(row, endSec);
        }
    }
}
