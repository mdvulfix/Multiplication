using System.Collections.Generic;
using UnityEngine;
using Framework.Core;

namespace Framework
{
    [CreateAssetMenu(fileName = "Factory Page (Default)", menuName = "Factories/Page/Default")]
    public class FactoryPageDefault : FactoryPage
    {
        public override HashSet<IPage> GetPages()
        {
            var pages = new HashSet<IPage>()
            {
                Get<PageLoading>(),
                Get<PageLogin>(),
                Get<PageMainMenu>()

            };

            return pages;
        }

    }
}
