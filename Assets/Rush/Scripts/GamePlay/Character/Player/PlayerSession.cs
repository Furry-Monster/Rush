using Netick;
using Netick.Unity;
using Rush.GamePlay.Manager.LocalPlayer;
using Rush.GamePlay.Match;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerSession : NetworkBehaviour
    {
        public override void NetworkStart()
        {
            if (IsInputSource)
            {
                var localPlayerManager = FindObjectOfType<LocalPlayerManager>();
                localPlayerManager.InvokeOnSessionSpawned(this);
            }
        }

        [Rpc(RpcPeers.InputSource, RpcPeers.Owner, true)]
        public void RPCSpawn()
        {
            var matchManager = FindObjectOfType<MatchManager>();
            matchManager.SpawnPlayerCharacter(Sandbox.LocalPlayer);
        }
    }
}