using Microsoft.Extensions.Localization;
using Okala.Api.App.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Okala.Api.App;

[Dependency(ReplaceServices = true)]
public class AppInfo : DefaultBrandingProvider
{
    private IStringLocalizer<AppResource> _localizer;

    public AppInfo(IStringLocalizer<AppResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}