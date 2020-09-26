namespace Group8.Management
{
    public enum GameState
    {
        /// <summary>
        /// State of the game at the main menu
        /// </summary>
        MainMenu,
        
        /// <summary>
        /// State of the game when the player plays the game
        /// </summary>
        Gameplay,
        
        /// <summary>
        /// State of the game when the player fails to complete the level
        /// </summary>
        LevelFailed,
        
        /// <summary>
        /// State of the game when the player completes the level successfully
        /// </summary>
        LevelPassed
    }
}