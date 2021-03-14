using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    //public char animName;
    //public PlayerMovement player;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void AnimPlay()
    {
        anim.SetBool("PlayerInteracted", true);
    }
}
