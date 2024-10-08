using Okala.Api.App.Localization;
using Volo.Abp.Application.Services;

namespace Okala.Api.App.Applications.Core;

public abstract class AppAppService : ApplicationService
{
    protected AppAppService()
    {
        LocalizationResource = typeof(AppResource);
    }
}