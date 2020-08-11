using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour, IControl
{
    public LayerMask Ground, Wall;
    SpriteRenderer MySprite;

    int health;
    public int Health
    {
        set
        {
            if(value <= 0)
            {
                Death();
            }
            else
            {
                value = health;
            }
        }
        get
        {
            return health;
        }
    }

    public float speed;
    public float jumpSpeed;
    public float maxSpeed_horizontal = 100f;
    public float Speed_horizontal
    {
        set
        {
            if(value > 0 && value < maxSpeed_horizontal)
            {
                speed = value;
            }

        }
        get
        {
            return speed;
        }
    }

    public int ExtraJumps = 2;
    public int extraJumpsMax = 4;
    int extjum;
    int extraJumps
    {
        set
        {
            extjum = value;
            if(extjum == extraJumpsMax)
            {
                extjum = 0;
                Debug.Log("0000");
            }
        }
        get
        {
            return extjum;
        }
    }

    private Rigidbody2D rb;

    int wallCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        MySprite = GetComponent<SpriteRenderer>();

        extraJumps = ExtraJumps;
    }


    // Update is called once per frame
    void Update()
    {
        Speed_horizontal = speed;
        OnGround();
        OnWall();
    }
    
    void FixedUpdate()
    {
        Move();

    }

    public void Move()
    {


        if (Input.GetButton("Horizontal"))
        {
         //   Debug.Log("move" + Input.GetAxis("Horizontal"));
            rb.velocity = new Vector2(Input.GetAxis("Horizontal") * Speed_horizontal * Time.deltaTime,0);
            if (Input.GetAxis("Horizontal") < 0)
            {
                Flip(true);
            }
            else
            {
                Flip(false);
            }
        }

        if (Input.GetButtonDown("Jump") && extraJumps > 0)
        {
            rb.AddForce(new Vector2(0, 2) * jumpSpeed * Time.deltaTime);
            extraJumps--;
        }
    }

    public void Flip(bool flip)
    {
        if (flip)
        {
            MySprite.flipX = true;
        }
        else
        {
            MySprite.flipX = false;
        }
    }

    public void OnGround()
    {
        RaycastHit2D ground = Physics2D.CircleCast(this.transform.position, 0.6f, new Vector2(0,0), Mathf.Infinity, Ground , Mathf.Infinity, Mathf.Infinity);


        if (ground)
        {
          //  Debug.Log("on ground");
            extraJumps = ExtraJumps;
            wallCount = 1;
        }
    }

    public void OnWall()
    {
        RaycastHit2D wall = Physics2D.CircleCast(this.transform.position, 0.6f, new Vector2(0, 0), Mathf.Infinity, Wall, Mathf.Infinity, Mathf.Infinity);


        if (wall)
        {
            Debug.Log("on wall");
            if(wallCount > 0)
            {
                extraJumps++;
                wallCount--;
            }
        }
    }

    public void Death()
    {
        Destroy(this);
    }

    void OnDrawGizmos()
    {

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(this.transform.position, 0.6f);
    }
}
