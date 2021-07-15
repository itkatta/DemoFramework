namespace Framework.Test
{
    using System.Collections;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Singleton config class.
    /// </summary>
    public class Config
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private static Config config;

        /// <summary>
        /// The web application URL.
        /// </summary>
        public readonly string WebAppUrl;

        /// <summary>
        /// The API base URI.
        /// </summary>
        public readonly string ApiBaseUri;

        /// <summary>
        /// The application identifier.
        /// </summary>
        public readonly string AppId;

        /// <summary>
        /// The temporary minimum.
        /// </summary>
        public readonly string TempMin;

        /// <summary>
        /// The temporary maximum.
        /// </summary>
        public readonly string TempMax;

        /// <summary>
        /// The wind minimum.
        /// </summary>
        public readonly string WindMin;

        /// <summary>
        /// The wind maximum
        /// </summary>
        public readonly string WindMax;

        /// <summary>
        /// The pressure minimum.
        /// </summary>
        public readonly string PressureMin;

        /// <summary>
        /// The pressure maximum.
        /// </summary>
        public readonly string PressureMax;

        /// <summary>
        /// The cloud minimum.
        /// </summary>
        public readonly string CloudMin;

        /// <summary>
        /// The cloud maximum.
        /// </summary>
        public readonly string CloudMax;

        /// <summary>
        /// The visibility minimum.
        /// </summary>
        public readonly string VisibilityMin;

        /// <summary>
        /// The visibility maximum.
        /// </summary>
        public readonly string VisibilityMax;

        /// <summary>
        /// The humidity minimum.
        /// </summary>
        public readonly string HumidityMin;

        /// <summary>
        /// The humidity maximum.
        /// </summary>
        public readonly string HumidityMax;

        /// <summary>
        /// Initializes a new instance of the <see cref="Config"/> class.
        /// </summary>
        /// <param name="testContext">The test context.</param>
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
                        case nameof(VisibilityMax):
                            VisibilityMax = item.Value.ToString();
                            break;
                        case nameof(VisibilityMin):
                            VisibilityMin = item.Value.ToString();
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

        /// <summary>
        /// Instances the specified test context.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        /// <returns></returns>
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
