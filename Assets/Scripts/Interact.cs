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
    public GameObject glassIcon, xGlassIcon;
    public GameObject text;
    public GameObject text2;
    public GameObject text3, finalDoorText;
    public bool isCarryingWater = false;
    public bool waterIsWorking = false;
    public bool textIsOnScreen = false;
    public GameObject fireplaceKey;
    public GameObject waterTankKey;
    public GameObject secretCompartmentKey;
    public GameObject normalWater;
    public GameObject fallingWater, kitchenWater;
    public GameObject kitchenTable;
    public GameObject normalTable;
    public GameObject painting;
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
    public ScriptTesteImagemController imagePuzzle;
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
        if(Input.GetKeyDown(KeyCode.Mouse0))
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

                    //Debug.Log("Colidi");
                    //player.ChangeCameraStateTrue();
                   

                }

                else if (hit.collider.CompareTag("FinalDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                        return;

                    if (Inventory.keys[doorScript.index] == true && soundEmitter >= 4 && imagePuzzle.valorFinal == 5)
                    {
                        doorScript.ChangeDoorState();
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Play("LockedDoor");
                        if (!textIsOnScreen)
                        {
                            textIsOnScreen = true;
                            finalDoorText.SetActive(true);
                            StartCoroutine(WaitForSec());
                        }
                    }

                    Debug.Log("Colidi");
                    //player.ChangeCameraStateTrue();


                }
                else if (hit.collider.CompareTag("Key"))
                {
                    Inventory.keys[hit.collider.GetComponent<KeyScript>().index] = true;
                    if (!textIsOnScreen)
                    {
                        textIsOnScreen = true;
                        uiObject.SetActive(true);
                        StartCoroutine("WaitForSec");
                    }
                    //Debug.Log("ColidiCarai");
                    //Destroy(gameObject);
                    FindObjectOfType<AudioManager>().Play("GetKey");

                    KeyScript keyScript = hit.collider.transform.GetComponent<KeyScript>();
                    keyScript.DestroyKey();
                    keys++;
                }

                //Interactable intercactable = hit.collider.GetComponent<Interactable>();

                else if(hit.collider.CompareTag("AnimInteractable"))
                {
                    PlayAnimation animation = hit.collider.transform.GetComponent<PlayAnimation>();
                    animation.AnimPlay();
                    Debug.Log("TaFuncionando"); //Não ta funcionando ;-; T-T
                }

                else if (hit.collider.CompareTag("Sink") && isCarryingWater == false)
                {
                    if (waterIsWorking)
                    {
                        isCarryingWater = true;
                        Debug.Log("PEGUEI A AGUA");
                        if (!textIsOnScreen)
                        {
                            textIsOnScreen = true;
                            uiObject2.SetActive(true);
                            StartCoroutine("WaitForSec");
                        }
                        glassIcon.SetActive(true);
                        trigger2.SetActive(true);
                    }
                    else
                    {
                        if (!textIsOnScreen)
                        {
                            textIsOnScreen = true;
                            uiObject3.SetActive(true);
                            StartCoroutine("WaitForSec");
                        }
                    }
                }

                else if(hit.collider.CompareTag("Fire"))
                {
                    if (isCarryingWater == true)
                    {
                        FireScript fireParticles = hit.collider.transform.GetComponent<FireScript>();
                        fireParticles.DestroyFire();
                        Debug.Log("APAGUEI O FOGO");
                        glassIcon.SetActive(false);
                        xGlassIcon.SetActive(true);
                        fireplaceKey.SetActive(true);
                        isCarryingWater = false;
                    }

                    else
                    {
                        if (!textIsOnScreen)
                        {
                            textIsOnScreen = true;
                            text3.SetActive(true);
                            StartCoroutine("WaitForSec");
                        }
                    }
                }

                else if(hit.collider.CompareTag("Regulator") && waterIsWorking == false)
                {
                    waterIsWorking = true;
                    Debug.Log("LIGUEI O REGISTRO");
                    if (!textIsOnScreen)
                    {
                        textIsOnScreen = true;
                        text.SetActive(true);
                        StartCoroutine("WaitForSec");
                    }
                    kitchenTable.SetActive(true);
                    normalTable.SetActive(false);
                    kitchenWater.SetActive(true);
                    //PoisonedWaterScript blackWater = hit.collider.transform.GetComponent<PoisonedWaterScript>();
                    //blackWater.DestroyWater();
                    //Debug.Log("RIP AGUA DA MORTE");
                    //waterTankKey.SetActive(true);
                    //normalWater.SetActive(true);
                    //fallingWater.SetActive(true);
                }

                else if(hit.collider.CompareTag("PoisonedWater"))
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
                        if (!textIsOnScreen)
                        {
                            textIsOnScreen = true;
                            text2.SetActive(true);
                            StartCoroutine("WaitForSec");
                        }
                    }

                }

                else if(hit.collider.CompareTag("MovableFloor"))
                {
                    FloorScript floor = hit.collider.transform.GetComponent<FloorScript>();
                    floor.DestroyFloor();
                    //secretCompartmentKey.SetActive(true);
                }

                else if(hit.collider.CompareTag("Text"))
                {
                    PrintMessage text = hit.collider.transform.GetComponent<PrintMessage>();

                    if (!textIsOnScreen)
                    {
                        textIsOnScreen = true;
                        text.ShowText();
                        StartCoroutine(WaitForSec());
                    }
                    //text.TextOnScreen();
                }

               // if (hit.collider.gameObject.name == "Boiler")
               // {
                   // boiler.SetActive(false);
                //}

                else if (hit.collider.CompareTag("RightDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                    {
                        return;
                    }
                    else
                    {
                        doorScript.PuzzleDoor();
                        pm.canMove = false;
                        StartCoroutine(WrongDoorEvent());
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                        FindObjectOfType<AudioManager>().Play("Right");
                        doorScript.ChangeGroup();
                    }

                    //player.ChangeCameraStateTrue();
                }

                else if (hit.collider.CompareTag("WrongDoor"))
                {
                    DoorScript doorScript = hit.collider.transform.parent.GetComponent<DoorScript>();

                    if (doorScript == null)
                    {
                        return;
                    }
                    else
                    {
                        Debug.Log(pm.transform.position);
                        doorScript.PuzzleDoor();
                        pm.canMove = false;
                        StartCoroutine(WrongDoorEvent());
                        FindObjectOfType<AudioManager>().Play("OpenDoor");
                        FindObjectOfType<AudioManager>().Play("Wrong");
                        //pm.SetPlayerSpeed(5);
                    }

                    //player.ChangeCameraStateTrue();
                }

                else if(hit.collider.CompareTag("SoundPuzzle"))
                {
                    Inventory.soundPuzzleObjects[hit.collider.GetComponent<SoundPuzzleScript>().index] = true;

                    SoundPuzzleScript soundPuzzle = hit.collider.transform.GetComponent<SoundPuzzleScript>();
                    soundPuzzle.ActivateIcon();
                    soundPuzzle.AddIndex();
                    soundPuzzle.DestroyObject();
                    uiObject4.SetActive(true);
                    FindObjectOfType<AudioManager>().Play("GetKey");
                    StartCoroutine("WaitForSec");
                   // soundEmitter++;
                }

                else if(hit.collider.CompareTag("NoiseEmitter"))
                {
                    NoiseEmitterScript noiseEmitterScript = hit.collider.transform.GetComponent<NoiseEmitterScript>();

                    if (noiseEmitterScript == null)
                        return;


                    if (Inventory.soundPuzzleObjects[noiseEmitterScript.index] == true)
                    {
                        soundEmitter++;
                        noiseEmitterScript.ActivateObject();
                        print(soundEmitter);
                        FindObjectOfType<AudioManager>().Play("Right");
                    }
                }
                // =======================Xylophone========================
                
                if(hit.collider.name == "XyloA")
                {
                    FindObjectOfType<AudioManager>().Play("XyloA");
                }

                if (hit.collider.name == "XyloB")
                {
                    FindObjectOfType<AudioManager>().Play("XyloB");
                }

                if (hit.collider.name == "XyloC")
                {
                    FindObjectOfType<AudioManager>().Play("XyloC");
                }

                if (hit.collider.name == "XyloD")
                {
                    FindObjectOfType<AudioManager>().Play("XyloD");
                }

                if (hit.collider.name == "XyloE")
                {
                    FindObjectOfType<AudioManager>().Play("XyloE");
                }

                if (hit.collider.name == "XyloF")
                {
                    FindObjectOfType<AudioManager>().Play("XyloF");
                }

                if (hit.collider.name == "XyloG")
                {
                    FindObjectOfType<AudioManager>().Play("XyloG");
                }
            }
        }

        if(soundEmitter == 4)
        {
            painting.SetActive(true);
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);
        textIsOnScreen = false;
        uiObject.SetActive(false);
        uiObject2.SetActive(false);
        uiObject3.SetActive(false);
        uiObject4.SetActive(false);
        text.SetActive(false);
        text2.SetActive(false);
        text3.SetActive(false);
        finalDoorText.SetActive(false);
        //player.ChangeCameraStateFalse();
    }

    IEnumerator WrongDoorEvent()
    {
        print("wrongDoorEvent");
        yield return new WaitForSeconds(2);
        character.transform.position = spawner.transform.position;
        character.transform.rotation = spawner.transform.rotation;
        FindObjectOfType<AudioManager>().Play("Slam");
        yield return new WaitForSeconds(1);
        pm.canMove = true;
        Debug.Log(pm.transform.position);
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
