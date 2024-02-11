using UnityEngine;

public class cameraPlayer : MonoBehaviour
{
    public float sensivity = 5f;

    [SerializeField] private Camera player;
    [SerializeField] private GameObject playerGameObject;
    [SerializeField] private float smoothTime = 0.05f;

    private float xRot;
    private float yRot;
    private float xRotCurrent;
    private float yRotCurrent;
    private float currentVelosityX;
    private float currentVelosityY;
    private float shakeAmount = 0.5f;
    private float speedShake = 1f;
    private float shakeDistation;
    private Vector3 shakePos;
    private Vector3 shakeRotation = Vector3.zero;
    private FreezePlayer _freezePlayerComponent;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        shakePos = transform.position;

        _freezePlayerComponent = gameObject.GetComponent<cameraPlayer>().transform.parent.GetComponent<FreezePlayer>();

        if (_freezePlayerComponent != null) { 
            _freezePlayerComponent.ToRotate += CameraRotate;
        }
    }

    private void OnDestroy()
    {
        _freezePlayerComponent.ToRotate -= CameraRotate;
    }

    private void CameraRotate()
    {
        xRot += Input.GetAxis("Mouse X") * sensivity;
        yRot += Input.GetAxis("Mouse Y") * sensivity;
        yRot = Mathf.Clamp(yRot, -60, 60);

        xRotCurrent = Mathf.SmoothDamp(xRotCurrent, xRot, ref currentVelosityX, smoothTime);
        yRotCurrent = Mathf.SmoothDamp(yRotCurrent, yRot, ref currentVelosityY, smoothTime);
        playerGameObject.transform.rotation = Quaternion.Euler(0f, xRotCurrent, 0f);
        player.transform.rotation = Quaternion.Euler(-yRotCurrent, xRotCurrent, 0f);

        shakeDistation += (transform.position - shakePos).magnitude;
        shakePos = transform.position;
        shakeRotation.x = Mathf.Sin(shakeDistation * speedShake) * shakeAmount;
        transform.localEulerAngles += shakeRotation;
    }

    public void CameraToLookAsPoint(Transform point)
    {
    }
}