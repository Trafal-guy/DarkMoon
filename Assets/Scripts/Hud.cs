using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hud : MonoBehaviour
{
    //public int keys = 0;
    public Text numberofkeys;
    [SerializeField] private Interact player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        numberofkeys.text = player.keys.ToString() + "/6";
    }
}
