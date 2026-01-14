using System.Collections.Generic;
using Rush.GamePlay.Character.Player;
using UnityEngine;

namespace Rush.GamePlay.Manager.Player
{
    public class PlayerManager : MonoBehaviour
    {
        private readonly Dictionary<int, PlayerSession> _playerSessions = new();
        private readonly Dictionary<int, PlayerCharacter> _playerCharacters = new();

        public bool TryGetPlayerSession(int inputSourcePlayerId, out PlayerSession playerSession)
        {
            return _playerSessions.TryGetValue(inputSourcePlayerId, out playerSession);
        }

        public PlayerSession GetPlayerSession(int inputSourcePlayerId)
        {
            return _playerSessions[inputSourcePlayerId];
        }

        public bool TryGetPlayerCharacter(int inputSourcePlayerId, out PlayerCharacter playerCharacter)
        {
            return _playerCharacters.TryGetValue(inputSourcePlayerId, out playerCharacter);
        }

        public PlayerCharacter GetPlayerCharacter(int inputSourcePlayerId)
        {
            return _playerCharacters[inputSourcePlayerId];
        }

        public void RegisterPlayerCharacter(PlayerCharacter playerCharacter)
        {
            _playerCharacters.Add(playerCharacter.InputSourcePlayerId, playerCharacter);
        }

        public void RegisterPlayerSession(PlayerSession playerSession)
        {
            _playerSessions.Add(playerSession.InputSourcePlayerId, playerSession);
        }

        public void RemovePlayerCharacter(int inputSourcePlayerId)
        {
            _playerCharacters.Remove(inputSourcePlayerId);
        }

        public void RemovePlayerSession(int inputSourcePlayerId)
        {
            _playerSessions.Remove(inputSourcePlayerId);
        }
    }
}