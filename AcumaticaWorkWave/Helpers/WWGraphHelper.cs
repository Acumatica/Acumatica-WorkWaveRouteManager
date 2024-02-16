using PX.Data;
using PX.Objects.SO;
using System.Linq;

namespace AcumaticaWorkWave.Helpers
{
    public static class WWGraphHelper
    {
        public static string GetFieldValue(this SOShipmentEntry graph, string viewName, string fieldName)
        {
            var result = string.Empty;
            var view = graph.Views[viewName];
            var cache = view.Cache;
            if (cache.Current == null)
            {
                var data = view.SelectSingle();
                if (data is PXResult res && res.TableCount > 0)
                {
                    cache.Current = res[0];
                }
                else
                {
                    cache.Current = data;
                } 
            }

            var row = cache.Current;
            var selector = cache.GetAttributes(fieldName).OfType<PXSelectorAttribute>().FirstOrDefault();
            var stringList = cache.GetAttributes(fieldName).OfType<PXStringListAttribute>().FirstOrDefault();

            //Try get value from Selector attribute
            if (selector?.SubstituteKey != null)
            {
                var subsKeyType = selector.SubstituteKey;
                var select = PXSelectorAttribute.Select(cache, row, fieldName);
                if (select != null)
                {
                    var propertyName = char.ToUpper(subsKeyType.Name[0]) + subsKeyType.Name.Substring(1);
                    result = graph.Caches[select.GetType()]?.GetValue(select, propertyName)?.ToString();
                }
            }
            else if (stringList != null)
            {
                var valueLabelDic = stringList.ValueLabelDic;
                var key = cache.GetValue(row, fieldName)?.ToString();
                result = valueLabelDic.TryGetValue(key, out string value) ? value : key;
            }
            else
            {
                //If not get value from Selector - get raw value 
                result = cache.GetValue(row, fieldName)?.ToString();
            }
            
            return result?.Trim();
        }

    }
}