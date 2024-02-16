using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.DAC;
using AcumaticaWorkWave.Helpers;
using System;

namespace AcumaticaWorkWave.API.Domain.Routes
{
    public class RouteDataProxy
    {
        public Step Step { get; internal set; }
        public TrackingData TrackingData => Step?.TrackingData;
        public string TrackingLink { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public void UpdateWWOrder(WWOrder wwOrder)
        {
            //WWOrder in ChangingError status, no way for update
            if (wwOrder.WWDeliveryStatus == WWOrderStatus.ChangingError)
            {
                return;
            }

            //WWOrder in Pending status, no way for update
            if (wwOrder.WWDeliveryStatus == WWOrderStatus.Pending && Step == null && TrackingData == null)
            {
                return;
            }
            
            if (Step != null)
            {
                wwOrder.WWDeliveryStatus = Step?.GetDeliveryStatus();
                wwOrder.WWGPS = TrackingData?.GetGPS();
                wwOrder.WWDeliveryDateTime = TrackingData?.GetDeliveryDateTime(DeliveryDate);
                wwOrder.WWNoteValue = TrackingData?.GetNote();
                wwOrder.WWPictureValue = TrackingData?.GetPicture();
                wwOrder.WWPictureNoteValue = TrackingData?.GetPictureNote();
                wwOrder.WWSignatureValue = TrackingData?.GetSignature();
                wwOrder.WWSignatureNoteValue = TrackingData?.GetSignatureNote();
                wwOrder.WWTrackingURL = TrackingLink;
            }
            else
            {
                wwOrder.WWDeliveryStatus =  WWOrderStatus.TBS;
            }
        }
    }
}