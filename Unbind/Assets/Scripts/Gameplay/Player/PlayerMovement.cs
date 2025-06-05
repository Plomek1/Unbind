using UnityEngine;

namespace Unbind
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool inMotion {  get; private set; }
        public bool onGround {  get; private set; }

        [Header("Movement")]
        [SerializeField] private float movementSpeed;
        [SerializeField] private float jumpHeight;
        [SerializeField] private float gravity;

        [Space(10)]
        [Header("Ground Check")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private float groundCheckSize;
        [SerializeField] private LayerMask groundMask;

        private CharacterController controller;
        private Vector3 movementInputVector;
        private float velocityY;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            Globals.Instance.InputReader.PlayerMove += Move;
            Globals.Instance.InputReader.PlayerJump += Jump;
        }

        private void Move(Vector2 movementInput) => movementInputVector = movementInput;

        private void Jump()
        {
            if (!GameManager.cursorLocked || !onGround) return;
            velocityY = Mathf.Sqrt(jumpHeight * 2 * gravity);
        }

        private void Update()
        {
            Vector3 movementVector = GameManager.cursorLocked ? transform.right * movementInputVector.x + transform.forward * movementInputVector.y : Vector3.zero;
            movementVector *= movementSpeed * Time.deltaTime;

            controller.Move(movementVector);

            inMotion = movementVector.sqrMagnitude > 0;
            onGround = Physics.CheckSphere(groundCheck.position, groundCheckSize, groundMask);


            velocityY = onGround && velocityY < 0 ? -5f : velocityY - gravity * Time.deltaTime;
            
            controller.Move(Vector3.up * velocityY * Time.deltaTime);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckSize);
        }
    }
}
