using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_04_Attack : MonoBehaviour
{
    public GameObject leaf;
    private GameObject leaf_Attack;
    private Vector2 leaf_trans;
    void Start()
    {
        leaf_trans = transform.Find("Trap_04_Leaf").position;
        StartCoroutine(Trap_Attack());
    }

    IEnumerator Trap_Attack()
    {
        while (true)
        {
            if (GetComponent<SpriteRenderer>().sprite.name == "Trap_04_05")
            {
                leaf_Attack = Instantiate(leaf, leaf_trans, Quaternion.identity);
                leaf_Attack.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, -20.0f);
                yield return new WaitForSeconds(1.0f);
                Destroy(leaf_Attack);
            }

            yield return null;
        }
    }
}
