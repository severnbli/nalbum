/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace Severnbli.NAlbum.Runtime.Core.Allocators.Pools
{
    public interface IPool<T> where T : new()
    {
        T Spawn();
        void Despawn(T instance);
    }
}