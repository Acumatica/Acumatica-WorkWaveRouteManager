using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.DAC;
using PX.Data;
using PX.Data.BQL;
using PX.Data.BQL.Fluent;
using PX.Objects.AR;
using PX.Objects.CS;
using PX.Objects.IN;
using PX.Objects.SO;
using System;

namespace AcumaticaWorkWave.BLC
{
    public class WWSOInvoiceShipmentExt : PXGraphExtension<SOInvoiceShipment>
    {
        #region IsActive

        public static bool IsActive() => PXAccess.FeatureInstalled<FeaturesSet.routeOptimizer>();

        #endregion IsActive

        [PXOverride]
        public virtual PXSelectBase GetShipmentsSelectCommand(SOShipmentFilter filter, Func<SOShipmentFilter, PXSelectBase> base_GetShipmentselectCommand)
        {
            if (filter.Action == "SO302000$createWokWaveOrder")
            {
                return new SelectFrom<SOShipment>.
                            InnerJoin<INSite>.On<SOShipment.FK.Site>.
                             LeftJoin<Customer>.On<SOShipment.customerID.IsEqual<Customer.bAccountID>>.SingleTableOnly.
                            Where<
                                Match<INSite, AccessInfo.userName.FromCurrent>.
                                  And<Customer.bAccountID.IsNull.Or<Match<Customer, AccessInfo.userName.FromCurrent>>>.
                                  And<SOShipment.status.IsEqual<SOShipmentStatus.open>>.
                                  And<WWSOShipmentExt.usrIsWorkWave.IsEqual<True>>.
                                  And<WWSOShipmentExt.usrIsOrderTied.IsEqual<True>>>.View(Base);
            }

            if (filter.Action == "SO302000$getDeliveryStatus")
            {
                return new SelectFrom<SOShipment>.
                            InnerJoin<INSite>.On<SOShipment.FK.Site>.
                             LeftJoin<Customer>.On<SOShipment.customerID.IsEqual<Customer.bAccountID>>.SingleTableOnly.
                            Where<
                                Match<INSite, AccessInfo.userName.FromCurrent>.
                                  And<Customer.bAccountID.IsNull.Or<Match<Customer, AccessInfo.userName.FromCurrent>>>.
                                  And<Brackets<SOShipment.status.IsEqual<WWShipmentStatus.partiallyRouted>.
                                            Or<SOShipment.status.IsEqual<WWShipmentStatus.routePlanning>.
                                            Or<SOShipment.status.IsEqual<WWShipmentStatus.routeAssigned>>>>>.
                                  And<WWSOShipmentExt.usrIsWorkWave.IsEqual<True>>>.View(Base);
            }

            return base_GetShipmentselectCommand(filter);
        }
    }
}