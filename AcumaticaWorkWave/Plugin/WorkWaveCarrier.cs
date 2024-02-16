using AcumaticaWorkWave.API.Client;
using AcumaticaWorkWave.API.Domain.Callback;
using AcumaticaWorkWave.API.Provider;
using AcumaticaWorkWave.Helpers;
using AcumaticaWorkWave.Resources;
using PX.CarrierService;
using PX.Data;
using PX.Objects.CA;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AcumaticaWorkWave.Plugin
{
    public class WorkWaveCarrier : ICarrierService
    {
        private string apiKey;
        private string signaturePassword;
        private string url;
        private string callbackUrl;
        private readonly string wwrmEligibilityType;
        private readonly string wwrmRouteType;
        private string barcodeLimit;
        private string barcodeDelimeter;
        private string storePodSignature;
        private string storePodPictures;
        private string storePodGps;
        private string storePodDriverNotes;
        private string driveNoteInternal;

        private readonly List<string> attributes;
        public IList<string> Attributes => attributes;
        public string CarrierID { get; set; }
        public string Method { get; set; }
        public string EligibilityType => wwrmEligibilityType;
        public string BarcodeDelimeter => barcodeDelimeter;
        public string BarcodeLimit => barcodeLimit;
        public string Url => url;
        public string CallbackUrl => callbackUrl;
        public bool StorePodGps => storePodGps == true.ToString();
        public bool StorePodDriverNotes => storePodDriverNotes == true.ToString();
        public bool StorePodPictures => storePodPictures == true.ToString();
        public bool StorePodSignature => storePodSignature == true.ToString();


        private readonly List<CarrierMethod> methods;
        public ReadOnlyCollection<CarrierMethod> AvailableMethods => methods.AsReadOnly();

        public WorkWaveCarrier()
        {
            methods = new List<CarrierMethod>
            {
                new CarrierMethod("NA", "Empty method")
            };

            attributes = new List<string>() { WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME};

            url = WWPluginDefaulValues.URL;
            wwrmEligibilityType = WWPluginDefaulValues.WWRM_ELIGIBILITY_TYPE;
            wwrmRouteType = WWPluginDefaulValues.DEFAULT_WWRM_ROUTE_TYPE;
            barcodeLimit = WWPluginProperties.BARCODE_LIMIT_PREVENT;
        }

        public WWRestOptions GetApiOptions(string apiKey, string url)
        {
            var options = new WWRestOptions
            {
                ApiKey = new Guid(apiKey),
                BaseUrl = url,
                SignaturePassword = signaturePassword
            };

            return options;
        }

        private Guid Guid(string apiKey)
        {
            throw new NotImplementedException();
        }

        public  WWRestOptions GetApiOptions()
        {
            return GetApiOptions(apiKey, url);
        }

        public CarrierResult<string> Cancel(string trackingNumber, string trackingData)
        {
            throw new NotImplementedException();
        }

        public void LoadSettings(IList<ICarrierDetail> settings)
        {
            foreach (ICarrierDetail carrierDetail in settings)
            {
                if (carrierDetail.DetailID == WWPluginProperties.API_KEY)
                {
                    apiKey = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.SIGNATURE_PASSWORD)
                {
                    signaturePassword = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.URL)
                {
                    url = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.CALLBACK_URL)
                {
                    callbackUrl = carrierDetail.Value;
                }

                if (carrierDetail.DetailID == WWPluginProperties.BARCODE_LIMIT)
                {
                    barcodeLimit = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.BARCODE_DELIMITER)
                {
                    barcodeDelimeter = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.STORE_POD_SIGNATURE)
                {
                    storePodSignature = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.STORE_POD_PICTURES)
                {
                    storePodPictures = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.STORE_POD_GPS)
                {
                    storePodGps = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.STORE_POD_DRIVER_NOTES)
                {
                    storePodDriverNotes = carrierDetail.Value;
                }
                if (carrierDetail.DetailID == WWPluginProperties.DRIVE_NOTE_INTERNAL)
                {
                    driveNoteInternal = carrierDetail.Value;
                }
            }
        }

        public IList<ICarrierDetail> ExportSettings()
        {
            List<ICarrierDetail> list = new List<ICarrierDetail>(12);

            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.API_KEY, WWPluginProperties.UI.API_KEY, apiKey, ControlTypeDefintion.Password));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.SIGNATURE_PASSWORD, WWPluginProperties.UI.SIGNATURE_PASSWORD, signaturePassword, ControlTypeDefintion.Password));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.URL, WWPluginProperties.UI.URL, url));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.CALLBACK_URL, WWPluginProperties.UI.CALLBACK_URL, callbackUrl));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.WWRM_ELIGIBILITY_TYPE, WWPluginProperties.UI.WWRM_ELIGIBILITY_TYPE, wwrmEligibilityType));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.WWRM_ROUTE_TYPE, WWPluginProperties.UI.WWRM_ROUTE_TYPE, wwrmRouteType));
            var barcodeLimitDetail = new WorkWaveDetail(CarrierID, WWPluginProperties.BARCODE_LIMIT, WWPluginProperties.UI.BARCODE_LIMIT, barcodeLimit, ControlTypeDefintion.Combo);
            barcodeLimitDetail.SetComboValues(new List<KeyValuePair<string, string>>
                                                  {
                                                      new KeyValuePair<string, string>(WWPluginProperties.BARCODE_LIMIT_ALLOW, WWPluginProperties.UI.BARCODE_LIMIT_ALLOW),
                                                      new KeyValuePair<string, string>(WWPluginProperties.BARCODE_LIMIT_PREVENT, WWPluginProperties.UI.BARCODE_LIMIT_PREVENT),
                                                      new KeyValuePair<string, string>(WWPluginProperties.BARCODE_LIMIT_SPLIT, WWPluginProperties.UI.BARCODE_LIMIT_SPLIT),
                                                  });
            list.Add(barcodeLimitDetail);

            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.BARCODE_DELIMITER, WWPluginProperties.UI.BARCODE_DELIMITER, barcodeDelimeter));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.STORE_POD_SIGNATURE, WWPluginProperties.UI.STORE_POD_SIGNATURE, storePodSignature, ControlTypeDefintion.CheckBox));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.STORE_POD_PICTURES, WWPluginProperties.UI.STORE_POD_PICTURES, storePodPictures, ControlTypeDefintion.CheckBox));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.STORE_POD_GPS, WWPluginProperties.UI.STORE_POD_GPS, storePodGps, ControlTypeDefintion.CheckBox));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.STORE_POD_DRIVER_NOTES, WWPluginProperties.UI.STORE_POD_DRIVER_NOTES, storePodDriverNotes, ControlTypeDefintion.CheckBox));
            list.Add(new WorkWaveDetail(CarrierID, WWPluginProperties.DRIVE_NOTE_INTERNAL, WWPluginProperties.UI.DRIVE_NOTE_INTERNAL, driveNoteInternal, ControlTypeDefintion.CheckBox));

            return list;
        }

        public CarrierResult<IList<CarrierCertificationData>> GetCertificationData()
        {
            PXTrace.WriteInformation(nameof(GetCertificationData));
            return null;
        }

        public CarrierResult<IList<RateQuote>> GetRateList(CarrierRequest request)
        {
            PXTrace.WriteInformation(nameof(GetRateList));
            return null;
        }

        public CarrierResult<RateQuote> GetRateQuote(CarrierRequest request)
        {
            PXTrace.WriteInformation(nameof(GetRateQuote));
            return null;
        }

        public CarrierResult<ShipResult> Return(CarrierRequest request)
        {
            PXTrace.WriteInformation(nameof(Return));
            return null;
        }

        public CarrierResult<ShipResult> Ship(CarrierRequest request)
        {
            PXTrace.WriteInformation(nameof(Ship));
            return null;
        }

        public CallbackResponce SetCallback()
        {
            var options = GetApiOptions();
            var provider = WWProviderLocator.Instance
                                            .Reset<WWCallbackProvider>()
                                            .Get<WWCallbackProvider>(options);

            var callback = new Callback
            {
                Url = callbackUrl,
                Test = true,
                SignaturePassword = signaturePassword
            };

            return provider.Set<CallbackResponce>(callback);
        }

        public CarrierResult<string> Test()
        {
            try
            {
                CheckParameters(apiKey, url, callbackUrl);
                var response = SetCallback();
                return new CarrierResult<string>(WWMessages.WWTestConnectionSuccessful);
            }
            catch (WWRequestExceptionBase e)
            {
                var (code, message) = WWProviderHelper.ExplainResponceException(e);
                return new CarrierResult<string>(false, null, new Message(code.ToString(), message));
            }
            catch (Exception e)
            {
                return new CarrierResult<string>(false, null, new Message ("-1", e.Message));
            }
        }

        public void CheckParameters(string apiKey, string url, string callbackUrl)
        {
            if (string.IsNullOrEmpty(apiKey) || string.IsNullOrEmpty(url) || string.IsNullOrEmpty(callbackUrl))
            {
                throw new PXException(PXLocalizer.Localize($"{WWPluginProperties.UI.API_KEY}, {WWPluginProperties.UI.URL} and {WWPluginProperties.UI.CALLBACK_URL} should be entered"));
            }
        }

        public class WorkWaveDetail : ICarrierDetail
        {
            public string CarrierID { get; set; }
            public string DetailID { get; set; }
            public string Descr { get; set; }
            public string Value { get; set; }
            public int? ControlType { get; set; }

            public WorkWaveDetail(string carrierID, string detailID, string descr, string value) : this(carrierID, detailID, descr, value, ControlTypeDefintion.Text)
            {
            }

            public WorkWaveDetail(string carrierID, string detailID, string descr, string value, int? controlType)
            {
                CarrierID = carrierID;
                DetailID = detailID;
                Descr = descr;
                Value = value;
                ControlType = controlType;
                comboValues = new List<KeyValuePair<string, string>>();
            }

            public IList<KeyValuePair<string, string>> GetComboValues()
            {
                return comboValues;
            }

            public void SetComboValues(IList<KeyValuePair<string, string>> list)
            {
                comboValues = list;
            }

            private IList<KeyValuePair<string, string>> comboValues;
        }
    }
}