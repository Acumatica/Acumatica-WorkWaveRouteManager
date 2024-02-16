using PX.Data;
using PX.Data.BQL;
using System;
using System.Collections.Generic;

namespace AcumaticaWorkWave.Custom
{
    public class WWShipmentStatus
    {
        public const string Open = "N";
        public const string PartiallyRouted = "W";
        public const string RoutePlanning = "P";
        public const string RouteAssigned = "S";
        public const string RouteDelivered = "D";
        public const string RouteError = "E";

        public static List<string> Statuses => new List<string> { PartiallyRouted, RoutePlanning, RouteAssigned, RouteDelivered };

        public class UI
        {
            public const string PartiallyRouted = "Partially Routed";
            public const string RoutePlanning = "Route Planning";
            public const string RouteAssigned = "Route Assigned";
            public const string RouteDelivered = "Route Delivered";
        }

        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(new Tuple<string, string>[]
            {
                Pair(PartiallyRouted, UI.PartiallyRouted),
                Pair(RoutePlanning, UI.RoutePlanning),
                Pair(RouteAssigned, UI.RouteAssigned),
                Pair(RouteDelivered, UI.RouteDelivered),
                
            })
            {
            }
        }

        public class partiallyRouted : BqlType<IBqlString, string>.Constant<WWShipmentStatus.partiallyRouted>
        {
            public partiallyRouted() : base(WWShipmentStatus.PartiallyRouted)
            {
            }
        }

        public class routePlanning : BqlType<IBqlString, string>.Constant<WWShipmentStatus.routePlanning>
        {
            public routePlanning() : base(WWShipmentStatus.RoutePlanning)
            {
            }
        }

        public class routeAssigned : BqlType<IBqlString, string>.Constant<WWShipmentStatus.routeAssigned>
        {
            public routeAssigned() : base(WWShipmentStatus.RouteAssigned)
            {
            }
        }

        public class routeDelivered : BqlType<IBqlString, string>.Constant<WWShipmentStatus.routeDelivered>
        {
            public routeDelivered() : base(WWShipmentStatus.RouteDelivered)
            {
            }
        }
    }
}