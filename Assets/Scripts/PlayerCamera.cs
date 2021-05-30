using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private string mouseXInputName, mouseYInputName;
    [SerializeField] private float mouseSensitivity;
    [SerializeField] private Transform playerBody;
    private bool isLocked = false;

    private float xAxisClamp;

    //testes
    public float length;
    //fim testes

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    //testes
    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    //fim testes

    private void Update()
    {
        if (isLocked == false)
            CameraRotation();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        //testes
        if (Physics.Raycast(ray, out hit, length))
        {
            //if (hit.collider.CompareTag("Key"))
            //{
                //UnlockCursor();
                //Cursor.visible = true;
                //print("cubunda");
           // }
            //else
            //{
                //Cursor.visible = false;
            //}
        }
        //fim testes
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90.0f)
        {
            xAxisClamp = 90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(270.0f);
        }

        if (xAxisClamp < -90.0f)
        {
            xAxisClamp = -90.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(90.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }

    public void ChangeCameraStateTrue()
    {
        isLocked = true;
    }

    public void ChangeCameraStateFalse()
    {
        isLocked = false;
    }
}