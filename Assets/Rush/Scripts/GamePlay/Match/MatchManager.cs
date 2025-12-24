using Netick;
using Netick.Unity;
using UnityEngine;

namespace Rush.GamePlay.Match
{
    public class MatchManager : NetworkEventsListener
    {
        [SerializeField] private NetworkObject _playerPrefab;

        public override void OnSceneLoaded(NetworkSandbox sandbox)
        {
            if (sandbox.IsHost)
                Sandbox.NetworkInstantiate(_playerPrefab.gameObject, Vector3.zero, Quaternion.identity,
                    sandbox.LocalPlayer);
        }

        public override void OnClientConnected(NetworkSandbox sandbox, NetworkConnection client)
        {
            Sandbox.NetworkInstantiate(_playerPrefab.gameObject, Vector3.zero, Quaternion.identity, client);
        }
    }
}