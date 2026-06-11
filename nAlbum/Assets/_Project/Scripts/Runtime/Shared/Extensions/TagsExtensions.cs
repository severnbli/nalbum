/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using Severnbli.NAlbum.Runtime.Core.Allocators.Pools.Collections;
using Severnbli.NAlbum.Runtime.Core.Domains;
using Severnbli.NAlbum.Runtime.Features.Tags;
using Severnbli.NAlbum.Runtime.Shared.Utils;

namespace Severnbli.NAlbum.Runtime.Shared.Extensions
{
    public static class TagsExtensions
    {
        public static void DoActionInChildren(this ITag tag, Action<ITag> action)
        {
            TagsUtils.DoActionWithTags(tag.GetChildren(), action);
        }

        public static void DoActionInNestedChildren(this ITag tag, Action<ITag> action)
        {
            var pool = ObjectDomain.GetInstance().Get<HashSetPool<ITag>>();
            var set = pool.Spawn();
            
            tag.GetNestedChildren(set);
            TagsUtils.DoActionWithTags(tag.GetChildren(), action);
            
            pool.Despawn(set);
        }
    }
}