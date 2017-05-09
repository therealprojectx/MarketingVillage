using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Web;

namespace MarketingVillage.Foundation.ContentRepository.Repositories
{
    public class SitecoreContentRepository : IContentRepository
    {
        private readonly ISitecoreContext _sitecoreContext;
        private readonly IRenderingContext _renderingContext;

        public SitecoreContentRepository(ISitecoreContext sitecoreContext, IRenderingContext renderingContext)
        {
            _sitecoreContext = sitecoreContext;
            _renderingContext = renderingContext;
        }
        public T GetContentItem<T>(string contentItem, bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.GetItem<T>(contentItem, isLazy, inferType);
        }
        public T GetCurrentItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.GetCurrentItem<T>(isLazy, inferType);
        }
        public T GetHomeItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.GetHomeItem<T>(isLazy, inferType);
        }
        public T GetRootItem<T>(bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.GetRootItem<T>(isLazy, inferType);
        }
        public T QuerySingle<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.QuerySingle<T>(query, isLazy, inferType);
        }
        public T QuerySingleRelative<T>(string query, bool isLazy = false, bool inferType = false) where T : class
        {
            return _sitecoreContext.QuerySingleRelative<T>(query, isLazy, inferType);
        }
        public bool HasDataSource()
        {
            return _renderingContext.HasDataSource;
        }
        public string GetDataSource()
        {
            return _renderingContext.GetDataSource();
        }
        public string GetRenderingParameters()
        {
            return _renderingContext.GetRenderingParameters();
        }
        public bool IsExperienceEditor => Sitecore.Context.PageMode.IsExperienceEditor;
        public string GetSiteRoot()
        {
            return Sitecore.Context.Site.RootPath;
        }
    }
}