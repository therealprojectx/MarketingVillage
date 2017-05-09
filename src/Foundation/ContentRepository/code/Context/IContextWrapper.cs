using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketingVillage.Foundation.ContentRepository.Context
{
    public interface IContextWrapper
    {
        string CurrentItemPath { get; }
        string GetParameterValue(string key);
    }
}
