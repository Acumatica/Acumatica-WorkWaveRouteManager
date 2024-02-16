using AcumaticaWorkWave.Resources;
using PX.Data;
using PX.Objects.CA;
using PX.Objects.CS;
using System;
using System.Collections;
using System.Linq;
using static PX.Data.BQL.BqlPlaceholder;

namespace AcumaticaWorkWave.Custom
{
    public class WWPXProviderTypeSelectorAttribute : PXProviderTypeSelectorAttribute
    {
        private Type[] _providerInterfaceType;

        public WWPXProviderTypeSelectorAttribute(params Type[] providerType)
        {
            _providerInterfaceType = providerType;
        }

        protected override IEnumerable GetRecords()
        {

            return GetProviderRecs(_providerInterfaceType).Where(c => c.TypeName != WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME);
        }
    }

    public class WWPXProviderOtherTypeSelectorAttribute : PXProviderTypeSelectorAttribute
    {
        private Type[] _providerInterfaceType;

        public WWPXProviderOtherTypeSelectorAttribute(params Type[] providerType)
        {
            _providerInterfaceType = providerType;
        }

        protected override IEnumerable GetRecords()
        {
            bool showPluginList = PXAccess.FeatureInstalled<FeaturesSet.customCarrierIntegration>();
            return GetProviderRecs(_providerInterfaceType).Where(c => (c.TypeName != WWPluginDefaulValues.PLUGIN_ASSEMBLY_NAME || showPluginList));
        }
    }
}