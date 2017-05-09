using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarketingVillage.Foundation.ContentRepository.Context;
using MarketingVillage.Foundation.ContentRepository.Repositories;
using MarketingVillage.Foundation.DependencyInjection.Pipelines.InitializeDepedencyInjection;

namespace MarketingVillage.Foundation.ContentRepository.DI
{
    public class RegisterContainer
    {
        public void Process(InitializeDependencyInjectionArgs args)
        {
            args.Container.Register<IContentRepository, SitecoreContentRepository>();
            args.Container.Register<IContextWrapper, SitecoreContextWrapper>();
        }
    }
}