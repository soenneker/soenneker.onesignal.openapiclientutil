using Soenneker.OneSignal.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.OneSignal.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OneSignalOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IOneSignalOpenApiClientUtil _openapiclientutil;

    public OneSignalOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IOneSignalOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
