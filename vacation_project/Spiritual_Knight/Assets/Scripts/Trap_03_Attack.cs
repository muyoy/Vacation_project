using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_03_Attack : MonoBehaviour
{
    public GameObject seed;
    private GameObject seed_Attack;
    private Vector2 seed_trans;
    void Start()
    {
        seed_trans = transform.Find("Trap_03_Seed").position;
        StartCoroutine(Trap_Attack());
    }

    IEnumerator Trap_Attack()
    {
        while(true)
        {
            if(GetComponent<SpriteRenderer>().sprite.name == "Trap_01_05")
            {
                seed_Attack = Instantiate(seed, seed_trans, Quaternion.identity);
                if(GetComponent<SpriteRenderer>().flipX)
                {
                    seed_Attack.GetComponent<Rigidbody2D>().velocity = new Vector2(20.0f, 0.0f);
                }
                else
                {
                    seed_Attack.GetComponent<Rigidbody2D>().velocity = new Vector2(-20.0f, 0.0f);
                }
                yield return new WaitForSeconds(1.0f);
                Destroy(seed_Attack);
            }

            yield return null;
        }
    }

}
