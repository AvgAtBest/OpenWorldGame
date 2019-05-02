using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public Transform attachedCamera;
    public bool isCursorHiden = true;
    public float minPitch = -80f, maxPitch = 80f;
    public Vector2 speed = new Vector2(120f, 120f);

    private Vector2 euler;
    // Start is called before the first frame update
    void Start()
    {
        //is the cursor supposed to be hidden?
        if (isCursorHiden)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        euler = transform.eulerAngles;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        euler.y += Input.GetAxis("Mouse X") * speed.x * Time.deltaTime;
        euler.x -= Input.GetAxis("Mouse Y") * speed.y * Time.deltaTime;

        euler.x = Mathf.Clamp(euler.x, minPitch, maxPitch);

        transform.localEulerAngles = new Vector3(0f, euler.y, 0f);
        attachedCamera.localEulerAngles = new Vector3(euler.x, 0f, 0f);
    }
}
