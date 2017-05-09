using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Mvc.Presentation;

namespace MarketingVillage.Foundation.ContentRepository.Context
{
    public class SitecoreContextWrapper : IContextWrapper
    {
        public string CurrentItemPath => Sitecore.Context.Item.Paths.FullPath;

        public string GetParameterValue(string key)
        {
            var value = String.Empty;
            var parameters = RenderingContext.Current.Rendering.Parameters;
            if (parameters != null && parameters.Any())
                value = parameters[key];
            return value;
        }
    }
}