using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
public class StrongBrick : Brick
{
    private int life = 3;

    //Polymorhism
    protected override void OnCollisionEnter(Collision other)
    {
        life--;
        if (life < 1)
        {
            //slight delay to be sure the ball have time to bounce
            Destroy(gameObject, 0.2f);
        }
    }
}
