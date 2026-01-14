using Netick;
using Netick.Unity;
using Rush.GamePlay.Manager;
using UnityEngine;
using NetworkPlayer = Netick.NetworkPlayer;

namespace Rush.GamePlay.Match
{
    public class MatchManager : NetworkEventsListener
    {
        [SerializeField] private NetworkObject _playerCharacterPrefab;
        [SerializeField] private NetworkObject _playerSessionPrefab;

        public override void OnSceneLoaded(NetworkSandbox sandbox)
        {
            var playerManager = FindObjectOfType<PlayerManager>();
            playerManager.CachePlayers();

            if (sandbox.IsHost)
                SpawnPlayerSession(sandbox.LocalPlayer);
        }

        public override void OnClientConnected(NetworkSandbox sandbox, NetworkConnection client)
        {
            SpawnPlayerSession(client);
        }

        public void SpawnPlayerCharacter(NetworkPlayer player)
        {
            Sandbox.NetworkInstantiate(_playerCharacterPrefab.gameObject, Vector3.zero, Quaternion.identity, player);
        }

        private void SpawnPlayerSession(NetworkPlayer player)
        {
            Sandbox.NetworkInstantiate(_playerSessionPrefab.gameObject, Vector3.zero, Quaternion.identity, player);
        }
    }
}