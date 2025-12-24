using Netick.Unity;
using UnityEngine;

namespace Rush.GamePlay.Character.Player.Animation
{
    public class PlayerCharacterAnimator : NetickBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private PlayerCharacterMovement _movement;

        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int Vertical = Animator.StringToHash("Vertical");
        private static readonly int Speed = Animator.StringToHash("Speed");

        private const int VelocityMultiplier = 100;

        public override void NetworkRender()
        {
            var velocity = _movement.LastVelocity * VelocityMultiplier;
            _animator.SetFloat(Horizontal, velocity.x);
            _animator.SetFloat(Vertical, velocity.z);
            _animator.SetFloat(Speed, velocity.magnitude);
        }
    }
}