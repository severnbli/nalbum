/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;

namespace Severnbli.NAlbum.Runtime.Core.Allocators.Pools.Collections
{
    public class HashSetPool<T> : Pool<HashSet<T>>
    {
        protected override HashSet<T> CreateInstance()
        {
            return new HashSet<T>(PoolsContracts.CollectionPoolInitSize);
        }
    }
}