using AcumaticaWorkWave.API.Domain.Routes;
using AcumaticaWorkWave.Custom;
using AcumaticaWorkWave.Resources;
using System;
using System.Linq;

namespace AcumaticaWorkWave.Helpers
{
    public static class WWRouteExtentions
    {
        public static string GetDeliveryStatus(this Step step)
        {
            if (step.IsNoTrackingData())
            {
                return WWOrderStatus.RouteAssigned;
            }
            else if (step.IsTrackingDataStatusReschedule())
            {
                return WWOrderStatus.Rescheduled;
            }
            else if (step.IsTrackingDataStatusDeliveredIssue())
            {
                return WWOrderStatus.DeliveredIssue;
            }
            else if (step.IsTrackingDataStatusDelivered())
            {
                return WWOrderStatus.Delivered;
            }

            return WWOrderStatus.TBS;
        }

        public static bool IsNoTrackingData(this Step step)
        {
            return step?.TrackingData == null;
        }

        public static bool IsTrackingDataStatusReschedule(this Step step)
        {
            return step.TrackingData != null && step.TrackingData.Status == WWTrackingDataStatuses.Reschedule;
        }

        public static bool IsTrackingDataStatusDeliveredIssue(this Step step)
        {
            return step.TrackingData != null
                && step.TrackingData.Status == WWTrackingDataStatuses.Done
                && step.TrackingData.Pods != null
                && step.TrackingData.Pods.Pods != null
                && step.TrackingData.Pods.Pods.Any(x => x.BarcodeStatus != WWTrackingDataStatuses.BarcodeStatusScanned);
        }

        public static bool IsTrackingDataStatusDelivered(this Step step)
        {
            return step.TrackingData != null
               && step.TrackingData.Status == WWTrackingDataStatuses.Done;
        }

        public static string GetGPS(this TrackingData trackingData)
        {
            if (trackingData != null)
            {
                
                if (trackingData.StatusLatLng != null)
                {
                    return string.Join(", ", trackingData.StatusLatLng);
                }
            }

            return null;
        }

        public static DateTime? GetDeliveryDateTime(this TrackingData trackingData, DateTime? date)
        {
            if (date.HasValue)
            {
                return date.Value.AddSeconds(trackingData.StatusSec.GetValueOrDefault());
            }

            return null;
        }

        public static string GetNote(this TrackingData trackingData)
        {
            if (trackingData != null && trackingData.Pods != null && trackingData.Pods.Note != null)
            {
                return trackingData.Pods.Note.Text;
            }

            return null;
        }

        public static string GetPicture(this TrackingData trackingData)
        {
            if (trackingData != null && trackingData.Pods != null && trackingData.Pods.Pictures != null)
            {
                var tokens = trackingData.Pods.Pictures.Select(p => p.Value.Token).ToList();
                return string.Join("|", tokens);
            }

            return null;
        }

        public static string GetPictureNote(this TrackingData trackingData)
        {
            if (trackingData != null && trackingData.Pods != null && trackingData.Pods.Pictures != null)
            {
                var tokens = trackingData.Pods.Pictures.Select(p => p.Value.Text).ToList();
                return string.Join("|", tokens);
            }

            return null;
        }

        public static string GetSignature(this TrackingData trackingData)
        {
            if (trackingData != null && trackingData.Pods != null && trackingData.Pods.Signatures != null)
            {
                var tokens = trackingData.Pods.Signatures.Select(p => p.Value.Token).ToList();
                return string.Join("|", tokens);
            }

            return null;
        }

        public static string GetSignatureNote(this TrackingData trackingData)
        {
            if (trackingData != null && trackingData.Pods != null && trackingData.Pods.Signatures != null)
            {
                var tokens = trackingData.Pods.Signatures.Select(p => p.Value.Text).ToList();
                return string.Join("|", tokens);
            }

            return null;
        }
    }
}