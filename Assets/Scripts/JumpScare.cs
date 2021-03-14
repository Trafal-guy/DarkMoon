using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{
    public AudioSource sound;
    //public PlayerMovement player;
    public GameObject jumpscareCam;
    public GameObject flashImg;

    private void OnTriggerEnter()
    {
        //sound.Play();
        jumpscareCam.SetActive(true);
        //player.speed = 5;
        flashImg.SetActive(true);
        StartCoroutine(EndJumpscare());
    }

    IEnumerator EndJumpscare()
    {
        yield return new WaitForSeconds(2.1f);
        //player.speed = 0;
        jumpscareCam.SetActive(false);
        flashImg.SetActive(false);
        Destroy(gameObject);
    }
}
