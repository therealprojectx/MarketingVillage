using MarketingVillage.Foundation.DependencyInjection.Pipelines.InitializeDepedencyInjection;
using Glass.Mapper.Sc;
using SimpleInjector;
using Sitecore.Pipelines;

namespace MarketingVillage.Foundation.Orm.DI
{
    public class RegisterContainer
    {
        public void Process(InitializeDependencyInjectionArgs args)
        {
            args.Container.Register<ISitecoreContext>(() => new SitecoreContext(), Lifestyle.Transient);
            args.Container.Register<IGlassHtml, GlassHtml>();
        }
    }
}