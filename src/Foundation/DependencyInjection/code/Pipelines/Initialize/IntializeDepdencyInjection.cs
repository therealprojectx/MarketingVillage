using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using MarketingVillage.Foundation.DependencyInjection.Pipelines.InitializeDepedencyInjection;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace MarketingVillage.Foundation.DependencyInjection.Pipelines.Initialize
{
    public class IntializeDepdencyInjection
    {
        public void Process(PipelineArgs args)
        {
            Log.Info("Start dependency injection initialization", this);

            var container = new Container();
            container.Options.ConstructorResolutionBehavior = new DefaultFirstConstructorBehavior();

            var containerArgs = new InitializeDependencyInjectionArgs(container);
            CorePipeline.Run("initializeDependencyInjection", containerArgs);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(
                    a =>
                        a.FullName.StartsWith("MarketingVillage.Feature.") ||
                        a.FullName.StartsWith("MarketingVillage.Foundation.") ||
                        a.FullName.StartsWith("MarketingVillage.Common.") ||
                        a.FullName.StartsWith("MarketingVillage.Website."));
            container.RegisterMvcControllers(assemblies.ToArray());
            container.RegisterMvcIntegratedFilterProvider();
            
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }

    public class DefaultFirstConstructorBehavior : IConstructorResolutionBehavior
    {
        public ConstructorInfo GetConstructor(Type implementationType)
        {
            var constructors = implementationType.GetConstructors();
            if (constructors.Any())
            {
                return (
                    from ctor in constructors
                    orderby ctor.GetParameters().Length ascending
                    select ctor)
                    .First();
            }

            return null;
        }
    }
}