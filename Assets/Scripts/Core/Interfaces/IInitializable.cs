namespace Group8.Interfaces
{
    /// <summary>
    /// Used for objects need to initialize.
    /// </summary>
    public interface IInitializable
    { 
        /// <summary>
        /// Pre initialization state
        /// </summary>
        void BaseObjectAwake();
        
        /// <summary>
        /// Initialization state
        /// </summary>
        void BaseObjectStart();
    }
}