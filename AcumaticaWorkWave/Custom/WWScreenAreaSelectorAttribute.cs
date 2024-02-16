using PX.Api;
using PX.Data;
using PX.Objects.CS;
using PX.Objects.SO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PX.Metadata;

namespace AcumaticaWorkWave.Custom
{
    public class WWScreenAreaSelectorAttribute : PXCustomSelectorAttribute
    {
        private readonly Type _fieldColumnType;
        private readonly Dictionary<AreaKey, Tuple<string, string, string, List<string>>> _screenInfoDictionary;
        private readonly string _screenID = "SO302000";
        private SOShipmentEntry soShipmentGraph;
        private List<string> _approvedViews = new List<string> { "Document", 
                                                                 "Transactions", 
                                                                 "OrderList", 
                                                                 "Shipping_Contact", 
                                                                 "Shipping_Address", 
                                                                 "CurrentDocument", 
                                                                 "Packages", 
                                                                 "PackageDetailSplit" };

        public WWScreenAreaSelectorAttribute(Type fieldColumnType) : base(typeof(WWScreenAreaSelect.screenAreaId),
                                                                          typeof(WWScreenAreaSelect.screenAreaName))
        {
            _fieldColumnType = fieldColumnType;
            _screenInfoDictionary = new Dictionary<AreaKey, Tuple<string, string, string, List<string>>>();
            soShipmentGraph = PXGraph.CreateInstance<SOShipmentEntry>();
            SelectorMode = PXSelectorMode.TextModeReadonly | PXSelectorMode.DisplayModeValue;
            ValidateValue = true;
            SubstituteKey = typeof(WWScreenAreaSelect.screenAreaName);
        }

        protected virtual IEnumerable GetRecords()
        {
            List<WWScreenAreaSelect> screenAreas = null;
            _screenInfoDictionary.Clear();

            if (!string.IsNullOrWhiteSpace(_screenID))
            {
                PXSiteMap.ScreenInfo info = null;
                try
                {
                    info = ScreenUtils.ScreenInfo.TryGet(_screenID);
                }
                catch (Exception e)
                {
                    var message = e.InnerException?.Message;
                    throw new PXException(message);
                }

                if (info != null)
                {
                    screenAreas = new List<WWScreenAreaSelect>(info.Containers.Count);

                    foreach (var container in info.Containers)
                    {
                        if (!container.Value.IsInSmartPanel)
                        {
                            var areaName = container.Value.DisplayName;
                            if (string.IsNullOrWhiteSpace(areaName))
                            {
                                areaName = "Main";
                            }

                            var viewName = container.Value.ViewName;
                            var dac = string.Empty;

                            var index = viewName.IndexOf(":", StringComparison.Ordinal);
                            if (index > 0)
                            {
                                viewName = viewName.Substring(0, index);
                            }

                            var view = soShipmentGraph.Views[viewName];

                            if (view != null)
                            {
                                dac = view.Cache.GetItemType().Name;
                            }

                            var fields = container.Value.Fields.Where(x => !x.Invisible)
                                                               .Select(x => x.FieldName)
                                                               .ToList();

                            if (!string.IsNullOrWhiteSpace(viewName) && _approvedViews.Any(a => a == viewName) && !string.IsNullOrWhiteSpace(dac))
                            {
                                var key = new AreaKey { AreaName = areaName, ViewName = viewName };
                                _screenInfoDictionary.Add(key, new Tuple<string, string, string, List<string>>(areaName, viewName, dac, fields));

                                var screenArea = new WWScreenAreaSelect()
                                {
                                    ScreenAreaId = key.GetHashCode(),
                                    ScreenAreaName = areaName,
                                    ViewName = viewName,
                                    DAC = dac,
                                };

                                screenAreas.Add(screenArea);
                            }
                        }
                    }
                }
            }

            return screenAreas ?? new List<WWScreenAreaSelect>();
        }

        public override void CacheAttached(PXCache sender)
        {
            base.CacheAttached(sender);
            sender.Graph.FieldUpdated.AddHandler(sender.GetItemType(), _FieldName, FieldUpdated);

            if (_fieldColumnType != null)
            {
                sender.Graph.FieldSelecting.AddHandler(sender.GetItemType(), _fieldColumnType.Name, FieldColumnSelecting);
            }
        }

        private void FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row is WWCustomFieldMapping row)
            {
                var key = _screenInfoDictionary.Keys.FirstOrDefault(k => k.GetHashCode() == row.WWScreenAreaID);
                if (key != null)
                {
                    var values = _screenInfoDictionary[key];
                    sender.SetValue<WWCustomFieldMapping.wwScreenAreaName>(row, values.Item1);
                    sender.SetValue<WWCustomFieldMapping.wwViewName>(row, values.Item2);
                    sender.SetValue<WWCustomFieldMapping.wwDACName>(row, values.Item3);
                }

                sender.SetValue<WWCustomFieldMapping.wwCustomFieldName>(row, string.Empty);
            }
        }

        private void FieldColumnSelecting(PXCache sender, PXFieldSelectingEventArgs e)
        {
            if (e.Row is WWCustomFieldMapping row)
            {
                var key = _screenInfoDictionary.Keys.FirstOrDefault(k => k.GetHashCode() == row.WWScreenAreaID);

                if (key != null)
                {
                    var dataRow = _screenInfoDictionary[key];
                    if (dataRow != null)
                    {
                        var list = dataRow.Item4.ToArray();
                        e.ReturnState = PXStringState.CreateInstance(e.ReturnState,
                                        CSAttributeDetail.ParameterIdLength,
                                        true,
                                        typeof(WWCustomFieldMapping.wwFieldName).Name,
                                        false,
                                        -1,
                                        string.Empty,
                                        list,
                                        list,
                                        false,
                                        null);

                        ((PXStringState)e.ReturnState).MultiSelect = false;
                    }
                }
            }
        }
    }

    internal class AreaKey : IEqualityComparer<AreaKey>
    {
        public string AreaName { get; set; }
        public string ViewName { get; set; }

        public bool Equals(AreaKey x, AreaKey y)
        {
            return x?.ViewName == y?.ViewName
                && x?.AreaName == y?.AreaName;
        }

        public int GetHashCode(AreaKey obj)
        {
            return obj.AreaName.GetHashCode() ^ obj.ViewName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj, this);
        }

        public override int GetHashCode()
        {
            return GetHashCode(this);
        }
    }
}