using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //Encapsulation
    private float m_speed = 4.0f;
    public float speed
    {
        get { return m_speed; }
        set
        {
            if (value > 0)
            {
                m_speed = value;
            }
            else
            {
                m_speed = 1;
            }
        }
    }
    public float MaxMovement = 2.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }
    //Abstraction
    void MovePaddle()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * m_speed * Time.deltaTime;

        if (pos.x > MaxMovement)
            pos.x = MaxMovement;
        else if (pos.x < -MaxMovement)
            pos.x = -MaxMovement;

        transform.position = pos;
    }
}
