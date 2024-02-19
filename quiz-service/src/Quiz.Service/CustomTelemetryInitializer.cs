using CarMax.Appraisal.Gateway.Helpers;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Options;
using Quiz.Service.Configuration;
using Quiz.Service.Resources;

namespace Quiz.Service
{
    public class CustomTelemetryInitializer : ITelemetryInitializer
    {
        private readonly IOptions<WebAppSettings> _webAppSettings;
        private string instance = string.Empty;

        public CustomTelemetryInitializer(IOptions<WebAppSettings> webAppSettings)
        {
            _webAppSettings = webAppSettings;
        }

        public void Initialize(ITelemetry telemetry)
        {
            if (_webAppSettings.Value.GetInstanceId)
            {
                if (string.IsNullOrEmpty(instance))
                {
                    instance = FileSystemHelper.GetInstanceNameFromLogFiles(Instance.ContainerId);
                }

                if (!string.IsNullOrEmpty(instance))
                {
                    telemetry.Context.Cloud.RoleInstance = instance;
                }
            }

        }
    }
}
