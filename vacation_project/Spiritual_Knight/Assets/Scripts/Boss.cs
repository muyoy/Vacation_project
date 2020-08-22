using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator ani;
    public UISlider ui_boss_hp_bar;

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
            ui_boss_hp_bar.value = boss_hp / 200;
            if(Boss_hp <= 0)
            {
                ani.SetBool("Dead", true);
                enabled = false;
            }
        }
    }
}
