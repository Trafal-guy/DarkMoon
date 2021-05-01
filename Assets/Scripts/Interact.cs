using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interact : MonoBehaviour
{
    public float length;
    public GameObject uiObject;
    public GameObject uiObject2;
    public GameObject uiObject3;
    public GameObject uiObject4;
    public GameObject text;
    public GameObject text2;
    public GameObject text3;
    public bool isCarryingWater = false;
    public bool waterIsWorking = false;
    private bool textIsOnScreen = false;
    public GameObject fireplaceKey;
    public GameObject waterTankKey;
    public GameObject secretCompartmentKey;
    public GameObject normalWater;
    public GameObject fallingWater;
    public GameObject kitchenTable;
    public GameObject normalTable;
    public PlayerCamera player;
    public GameObject ghost, ghost2, ghost3;
    public GameObject trigger, trigger2, trigger3;
    //public GameObject phone, tv, clock, boiler;
    public Text numberOfKeys;
    public int keys;
    public int soundEmitter;


    //testes
    public GameObject character;
    private PlayerMovement pm;
    public GameObject spawner;
    //fim testes
    
    // Start is called before the first frame update
    void Start()
    {
        //testes
        pm = character.GetComponent<PlayerMovement>();
        //fim testes

        uiObject.SetActive(false);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);
        fireplaceKey.SetActive(false);
        waterTankKey.SetActive(false);
        text.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        //secretCompartmentKey.SetActive(false);
        normalWater.SetActive(false);
        fallingWater.SetActive(false);
        kitchenTable.SetActive(false);
        ghost.SetActive(false);
        ghost2.SetActive(false);
        ghost3.SetActive(false);
        trigger2.SetActive(false);
        //trigger3.SetActive(false);
        numberOfKeys = GetComponent<Text>();
        keys = 0;
        soundEmitter = 0;
        //boiler.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //numberOfKeys.text = keys.ToString();
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, length))
            {

                if(hit.collider.CompareTag("Door"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                        return;

                    if (Inventory.keys[doorScript.index] == true)
                    {
                        doorScript.ChangeDoorState();
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                    }
                    else
                        FindObjectOfType<AudioManager>().Play("LockedDoor");

                    Debug.Log("Colidi");
                    //player.ChangeCameraStateTrue();
                   

                }

                if (hit.collider.CompareTag("FinalDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                        return;

                    if (Inventory.keys[doorScript.index] == true && soundEmitter >=4)
                    {
                        doorScript.ChangeDoorState();
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                    }
                    else
                        FindObjectOfType<AudioManager>().Play("LockedDoor");

                    Debug.Log("Colidi");
                    //player.ChangeCameraStateTrue();


                }
                if (hit.collider.CompareTag("Key"))
                {
                    Inventory.keys[hit.collider.GetComponent<KeyScript>().index] = true;
                    uiObject.SetActive(true);
                    StartCoroutine("WaitForSec");
                    //Debug.Log("ColidiCarai");
                    //Destroy(gameObject);
                    FindObjectOfType<AudioManager>().Play("GetKey");

                    KeyScript keyScript = hit.collider.transform.GetComponent<KeyScript>();
                    keyScript.DestroyKey();
                    keys++;
                }

                //Interactable intercactable = hit.collider.GetComponent<Interactable>();

                if(hit.collider.CompareTag("AnimInteractable"))
                {
                    PlayAnimation animation = hit.collider.transform.GetComponent<PlayAnimation>();
                    animation.AnimPlay();
                    Debug.Log("TaFuncionando"); //Não ta funcionando ;-; T-T
                }

                if (hit.collider.CompareTag("Sink") && isCarryingWater == false)
                {
                    if (waterIsWorking)
                    {
                        isCarryingWater = true;
                        Debug.Log("PEGUEI A AGUA");
                        uiObject2.SetActive(true);
                        StartCoroutine("WaitForSec");
                        trigger2.SetActive(true);
                    }
                    else
                    {
                        uiObject3.SetActive(true);
                        StartCoroutine("WaitForSec");
                    }
                }

                if(hit.collider.CompareTag("Fire"))
                {
                    if (isCarryingWater == true)
                    {
                        FireScript fireParticles = hit.collider.transform.GetComponent<FireScript>();
                        fireParticles.DestroyFire();
                        Debug.Log("APAGUEI O FOGO");
                        fireplaceKey.SetActive(true);
                        isCarryingWater = false;
                    }

                    else
                    {
                        text3.SetActive(true);
                        StartCoroutine("WaitForSec");
                    }
                }

                if(hit.collider.CompareTag("Regulator") && waterIsWorking == false)
                {
                    waterIsWorking = true;
                    Debug.Log("LIGUEI O REGISTRO");
                    text.SetActive(true);
                    StartCoroutine("WaitForSec");
                    kitchenTable.SetActive(true);
                    normalTable.SetActive(false);
                    //PoisonedWaterScript blackWater = hit.collider.transform.GetComponent<PoisonedWaterScript>();
                    //blackWater.DestroyWater();
                    //Debug.Log("RIP AGUA DA MORTE");
                    //waterTankKey.SetActive(true);
                    //normalWater.SetActive(true);
                    //fallingWater.SetActive(true);
                }

                if(hit.collider.CompareTag("PoisonedWater"))
                {
                    if(waterIsWorking)
                    {
                        PoisonedWaterScript blackWater = hit.collider.transform.GetComponent<PoisonedWaterScript>();
                        blackWater.DestroyWater();
                        Debug.Log("RIP AGUA DA MORTE");
                        waterTankKey.SetActive(true);
                        normalWater.SetActive(true);
                        fallingWater.SetActive(true);
                    }

                    else
                    {
                        text2.SetActive(true);
                        StartCoroutine("WaitForSec");
                    }

                }

                if(hit.collider.CompareTag("MovableFloor"))
                {
                    FloorScript floor = hit.collider.transform.GetComponent<FloorScript>();
                    floor.DestroyFloor();
                    //secretCompartmentKey.SetActive(true);
                }

                if(hit.collider.CompareTag("Text"))
                {
                    PrintMessage text = hit.collider.transform.GetComponent<PrintMessage>();
                    text.ShowText();
                    text.TextOnScreen();
                }

               // if (hit.collider.gameObject.name == "Boiler")
               // {
                   // boiler.SetActive(false);
                //}

                if (hit.collider.CompareTag("RightDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                    {
                        return;
                    }
                    else
                    {
                        doorScript.ChangeDoorState();
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                    }

                    //player.ChangeCameraStateTrue();
                }

                if (hit.collider.CompareTag("WrongDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                    {
                        return;
                    }
                    else
                    {
                        doorScript.ChangeDoorState();
                        pm.SetPlayerSpeed(0);
                        StartCoroutine(WrongDoorEvent());
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                        //pm.SetPlayerSpeed(0);
                    }

                    //player.ChangeCameraStateTrue();
                }

                if(hit.collider.CompareTag("SoundPuzzle"))
                {
                    Inventory.soundPuzzleObjects[hit.collider.GetComponent<SoundPuzzleScript>().index] = true;

                    SoundPuzzleScript soundPuzzle = hit.collider.transform.GetComponent<SoundPuzzleScript>();
                    soundPuzzle.AddIndex();
                    soundPuzzle.DestroyObject();
                    uiObject4.SetActive(true);
                    StartCoroutine("WaitForSec");
                   // soundEmitter++;
                }

                if(hit.collider.CompareTag("NoiseEmitter"))
                {
                    NoiseEmitterScript noiseEmitterScript = hit.collider.transform.GetComponent<NoiseEmitterScript>();

                    if (noiseEmitterScript == null)
                        return;


                    if (Inventory.soundPuzzleObjects[noiseEmitterScript.index] == true)
                    {
                        soundEmitter++;
                        noiseEmitterScript.ActivateObject();
                        print(soundEmitter);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        uiObject.SetActive(false);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);
        text.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        //player.ChangeCameraStateFalse();
    }

    IEnumerator WrongDoorEvent()
    {
        yield return new WaitForSeconds(2);
        character.transform.position = spawner.transform.position;
        yield return new WaitForSeconds(1);
        pm.SetPlayerSpeed(5);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("JumpScare"))
        {
            ghost.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Scream");
            Destroy(trigger);
            Debug.Log("JUMPSCARE");
        }
    }
}
