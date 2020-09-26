namespace Group8.Interfaces
{
    /// <summary>
    /// Used for objects need every frame update
    /// </summary>
    public interface IUpdatable
    {
        /// <summary>
        /// Frame based update
        /// </summary>
        void BaseObjectUpdate();

        /// <summary>
        /// Fixed time based update
        /// </summary>
        void BaseObjectFixedUpdate();
        
        /// <summary>
        /// Frame based post update
        /// </summary>
        void BaseObjectLateUpdate();
    }
}