using UnityEngine;
using Group8.Interfaces;

namespace Group8.Base
{
    /// <summary>
    /// 
    /// </summary>
    [DisallowMultipleComponent]
    public class BaseObject : MonoBehaviour, IInitializable, IDestroyable
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectAwake() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectStart() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectOnDisable() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectDestroy() { }
    }
}