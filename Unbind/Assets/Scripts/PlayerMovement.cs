using UnityEngine;

namespace Unbind
{
    public class PlayerMovement : MonoBehaviour
    {
        public bool inMotion {  get; private set; }
        public bool onGround {  get; private set; }

        [SerializeField] private float movementSpeed;

        private CharacterController controller;

        private Vector3 movementInputVector;

        private void Start()
        {
            controller = GetComponent<CharacterController>();
            Globals.Instance.inputReader.PlayerMove += Move;
        }

        private void Move(Vector2 movementInput) => movementInputVector = movementInput;

        private void Update()
        {
            Vector3 movementVector = transform.right * movementInputVector.x + transform.forward * movementInputVector.y;
            movementVector *= movementSpeed * Time.deltaTime;

            controller.Move(movementVector);
            inMotion = movementVector.sqrMagnitude > 0;
        }
    }
}
