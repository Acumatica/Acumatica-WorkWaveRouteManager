using PX.Common;

namespace AcumaticaWorkWave.Resources
{
    [PXLocalizable]
    public class WWPluginProperties
    {
        public const string API_KEY = "API KEY";
        public const string SIGNATURE_PASSWORD = "SIGNATURE PASSWORD";
        public const string URL = "URL";
        public const string CALLBACK_URL = "CALLBACK URL";
        public const string WWRM_ELIGIBILITY_TYPE = "WWRM ELIGIBILITY TYPE";
        public const string WWRM_ROUTE_TYPE = "WWRM ROUTE TYPE";
        public const string BARCODE_LIMIT = "BARCODE LIMIT";
        public const string BARCODE_DELIMITER = "BARCODE DELIMITER";
        public const string STORE_POD_SIGNATURE = "STORE POD SIGNATURE";
        public const string STORE_POD_PICTURES = "STORE POD PICTURES";
        public const string STORE_POD_GPS = "STORE POD GPS";
        public const string STORE_POD_DRIVER_NOTES = "STORE POD DRIVER NOTES";
        public const string DRIVE_NOTE_INTERNAL = "DRIVER NOTE INTERNAL";

        public const string BARCODE_LIMIT_ALLOW = "ALLOW";
        public const string BARCODE_LIMIT_PREVENT = "PREVENT";
        public const string BARCODE_LIMIT_SPLIT = "SPLIT";
        
        //Route types
        public const string WWRM_ROUTE_DROP_OFF = "Drop-off";
        public const string WWRM_ROUTE_PICK_UP = "Pick-up";
        public static string WWRM_ROUTE_PICK_UP_DROP_OFF = $"{WWRM_ROUTE_PICK_UP} & {WWRM_ROUTE_DROP_OFF}";

        [PXLocalizable]
        internal class UI
        {
            public const string API_KEY = "API Key";
            public const string SIGNATURE_PASSWORD = "Signature Password";
            public const string URL = "WorkWave URL";
            public const string CALLBACK_URL = "CallBack URL";
            public const string WWRM_ELIGIBILITY_TYPE = "WWRM Eligibility Type";
            public const string WWRM_ROUTE_TYPE = "WWRM Route Type";
            public const string BARCODE_LIMIT = "BarCode Limit";
            public const string BARCODE_DELIMITER = "BarCode Delimiter";
            public const string STORE_POD_SIGNATURE = "Store PoD Signature";
            public const string STORE_POD_PICTURES = "Store PoD Pictures";
            public const string STORE_POD_GPS = "Store PoD GPS";
            public const string STORE_POD_DRIVER_NOTES = "Store PoD Driver notes";
            public const string DRIVE_NOTE_INTERNAL = "Driver Note Internal";

            //Allow the shipment lines to exceed 10 – ideal for companies that do not plan to use BarCode tracking;
            public const string BARCODE_LIMIT_ALLOW = "Allow";

            //If a shipment contains more than 10 lines (or packages) prevent the shipment from being send to WWRM and display an error message
            public const string BARCODE_LIMIT_PREVENT = "Prevent";

            //If a shipment contains more than 10 lines (or packages), split the shipment into multiple WorkWave delivery
            public const string BARCODE_LIMIT_SPLIT = "Split";
        }
    }
}