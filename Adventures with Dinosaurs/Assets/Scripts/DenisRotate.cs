using UnityEngine;

public class DenisRotate : MonoBehaviour
{
    float mouseSense = 1;

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float rotateY = Input.GetAxis("Mouse X") * mouseSense;
        float rotateX = Input.GetAxis("Mouse Y") * mouseSense;
        Vector3 rotPlayer = transform.rotation.eulerAngles;

        rotPlayer.z += rotateX;
        rotPlayer.y += rotateY;


        transform.rotation = Quaternion.Euler(rotPlayer);
    }
}