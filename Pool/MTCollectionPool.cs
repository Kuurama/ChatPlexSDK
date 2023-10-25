using System.Collections.Generic;

namespace CP_SDK.Pool
{
    /// <summary>
    /// A Collection such as List, HashSet, Dictionary etc can be pooled and reused by using a CollectionPool.
    /// </summary>
    public class CollectionPool<TCollection, TItem> where TCollection : class, ICollection<TItem>, new()
    {
        /// <summary>
        /// Static collection
        /// </summary>
        internal static readonly ObjectPool<TCollection> s_Pool = new ObjectPool<TCollection>(() => new TCollection(), actionOnRelease: (x => x.Clear()), defaultCapacity: 100);

        ////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Simple get
        /// </summary>
        /// <returns></returns>
        public static TCollection Get()
            => s_Pool.Get();
        /// <summary>
        /// Release an element
        /// </summary>
        /// <param name="p_Element">Element to release</param>
        public static void Release(TCollection p_Element)
            => s_Pool.Release(p_Element);
    }
}