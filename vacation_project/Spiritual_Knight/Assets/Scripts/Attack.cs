using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" || other.tag=="wall")
        {
            ani.SetBool("Destory", true);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            
            Destroy(gameObject,1.0f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Ground" || other.tag == "wall")
        {
            ani.SetBool("Destory", true);

            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            Destroy(gameObject, 1.0f);
        }
    }
}
