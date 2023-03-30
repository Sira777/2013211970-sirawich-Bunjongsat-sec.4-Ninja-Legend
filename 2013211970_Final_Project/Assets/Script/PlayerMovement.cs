using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public float speed = 5f;
    public float jump = 5f;

    public bool isGround;
    public bool isMove;
    public LayerMask layerGround;

    public int hp = 3;
    private bool isFlash;

    public static PlayerMovement instance;

    public GameObject footPlayer;

    private void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        FilpSprite();
        CheckGround();
        Jump();
        AnimePlayer();

    }

    void Run()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);
        isMove = Input.GetAxis("Horizontal") != 0;
    }

    void FilpSprite()
    {
        bool filp = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (filp)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(footPlayer.transform.position, 0.1f, layerGround);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            AudioManager.instance.playJump();
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }
    }

    void AnimePlayer()
    {
        animator.SetBool("isMove",isMove);
        animator.SetBool("isGround", isGround);
    }

    void getDamage()
    {
        AudioManager.instance.playenemyHit();
        hp--;
        isFlash = true;
        Physics2D.IgnoreLayerCollision(7,8,true);
        StartCoroutine(flash());

        if(hp <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !isFlash)
        {
            getDamage();
        }
    }

    IEnumerator flash()
    {
        for(int i = 0; i < 10; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        isFlash = false;
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    public void addHP()
    {
        hp++;
        if(hp > GamePlay.instance.maxHP)
        {
            hp = GamePlay.instance.maxHP;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0.75f, 0f, 0f, 0.75f);
        Gizmos.DrawSphere(footPlayer.transform.position, 0.1f);
    }
}
