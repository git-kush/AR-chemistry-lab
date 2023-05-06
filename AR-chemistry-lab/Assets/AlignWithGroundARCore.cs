using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AlignWithGroundARCore : MonoBehaviour
{
    public ARSessionOrigin m_SessionOrigin;
    private Quaternion m_DeviceRotation;

    private void Awake()
    {
        m_SessionOrigin = GetComponent<ARSessionOrigin>();
    }

    private void Update()
    {
        m_DeviceRotation = m_SessionOrigin.camera.transform.rotation;
        transform.rotation = Quaternion.Euler(90f, m_DeviceRotation.eulerAngles.y, 0f);
    }
}
