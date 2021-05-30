using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float speed;

    [SerializeField] private float walkSpeed, runSpeed, crouchSpeed;
    [SerializeField] private float runBuildUpSpeed;
    [SerializeField] private KeyCode runKey;

    [SerializeField] private float slopeForce;
    [SerializeField] private float slopeForceRayLength;

    [SerializeField] private KeyCode crouchKey = KeyCode.C;
    private bool isCrouching = false;
    public bool canMove = true;
    private float originalHeight;
    [SerializeField] private float crouchHeight = 0.5f;

    private CharacterController charController;
    [SerializeField] private GameObject ghost, ghost2, ghost3;
    [SerializeField] private GameObject trigger, trigger1, trigger2, trigger3, trigger4, corridorTrigger1, corridorTrigger2, spotlightsTrigger;
    [SerializeField] private PlayerCamera camera;
    [SerializeField] private GameObject chairs, diningTable, modernTable, door, spotlights;
    [SerializeField] private DoorScript doorScript;
    [SerializeField] private ScriptTesteImagemController stic;


    private void Awake()
    {
        charController = GetComponent<CharacterController>();
        originalHeight = charController.height;
        //doorScript = GetComponent<DoorScript>();
    }

    private void Update()
    {
        if (canMove)
        {
            CharacterMovement();

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                FindObjectOfType<AudioManager>().Play("Walk");
            else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D))
                FindObjectOfType<AudioManager>().Stop("Walk");
        }
    }

    private void CharacterMovement()
    {
        float horizontalInput = Input.GetAxis(horizontalInputName);
        float verticalInput = Input.GetAxis(verticalInputName);

        Vector3 forwardMovement = transform.forward * verticalInput;
        Vector3 rightMovement = transform.right * horizontalInput;


        charController.SimpleMove(Vector3.ClampMagnitude(forwardMovement + rightMovement, 1.0f) * speed);

        if ((verticalInput != 0 || horizontalInput != 0) && OnSlope())
            charController.Move(Vector3.down * charController.height / 2 * slopeForce * Time.deltaTime);

        //Arrumar depois
        //SetMovementSpeed();
        //fim arrumar depois

        //FindObjectOfType<AudioManager>().Play("Walk");

        if(Input.GetKeyDown(crouchKey))
        {
            isCrouching = !isCrouching;

            Crouch();
        }
    }

    private bool OnSlope()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, charController.height / 2 * slopeForceRayLength))
            if (hit.normal != Vector3.up)
                return true;

        return false;
    }

    private void SetMovementSpeed()
    {
        if (Input.GetKey(runKey))
            speed = Mathf.Lerp(speed, runSpeed, Time.deltaTime * runBuildUpSpeed);
        else if (Input.GetKeyDown(crouchKey))
            speed = Mathf.Lerp(speed, crouchSpeed, Time.deltaTime * runBuildUpSpeed);
        else
            speed = Mathf.Lerp(speed, walkSpeed, Time.deltaTime * runBuildUpSpeed);

        //FindObjectOfType<AudioManager>().Play("Walk");
    }

    public void SetPlayerSpeed(int newSpeed)
    {
        speed = newSpeed;
    }

    private void Crouch()
    {
        if(isCrouching)
        {
            charController.height = crouchHeight;
        }

        else
        {
            charController.height = originalHeight;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "BathroomJumpscareTrigger")
        {
            ghost.SetActive(true);
            canMove = false;
            FindObjectOfType<AudioManager>().Play("Scream");
            Destroy(trigger);
            Debug.Log("JUMPSCARE");
            camera.ChangeCameraStateTrue();
            StartCoroutine("JumpscareTimer");
        }

        if(collision.gameObject.name == "LivingRoomGhostTrigger")
        {
            ghost2.SetActive(true);
            Destroy(trigger1);
        }

        if(collision.gameObject.name == "KitchenGhostTrigger")
        {
            ghost3.SetActive(true);
            Destroy(trigger2);
        }

        if(collision.gameObject.name == "BedroomKnockingJumpscareTrigger")
        {
            FindObjectOfType<AudioManager>().Play("Knock");
            Destroy(trigger3);
        }

        if(collision.gameObject.name == "ChairsTrigger")
        {
            chairs.SetActive(true);
            diningTable.SetActive(false);
            modernTable.SetActive(true);
            Destroy(trigger4);
        }
        if (collision.gameObject.name == "WinConditionTrigger")
            SceneManager.LoadScene("Menu");

        if(collision.gameObject.name == "CorridorTrigger1" || collision.gameObject.name == "CorridorTrigger2")
        {
            if(doorScript.open == true)
            {
                doorScript.ChangeDoorState();
                FindObjectOfType<AudioManager>().Play("Slam");
                StartCoroutine(LockDoor());
                StartCoroutine(DestroyDoor());
            }
            else
            {
                StartCoroutine(LockDoor());
                StartCoroutine(DestroyDoor());
            }

            corridorTrigger1.SetActive(false);
            corridorTrigger2.SetActive(false);
            spotlightsTrigger.SetActive(true);

        }

        if(collision.gameObject.name == "SpotlightsTrigger" && stic.valorFinal != 5)
        {
            spotlights.SetActive(true);
            FindObjectOfType<AudioManager>().Play("BigSwitch");
            Destroy(spotlightsTrigger);
        }
    }

    IEnumerator JumpscareTimer()
    {
        yield return new WaitForSeconds(2);
        camera.ChangeCameraStateFalse();
        canMove = true;
    }

    IEnumerator LockDoor()
    {
        yield return new WaitForSeconds(1);
        FindObjectOfType<AudioManager>().Play("Lock");
    }

    IEnumerator DestroyDoor()
    {
        yield return new WaitForSeconds(1);
        doorScript.Destroy();
        door.SetActive(true);
    }
}
