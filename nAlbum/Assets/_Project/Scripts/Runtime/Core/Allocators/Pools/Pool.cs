/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using Severnbli.NAlbum.Runtime.Core.Allocators.Factories;

namespace Severnbli.NAlbum.Runtime.Core.Allocators.Pools
{
    public class Pool<T> : Factory<T>, IPool<T> where T : new()
    {
        protected readonly Stack<T> Instances = new();
        
        public T Spawn()
        {
            var instance = SpawnInstance();
            PostSpawn(instance);
            return instance;
        }

        protected virtual T SpawnInstance()
        {
            if (!Instances.TryPop(out var instance))
            {
                instance = Create();
            }
            
            return instance;
        }

        protected virtual void PostSpawn(T instance)
        {
            
        }

        public void Despawn(T instance)
        {
            DespawnInstance(instance);
            PostDespawn(instance);
        }

        protected virtual void DespawnInstance(T instance)
        {
            Instances.Push(instance);
        }

        protected virtual void PostDespawn(T instance)
        {
            
        }
    }
}