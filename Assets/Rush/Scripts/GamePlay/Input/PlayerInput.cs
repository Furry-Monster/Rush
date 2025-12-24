using Netick;
using UnityEngine;

namespace Rush.GamePlay.GameInput
{
    public struct PlayerInput : INetworkInput
    {
        public Vector2 MoveAxis;
        public Vector3 RaycastPos;
    }
}