/*
    nAlbum – Media album based on Unity 
    Copyright (C) 2026 Severnbli (aka Usevalad Buben)
    
    You should have received a copy of the GNU General Public License
    along with this program. If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using Severnbli.NAlbum.Runtime.Shared.Utils;

namespace Severnbli.NAlbum.Runtime.Core.Domains
{
    /// <summary>
    /// Domain that only handle application-level objects
    /// such as pools
    /// </summary>
    public class ObjectDomain
    {
        #region Singleton
        
        private static ObjectDomain _instance;

        public static ObjectDomain GetInstance()
        {
            return _instance ??= new ObjectDomain();
        }
        
        #endregion

        private readonly Dictionary<Type, object> _domain = new();

        /// <summary>
        /// Give object sample from domain or create and bind it to domain
        /// </summary>
        /// <typeparam name="T">Must be class with existed default constructor</typeparam>
        /// <returns></returns>
        public T Get<T>() where T : class, new()
        {
            T result;
            
            if (!_domain.TryGetValue(typeof(T), out var obj))
            {
                result = CreateAndBindToDomain<T>();
            }
            else
            {
                try
                {
                    result = (T)obj;
                }
                catch (InvalidCastException e)
                {
                    LogUtils.LogError($"Invalid cast on domain object conversion: {e.Message}");
                    result = CreateAndBindToDomain<T>();
                }
            }
            
            return result;
        }

        private T CreateAndBindToDomain<T>() where T : class, new()
        {
            var obj = new T();
            _domain[typeof(T)] = obj;
            return obj;
        }
    }
}