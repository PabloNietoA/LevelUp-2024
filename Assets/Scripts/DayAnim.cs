using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAnim : MonoBehaviour
{
    public bool fromUp;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("FromUp", fromUp);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
