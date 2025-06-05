using UnityEngine;

namespace Unbind
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float sensitivity;
        [SerializeField] private Camera playerCamera;

        private float rotationX = 0f;

        void Start()
        {
            Globals.Instance.InputReader.PlayerLook += Look;
        }

        private void Look(Vector2 mouseDelta)
        {
            if (!GameManager.cursorLocked) return;

            Vector3 cameraRotationDelta = mouseDelta * sensitivity * Time.deltaTime;
            transform.Rotate(Vector3.up * cameraRotationDelta.x);

            rotationX -= cameraRotationDelta.y;
            rotationX = Mathf.Clamp(rotationX, -90f, 90f);

            Vector3 cameraRotation = new Vector3(rotationX, playerCamera.transform.localEulerAngles.y, playerCamera.transform.localEulerAngles.z);
            playerCamera.transform.localRotation = Quaternion.Euler(cameraRotation);
        }
    }
}
