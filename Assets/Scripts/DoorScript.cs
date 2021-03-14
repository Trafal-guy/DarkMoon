using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public bool open = false;
    [SerializeField] private float doorOpenAngle;
    [SerializeField] private float doorClosedAngle;
    [SerializeField] private float smooth;
    public int index;

    private void Start()
    {
        
    }

    public void ChangeDoorState()
    {
        open = !open;
    }

    private void Update()
    {
        if (open)
        {
            Quaternion targetRotation = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);
            //FindObjectOfType<AudioManager>().Play("OpenDoor");
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, smooth * Time.deltaTime);
            //FindObjectOfType<AudioManager>().Play("OpenDoor");
        }
    }
}
