/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

namespace Severnbli.NAlbum.Runtime.Core.Allocators.Factories
{
    public class Factory<T> : IFactory<T> where T : new()
    {
        public T Create()
        {
            var instance = CreateInstance();
            PostCreate(instance);
            return instance;
        }

        protected virtual T CreateInstance()
        {
            return new T();
        }

        protected virtual void PostCreate(T instance)
        {
            
        }
    }
}