using Netick.Unity;
using Rush.GamePlay.Manager.Player;
using UnityEngine;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerCharacter : NetworkBehaviour
    {
        [SerializeField] private PlayerSession _playerSession;

        private int _inputSourcePlayerId;

        public override void NetworkStart()
        {
            var playerManager = FindObjectOfType<PlayerManager>();
            playerManager.RegisterPlayerCharacter(this);

            _inputSourcePlayerId = InputSourcePlayerId;

            playerManager.TryGetPlayerSession(_inputSourcePlayerId, out _playerSession);
        }

        public override void NetworkDestroy()
        {
            var playerManager = FindObjectOfType<PlayerManager>();
            playerManager.RemovePlayerCharacter(_inputSourcePlayerId);
        }
    }
}