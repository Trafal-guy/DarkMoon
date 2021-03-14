using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour
{
    //[SerializeField] private GameObject Key;

    private void Start()
    {
        //Key.SetActive(false);
    }
    public void DestroyFire()
    {
        //Key.SetActive(true);
        Destroy(gameObject);
    }
}
