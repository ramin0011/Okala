using Volo.Abp.Application.Services;
using Okala.Api.App.Localization;

namespace Okala.Api.App.Services;

/* Inherit your application services from this class. */
public abstract class AppAppService : ApplicationService
{
    protected AppAppService()
    {
        LocalizationResource = typeof(AppResource);
    }
}