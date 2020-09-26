using System;
using System.Linq;
using UnityEngine;
using Group8.Base;
using Group8.Extensions;
using System.Collections.Generic;

namespace Group8.Management
{
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private List<BaseObject> baseObjects = default;

        private GameState currentGameState = GameState.MainMenu;

        public GameState CurrentGameState
        {
            get => currentGameState;
            set
            {
                currentGameState = value;
                GameStateChanged?.Invoke(this.currentGameState);
            }
        }

        public event Action<GameState> GameStateChanged;

        #region Unity Event Methods

        private void Awake()
        {
            CallAwakes();
        }

        private void Start()
        {
            CallStarts();
        }

        private void Update()
        {
            CallUpdates();
        }

        private void FixedUpdate()
        {
            CallFixedUpdates();
        }

        private void LateUpdate()
        {
            CallLateUpdates();
        }

        private void OnDestroy()
        {
            CallOnDestroys();
        }

        #endregion

        #region Broadcasting Methods

        private void CallAwakes()
        {
            baseObjects.Call(x=>x.BaseObjectAwake());
        }
        
        private void CallStarts()
        {
            baseObjects.Call(x=>x.BaseObjectStart());
        }
        
        private void CallUpdates()
        {
            baseObjects.OfType<UpdatableBaseObject>().Call(x => x.BaseObjectUpdate());
        }
        
        private void CallFixedUpdates()
        {
            baseObjects.OfType<UpdatableBaseObject>().Call(x=> x.BaseObjectFixedUpdate());
        }
        
        private void CallLateUpdates()
        {
            baseObjects.OfType<UpdatableBaseObject>().Call(x => x.BaseObjectLateUpdate());
        }
        
        private void CallOnDestroys()
        {
            baseObjects.Call(x=>x.BaseObjectDestroy());
        }

        #endregion

        #region Public Methods

        public void SetGameState(GameState state, bool force)
        {
            if (state.Equals(CurrentGameState) && !force) return;
            this.CurrentGameState = state;
        }
        
        #endregion
    }
}