using UnityEngine;
using Group8.Interfaces;

namespace Group8.Base
{
    /// <summary>
    /// 
    /// </summary>
    [DisallowMultipleComponent]
    public class UpdatableBaseObject : BaseObject, IUpdatable
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectUpdate() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectFixedUpdate() { }

        /// <summary>
        /// 
        /// </summary>
        public virtual void BaseObjectLateUpdate() { }
    }
}