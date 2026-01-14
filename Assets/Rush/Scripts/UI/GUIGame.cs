using System;
using Rush.GamePlay.Manager.LocalPlayer;
using UnityEngine;
using UnityEngine.UI;

namespace Rush.UI.Game.GUI
{
    public class GUIGame : MonoBehaviour
    {
        [SerializeField] private Button _buttonRespawn;

        private void Start()
        {
            _buttonRespawn.onClick.AddListener(OnButtonRespawn);
        }

        private void OnButtonRespawn()
        {
            var localPlayerManager = FindObjectOfType<LocalPlayerManager>();
            localPlayerManager?.PlayerSession.RPCSpawn();
        }
    }
}