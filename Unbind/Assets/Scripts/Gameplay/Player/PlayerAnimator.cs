using UnityEngine;

namespace Unbind
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField]private Animator movementAnimator;
        
        private PlayerMovement movementScript;

        private Vector3 lastPosition;

        private void Start()
        {
            movementScript = GetComponent<PlayerMovement>();
        }

        private void LateUpdate()
        {
            Vector3 positionDelta = transform.position - lastPosition;
            positionDelta.y = 0f;

            movementAnimator.SetFloat("Velocity", positionDelta.sqrMagnitude);
            movementAnimator.SetBool("OnGround", movementScript.onGround);

            lastPosition = transform.position;
        }
    }
}
