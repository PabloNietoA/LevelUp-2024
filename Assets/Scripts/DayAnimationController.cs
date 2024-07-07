using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAnimationController : MonoBehaviour
{

    public bool IsTop;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().SetBool("IsTop", IsTop);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
