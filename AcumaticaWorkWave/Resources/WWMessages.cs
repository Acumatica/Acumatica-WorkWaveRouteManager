using PX.Common;

namespace AcumaticaWorkWave.Resources
{
    [PXLocalizable]
    public class WWMessages
    {
        public const string WWFeatureFieldClass = "WORKWAVE";

        public const string WWFeatureName = "WorkWave Route Optimization";

        public const string WWValueIsRequired = "Required value is null or empty";

        public const string WWFeatureException = "Feature Exception";

        public const string WWFeatureNotActiveException = "Plug-In {0} is disabled. Enable feature {1} for use plug-in.";

        public const string WWWorkWaveTerritoriesNotAnyActiveRow = "At least one entry in the WorkWave Territories should be active";

        public const string WWTestConnectionSuccessful = "Testing connection successfull";

        public const string WWTestConnectionError = "Testing connection error";

        public const string WWAPIException = "WW API Exception";

        public const string WWHTTPException = "HTTP Exception";

        public const string WWCompanyFieldCannotBeEmpty = "Error: Company field cannot be empty";

        public const string WWBarcodeLimitationPreventException = "Error: Cannot create WorkWave order as Shipment has more than 10 packages";

        public const string WWShipmentHeader = "Shipment";

        public const string WWShipmentDeleteAsk = "The current Shipment record will be deleted";

        public const string WWOrderDeleteAsk = "The current WorkWave order(s) will be deleted";

        public const string WWShipmentDeleteError = "Shipment delete error: WorkWave order(s) {0} is assigned and cannot be deleted. Unassign the order(s) in WorkWave and try again.";

        public const string WWOrderDeleteError = "One or more error occurs while delete WorkWave order(s)";

        public const string WWOrderDeleteLocally = "WorkWave Orders will be deleted only from Acumatica site. You must independently remove these orders from the WorkWave site.";

        public const string WWAPIKeyShouldBeGuid = "WorkWave API Key should be in GUID format";

        public const string WWAPIKeyChangedHeader = "Plug-in API KEY";

        public const string WWAPIKeyChanged = "After the API KEY will be changed, all the related records from the table \"Workwave Territories\" will be deleted.";

        public const string WWShipmentCorrectError = "Shipment correct error: current WorkWave order(s) {0} is assigned and cannot be corrected. Unassign the order(s) in WorkWave and try again";

        public const string WWCantDuplicateCustomFieldMapping = "Cannot duplicate WorkWave custom field mapping record.";

        public const string WWDuplicateWorkWaveTerritory = "Cannot duplicate WorkWave Territory record. Combination of Company/Branch/Warehouse/Territory should be unique";
        public const string WWDuplicateCompanyBranchWarehousetDifferentTerritory = "Cannot duplicate WorkWave Territory record. Combination of Company/Branch/Warehouse can not belong to different Territories";

        public const string WWCustomFieldMappingCountMoreThen20 = "OrderStep can not contain more than 20 custom fields.";

        public const string WWCustomFieldMappingLengthMoreThen3000 = "The total combined size of all custom field values cannot exceed 3000 characters.";

        public const string SignaturePrefix = "sig";
        public const string PicturePrefix = "pic";

        public const string ShipmentIsNotOpen = "Shipment has the status invalid for creating WorkWave Order";
    }
}