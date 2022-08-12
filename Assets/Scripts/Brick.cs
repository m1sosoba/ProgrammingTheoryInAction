using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Brick : MonoBehaviour
{
    public UnityEvent<int> onDestroyed;

    void Start()
    {

    }

    //Polymorhism
    protected virtual void OnCollisionEnter(Collision other)
    {
        //slight delay to be sure the ball have time to bounce
        Destroy(gameObject, 0.2f);
    }
}
