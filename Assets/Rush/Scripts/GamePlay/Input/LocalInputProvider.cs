using Netick.Unity;
using UnityEngine;

namespace Rush.GamePlay.GameInput
{
    public class LocalInputProvider : NetworkEventsListener
    {
        public override void OnInput(NetworkSandbox sandbox)
        {
            var playerInput = new PlayerInput
            {
                MoveAxis = GetMoveAxis(),
                RaycastPos = GetRaycastPos(),
            };

            sandbox.SetInput(playerInput);
        }

        /// <summary>
        /// Get movement axis based on camera orientation and input axes.
        /// </summary>
        private static Vector2 GetMoveAxis()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            var mainCamera = Camera.main!;

            var forward = mainCamera.transform.forward * vertical;
            var right = mainCamera.transform.right * horizontal;
            var forwardVec2 = new Vector2(forward.x, forward.z);
            var rightVec2 = new Vector2(right.x, right.z);

            return forwardVec2 + rightVec2;
        }

        /// <summary>
        /// Get world position from raycast based on mouse position.
        /// </summary>
        private static Vector3 GetRaycastPos()
        {
            var mainCamera = Camera.main!;
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            var plane = new Plane(Vector3.up, Vector3.zero);
            if (plane.Raycast(ray, out var enter))
            {
                var point = ray.GetPoint(enter);
                return point;
            }

            return default;
        }
    }
}