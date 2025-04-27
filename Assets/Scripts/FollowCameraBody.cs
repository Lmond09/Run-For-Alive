using UnityEngine;

public class FollowCameraBody : MonoBehaviour
{
    public Transform xrCamera;     // Assign the Main Camera
    public Vector3 positionOffset = new Vector3(0, -1.7f, 0);  // Adjust as needed

    void LateUpdate()
    {
        // Follow camera position + offset
        transform.position = xrCamera.position + positionOffset;

        // Face the same direction (only Y rotation)
        Vector3 cameraEuler = xrCamera.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(0, cameraEuler.y, 0);
    }
}
