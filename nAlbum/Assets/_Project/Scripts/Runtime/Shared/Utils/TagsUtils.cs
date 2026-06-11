/*
    nAlbum – Media album based on Unity
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)

    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using Severnbli.NAlbum.Runtime.Features.Tags;

namespace Severnbli.NAlbum.Runtime.Shared.Utils
{
    public static class TagsUtils
    {
        public static void DoActionWithTags(HashSet<ITag> tags, Action<ITag> action)
        {
            foreach (var tag in tags)
            {
                action(tag);
            }
        }
    }
}