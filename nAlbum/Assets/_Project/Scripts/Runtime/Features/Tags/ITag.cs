/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;

namespace Severnbli.NAlbum.Runtime.Features.Tags
{
    public interface ITag
    {
        string GetDescription();
        HashSet<ITag> GetChildren();
        HashSet<ITag> GetNestedChildren(HashSet<ITag> buffer = null);
        bool HasChildren(ITag tag);
        bool HasNestedChildren(ITag tag);
        bool AddChild(ITag tag);
        bool RemoveChild(ITag tag);
    }
}