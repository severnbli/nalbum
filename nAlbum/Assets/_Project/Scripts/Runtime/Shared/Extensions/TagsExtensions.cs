/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using Severnbli.NAlbum.Runtime.Features.Tags;

namespace Severnbli.NAlbum.Runtime.Shared.Extensions
{
    public static class TagsExtensions
    {
        public static void DoActionInChildren(this ITag tag, Action<ITag> action, bool nested = false)
        {
            var children = nested ? tag.GetNestedChildren() : tag.GetChildren();
            foreach (var child in children) action(child);
        }
    }
}