using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Framework.Test
{
    [TestClass]
    public class Config
    {
        public readonly string WebAppUrl;
        public readonly string ApiBaseUri;
        public readonly string AppId;
        public readonly string TempMin;
        public readonly string TempMax;
        public readonly string WindMin;
        public readonly string WindMax;
        public readonly string PressureMin;
        public readonly string PressureMax;
        public readonly string CloudMin;
        public readonly string CloudMax;
        public readonly string VisiblityMin;
        public readonly string VisiblityMax;
        public readonly string HumidityMin;
        public readonly string HumidityMax;
        private static Config config;


        private Config(TestContext testContext)
        {
            if (testContext != null)
            {
                foreach (DictionaryEntry item in testContext.Properties)
                {
                    switch (item.Key.ToString())
                    {
                        case nameof(WebAppUrl):
                            WebAppUrl = item.Value.ToString();
                            break;
                        case nameof(ApiBaseUri):
                            ApiBaseUri = item.Value.ToString();
                            break;
                        case nameof(AppId):
                            AppId = item.Value.ToString();
                            break;
                        case nameof(TempMax):
                            TempMax = item.Value.ToString();
                            break;
                        case nameof(TempMin):
                            TempMin = item.Value.ToString();
                            break;
                        case nameof(WindMax):
                            WindMax = item.Value.ToString();
                            break;
                        case nameof(WindMin):
                            WindMin = item.Value.ToString();
                            break;
                        case nameof(PressureMax):
                            PressureMax = item.Value.ToString();
                            break;
                        case nameof(PressureMin):
                            PressureMin = item.Value.ToString();
                            break;
                        case nameof(CloudMax):
                            CloudMax = item.Value.ToString();
                            break;
                        case nameof(CloudMin):
                            CloudMin = item.Value.ToString();
                            break;
                        case nameof(VisiblityMax):
                            VisiblityMax = item.Value.ToString();
                            break;
                        case nameof(VisiblityMin):
                            VisiblityMin = item.Value.ToString();
                            break;
                        case nameof(HumidityMax):
                            HumidityMax = item.Value.ToString();
                            break;
                        case nameof(HumidityMin):
                            HumidityMin = item.Value.ToString();
                            break;
                    }

                }
            }

        }

        public static Config Instance(TestContext testContext)
        {

            if (config == null)
            {
                config = new Config(testContext);
            }
            return config;

        }
    }
}
