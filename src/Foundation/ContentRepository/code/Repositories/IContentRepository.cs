using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketingVillage.Foundation.ContentRepository.Model;

namespace MarketingVillage.Foundation.ContentRepository.Repositories
{
    public interface IContentRepository
    {
        T GetContentItem<T>(string contentItem, bool isLazy = false, bool inferType = false) where T : class;
        T GetCurrentItem<T>(bool isLazy = false, bool inferType = false) where T : class;
        T GetHomeItem<T>(bool isLazy = false, bool inferType = false) where T : class;
        T GetRootItem<T>(bool isLazy = false, bool inferType = false) where T : class;
        T QuerySingle<T>(string query, bool isLazy = false, bool inferType = false) where T : class;
        T QuerySingleRelative<T>(string query, bool isLazy = false, bool inferType = false) where T : class;
        bool HasDataSource();
        string GetDataSource();
        string GetRenderingParameters();
        bool IsExperienceEditor { get; }
        string GetSiteRoot();
    }
}
