using SimpleInjector;

namespace MarketingVillage.Foundation.DependencyInjection.Pipelines.InitializeDepedencyInjection
{
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Pipelines;

    // TODO: \App_Config\include\InitializeDependencyInjectionArgs.config created automatically when creating InitializeDependencyInjectionArgs class.

    public class InitializeDependencyInjectionArgs : PipelineArgs
    {
        public Container Container { get; set; }

        public InitializeDependencyInjectionArgs(Container container)
        {
            this.Container = container;
        }
    }
}