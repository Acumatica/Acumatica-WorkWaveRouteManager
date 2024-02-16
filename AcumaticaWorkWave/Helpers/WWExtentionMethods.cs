using AcumaticaWorkWave.Resources;
using System;
using System.Text;

namespace AcumaticaWorkWave.Helpers
{
    public static class WWExtentionMethods
    {
        public static StringBuilder TryAppend(this StringBuilder sb, object value, char delimiter, char whiteSpace)
        {
            if (value is string str && !string.IsNullOrEmpty(str))
            {
                sb.Append(str).Append(delimiter).Append(whiteSpace);
            }

            return sb;
        }

        public static string ToWWDate(this DateTime? date)
        {
            return date?.ToString("yyyyMMdd");
        }

        public static bool IsBarcodeLimitAllow(this string barcodeLimit)
        {
            return barcodeLimit == WWPluginProperties.BARCODE_LIMIT_ALLOW;
        }

        public static bool IsBarcodeLimitPrevent(this string barcodeLimit)
        {
            return barcodeLimit == WWPluginProperties.BARCODE_LIMIT_PREVENT;
        }

        public static Guid? ToGuid(string value)
        {
            try
            {
                return new Guid(value);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}