using Netick;
using Netick.Unity;
using Rush.GamePlay.Manager;
using Rush.GamePlay.Match;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerSession : NetworkBehaviour
    {
        [Networked] public NetworkString16 NickName { get; set; }

        private int _inputSourcePlayerId;

        public void SetNickName(string nickName)
        {
            NickName = new NetworkString16(nickName);
        }

        public override void NetworkStart()
        {
            _inputSourcePlayerId = InputSourcePlayerId;

            var playerManager = FindObjectOfType<PlayerManager>();
            playerManager.RegisterPlayerSession(this);

            if (IsInputSource)
            {
                var localPlayerManager = FindObjectOfType<LocalPlayerManager>();
                localPlayerManager.InvokeOnSessionSpawned(this);
            }
        }

        public override void NetworkDestroy()
        {
            var playerManager = FindObjectOfType<PlayerManager>();
            playerManager.RemovePlayerSession(_inputSourcePlayerId);
        }

        [Rpc(RpcPeers.InputSource, RpcPeers.Owner, true)]
        public void RPCSpawn()
        {
            var matchManager = FindObjectOfType<MatchManager>();
            matchManager.SpawnPlayerCharacter(InputSource);
        }
    }
}