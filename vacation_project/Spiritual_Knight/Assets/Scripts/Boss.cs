using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public UISlider ui_boss_hp_bar;
    public GameObject pre;
    public GameObject[] pattern;
    private Animator ani;
    public enum Boss_Pattern
    {
        earthquake,
        groundSpawn,
        trapSpawn
    }

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

    private void Update()
    {
        ui_boss_hp_bar.value = boss_hp / 4000;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ani.SetBool("Attack1", true);
            StartCoroutine(Attack());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Attack")
        {
            ani.SetTrigger("Hit");
            Boss_hp = boss_hp - Player.attack_dmg;
            if(Boss_hp <= 0)
            {
                ani.SetBool("Dead", true);
                enabled = false;
            }
        }
    }
    IEnumerator Boss_Random_Pattern()
    {

        yield return null;
    }
    IEnumerator Attack()
    {
        while(true)
        {
            if(GetComponent<SpriteRenderer>().sprite.name == "GR_Attack1_04")
            {
                GameObject a = Instantiate(pre, transform.position, Quaternion.identity);
                if(Player.isGround)
                {
                    Player.Hp_bar = Player.Hp_bar - 10.0f;
                }
                yield return new WaitForSeconds(0.9f);
                Destroy(a);
                ani.SetBool("Attack1", false);
            }
            yield return null;
        }
    }
}
