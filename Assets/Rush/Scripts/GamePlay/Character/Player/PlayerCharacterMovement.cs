using Netick;
using Netick.Unity;
using Rush.GamePlay.GameInput;
using UnityEngine;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerCharacterMovement : NetworkBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _moveSpeed = 5.0f;

        public Vector3 LastVelocity => _lastVelocity;
        [Networked] private Vector3 _lastVelocity { get; set; }

        public override void NetworkFixedUpdate()
        {
            if (FetchInput(out PlayerInput localInput))
            {
                // set pos
                var horizontal = localInput.MoveAxis.x;
                var vertical = localInput.MoveAxis.y;
                var velocity = new Vector3(horizontal, 0f, vertical) * _moveSpeed;
                _rigidbody.transform.position += velocity * Sandbox.FixedDeltaTime;

                // set rot
                var lookDir = localInput.RaycastPos - _rigidbody.transform.position;
                _rigidbody.transform.rotation = Quaternion.LookRotation(lookDir, Vector3.up);

                _lastVelocity = velocity;
            }
        }
    }
}