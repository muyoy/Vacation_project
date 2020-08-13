using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject attack_sprite;

    GameObject attack;
    GameObject level_design_1;
    GameObject level_design_2;
    Vector2 attack_vector;
    Rigidbody2D player;
    SpriteRenderer character_flip;
    Animator ani;
    public UISlider ui_hp_bar;
    
    public float move_speed;
    public float jump_power;
    public float jump_time;
    public float attack_cool_setting;

    private bool isGround;
    private bool isJumping;
    private bool isDmg = true;
    private float jump_time_counter;
    private float attack_cool;

    private float speed;

    [SerializeField]
    private float hp_bar;
    public float Hp_bar
    {
        get { return hp_bar; }
        set { hp_bar = value; }
    }
    void Start()
    {
        level_design_1 = GameObject.Find("UI Root").transform.Find("Modal").gameObject;
        level_design_2 = GameObject.Find("UI Root").transform.Find("Modal_1").gameObject;
        player = GetComponent<Rigidbody2D>();
        character_flip = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }
    private void Update()
    {
        if (!player.IsAwake())
        {
            player.WakeUp();
        }

        if(hp_bar < 0)
        {
            ani.SetBool("Dead", true);
            GetComponent<Player>().enabled = false;
        }

        if (isGround == true && Input.GetKeyDown(KeyCode.Z))
        {
            ani.SetBool("Jump", true);
            isJumping = true;
            jump_time_counter = jump_time;
            player.velocity = new Vector2(player.velocity.x, jump_power);
        }
        if(isJumping == true && Input.GetKey(KeyCode.Z))
        {
            if (jump_time_counter > 0)
            {
                ani.SetBool("Jump", true);
                player.velocity = new Vector2(player.velocity.x, jump_power);
                jump_time_counter -= Time.deltaTime;
            }
            else if (jump_time_counter < 0)
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Z))
            isJumping = false;
    }
    private void FixedUpdate()
    {
        speed = Input.GetAxis("Horizontal");
        ani.SetFloat("Speed", Mathf.Abs(speed));

        player.velocity = new Vector2(speed * move_speed, player.velocity.y);
        if (speed > 0)
            character_flip.flipX = true;
        if (speed < 0)
            character_flip.flipX = false;

        if (Input.GetKeyDown(KeyCode.X) && attack_cool <= 0 && isGround)
        {
            Attack();
            ani.SetTrigger("Attack");
            attack_cool = attack_cool_setting;
        }
        attack_cool -= Time.deltaTime;
    }

    void Attack()
    {
        attack_vector = transform.Find("Attack_Postion").position;
        if (character_flip.flipX)
        {
            attack = Instantiate(attack_sprite, attack_vector, Quaternion.identity);
            attack.transform.localScale = Vector3.one;
            attack.GetComponent<Rigidbody2D>().velocity = new Vector2(15.0f, 0.0f);
        }
        else
        {
            attack = Instantiate(attack_sprite, attack_vector, Quaternion.identity);
            attack.transform.localScale = new Vector3(-1, 1, 1);
            attack.GetComponent<Rigidbody2D>().velocity = new Vector2(-15.0f, 0.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Trap" && isDmg)
        { 
            Hp_bar = hp_bar - 0.000001f;
            Debug.Log(hp_bar.ToString());
            ui_hp_bar.value = hp_bar/100;

            StartCoroutine(HIT());
        }

        if(other.gameObject.tag == "Level_Design_1")
        {
            GetComponent<Player>().enabled = false;
            level_design_1.SetActive(true);
            Destroy(other, 1.0f);
        }

        if (other.gameObject.tag == "Level_Design_2")
        {
            player.velocity = new Vector2(0, 0);
            GetComponent<Player>().enabled = false;
            level_design_2.SetActive(true);
            Destroy(other, 1.0f);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Trap" && isDmg)
        {
            Hp_bar = hp_bar - 0.000001f;
            Debug.Log(hp_bar.ToString());
            ui_hp_bar.value = hp_bar / 100;

            StartCoroutine(HIT());
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ani.SetBool("Jump", false);
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    IEnumerator HIT()
    {
        int i = 0;
        isDmg = false;
        Color color = GetComponent<SpriteRenderer>().color;
        while (i < 3)
        {
            color.a = 0;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.1f);
            color.a = 1f;
            GetComponent<SpriteRenderer>().color = color;
            yield return new WaitForSeconds(0.1f);
            i++;
        }

        color.a = 1f;
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(1.0f);
        isDmg = true;
    }
}

/*미안하다 이거 보여주려고 어그로끌었다..나루토 사스케 싸움수준 ㄹㅇ실화냐? 
진짜 세계관최강자들의 싸움이다.. 그찐따같던 나루토가 맞나? 진짜 나루토는 전설이다..
진짜옛날에 맨날나루토봘는데 왕같은존재인 호카게 되서 세계최강 전설적인 영웅이된나루토보면 
진짜내가다 감격스럽고 나루토 노래부터 명장면까지 가슴울리는장면들이 뇌리에 스치면서 가슴이 웅장해진다.. 
그리고 극장판 에 카카시앞에 운석날라오는 거대한 걸 사스케가 갑자기 순식간에 나타나서 부숴버리곤 개간지나게 나루토가 
없다면 마을을 지킬 자는 나밖에 없다 라며 바람처럼 사라진장면은 진짜 나루토처음부터 본사람이면 안울수가없더라 진짜 너무 감격스럽고 
보루토를 최근에 알았는데 미안하다.. 지금20화보는데 진짜 나루토세대나와서 너무 감격스럽고 모두어엿하게 큰거보니 내가 다 뭔가 알수없는 추억이라해야되나 
그런감정이 이상하게 얽혀있다..시노는 말이많아진거같다 좋은선생이고..그리고 보루토왜욕하냐 귀여운데 나루토를보는것같다 
성격도 닮았어 그리고버루토에 나루토사스케 둘이싸워도 이기는 신같은존재 나온다는게 사실임?? 그리고인터닛에 쳐봣는디 이거 ㄹㅇㄹㅇ 진짜팩트냐?? 
저적이 보루토에 나오는 신급괴물임?ㅡ 나루토사스케 합체한거봐라 진짜 ㅆㅂ 이거보고 개충격먹어가지고 와 소리 저절로 나오더라 ;; 진짜 저건 개오지는데..
저게 ㄹㅇ이면 진짜 꼭봐야돼 진짜 세계도 파괴시키는거아니야..와 진짜 나루토사스케가 저렇게 되다니 진짜 눈물나려고했다..버루토그라서 계속보는중인데 저거 ㄹㅇ이냐..? 
 하..ㅆㅂ 사스케 보고싶다..진짜언제 이렇게 신급 최강들이 되었을까 옛날생각나고 나 중딩때생각나고 뭔가 슬프기도하고 좋기도하고 감격도하고 여러가지감정이 복잡하네.. 
아무튼 나루토는 진짜 애니중최거명작임.. -기획자 박종관*/
