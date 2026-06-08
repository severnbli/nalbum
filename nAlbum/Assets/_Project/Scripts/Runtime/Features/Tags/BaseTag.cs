/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;

namespace Severnbli.NAlbum.Runtime.Features.Tags
{
    public class BaseTag : ITag
    {
        private string _name;
        
        public HashSet<ITag> Children { get; } = new();

        public virtual string GetDescription() => _name;
    }
}