using Netick.Unity;
using Rush.GamePlay.Manager;
using TMPro;
using UnityEngine;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerCharacterVisual : NetworkBehaviour
    {
        [SerializeField] private TMP_Text _textNameTag;

        public override void NetworkStart()
        {
            var playerManager = FindObjectOfType<PlayerManager>();

            if (playerManager.TryGetPlayerSession(InputSourcePlayerId, out var playerSession))
            {
                _textNameTag.SetText(playerSession.NickName.ToString());
            }
        }
    }
}