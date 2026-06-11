/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System.Collections.Generic;
using Severnbli.NAlbum.Runtime.Core.Allocators.Pools.Collections;
using Severnbli.NAlbum.Runtime.Core.Domains;

namespace Severnbli.NAlbum.Runtime.Features.Tags
{
    public class BaseTag : ITag
    {
        private string _name;
        private readonly HashSet<ITag> _children = new();

        public virtual string GetDescription() => _name;
        
        public HashSet<ITag> GetChildren() => _children;

        public HashSet<ITag> GetNestedChildren(HashSet<ITag> buffer = null)
        {
            buffer ??= new HashSet<ITag>();

            if (buffer.Contains(this)) return buffer;
            
            foreach (var child in _children)
            {
                buffer.Add(child);
                child.GetNestedChildren(buffer);
            }
            
            return buffer;
        }

        public bool HasChildren(ITag tag)
        {
            return _children.Contains(tag);
        }

        public bool HasNestedChildren(ITag tag)
        {
            var pool = ObjectDomain.GetInstance().Get<HashSetPool<ITag>>();
            var set = pool.Spawn();
            
            var nestedChildren = tag.GetNestedChildren(set);
            var hasChildren = nestedChildren.Contains(tag);
            
            pool.Despawn(set);
            return hasChildren;
        }
        
        public bool AddChild(ITag tag)
        {
            return _children.Add(tag);
        }

        public bool RemoveChild(ITag tag)
        {
            return _children.Remove(tag);
        }
    }
}