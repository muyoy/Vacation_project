using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator ani;

    [SerializeField]
    private float boss_hp;
    private float Boss_hp
    {
        get { return boss_hp; }
        set { boss_hp = value; }
    }

    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            ani.SetTrigger("Hit");
            Boss_hp = boss_hp - 100.0f;
            if(Boss_hp <= 0)
            {
                ani.SetBool("Dead", true);
                enabled = false;
            }
        }
    }
}
