using System;
using Rush.GamePlay.Character.Player;
using UnityEngine;

namespace Rush.GamePlay.Manager
{
    public class LocalPlayerManager : MonoBehaviour
    {
        public event Action OnCharacterSpawned;
        public event Action<PlayerSession> OnSessionSpawned;

        public PlayerSession PlayerSession { get; private set; }

        public void InvokeOnSessionSpawned(PlayerSession playerSession)
        {
            PlayerSession = playerSession;
            OnSessionSpawned?.Invoke(playerSession);
        }
    }
}