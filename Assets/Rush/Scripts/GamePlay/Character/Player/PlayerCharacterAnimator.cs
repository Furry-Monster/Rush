using Netick.Unity;
using UnityEngine;

namespace Rush.GamePlay.Character.Player
{
    public class PlayerCharacterAnimator : NetickBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerCharacterMovement _movement;

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private const int VelocityMultiplier = 100;
        private const float MaxLastVelocityInterpolationSpeed = 5f;

        private Vector3 _lastVelocity;

        public override void NetworkRender()
        {
            var velocity = _movement.LastVelocity * VelocityMultiplier;
            var direction = transform.InverseTransformDirection(velocity);

            _lastVelocity = Vector3.Lerp(_lastVelocity, direction,
                Sandbox.DeltaTime * MaxLastVelocityInterpolationSpeed);
            _lastVelocity = Vector3.ClampMagnitude(_lastVelocity, 1f);

            _animator.SetFloat(Horizontal, _lastVelocity.x);
            _animator.SetFloat(Vertical, _lastVelocity.z);
            _animator.SetFloat(Speed, velocity.magnitude);
        }
    }
}