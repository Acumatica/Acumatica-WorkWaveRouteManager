using PX.Data;
using PX.Data.BQL;
using System;

namespace AcumaticaWorkWave.Custom
{
    public class WWOrderStatus
    {
        public const string NotCreated = "O";
        public const string Pending = "P";
        public const string TBS = "C";
        public const string RouteAssigned = "A";
        public const string Rescheduled = "S";
        public const string DeliveredIssue = "I";
        public const string Delivered = "D";
        public const string ChangingError = "E";

        private class UI
        {
            public const string NotCreated = "Not Created";
            public const string Pending = "Pending";
            public const string TBS = "TBS";
            public const string RouteAssigned = "Route Assigned";
            public const string Rescheduled = "Rescheduled";
            public const string DeliveredIssue = "Delivered with Issue";
            public const string Delivered = "Delivered";
            public const string ChangingError = "Error";
        }

        public class ListAttribute : PXStringListAttribute
        {
            public ListAttribute() : base(new Tuple<string, string>[]
            {
                Pair(NotCreated, UI.NotCreated),
                Pair(Pending, UI.Pending),
                Pair(TBS, UI.TBS),
                Pair(RouteAssigned, UI.RouteAssigned),
                //Pair(Rescheduled, UI.Rescheduled),
                Pair(DeliveredIssue, UI.DeliveredIssue),
                Pair(Delivered, UI.Delivered),
                Pair(ChangingError, UI.ChangingError)
            })
            {
            }
        }

        public class notCreated : BqlType<IBqlString, string>.Constant<WWOrderStatus.notCreated>
        {
            public notCreated() : base(WWOrderStatus.NotCreated)
            {
            }
        }

        public class pending : BqlType<IBqlString, string>.Constant<WWOrderStatus.pending>
        {
            public pending() : base(WWOrderStatus.Pending)
            {
            }
        }

        public class tbs : BqlType<IBqlString, string>.Constant<WWOrderStatus.tbs>
        {
            public tbs() : base(WWOrderStatus.TBS)
            {
            }
        }

        public class routeAssigned : BqlType<IBqlString, string>.Constant<WWOrderStatus.routeAssigned>
        {
            public routeAssigned() : base(WWOrderStatus.RouteAssigned)
            {
            }
        }

        public class rescheduled : BqlType<IBqlString, string>.Constant<WWOrderStatus.rescheduled>
        {
            public rescheduled() : base(WWOrderStatus.Rescheduled)
            {
            }
        }

        public class deliveredIssue : BqlType<IBqlString, string>.Constant<WWOrderStatus.deliveredIssue>
        {
            public deliveredIssue() : base(WWOrderStatus.DeliveredIssue)
            {
            }
        }

        public class delivered : BqlType<IBqlString, string>.Constant<WWOrderStatus.delivered>
        {
            public delivered() : base(WWOrderStatus.Delivered)
            {
            }
        }
    }
}