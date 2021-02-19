using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    public float speed = 20.0f;
    public bool vertical;
    public float changeTime = 3.0f;
    int direction = 1;
    float timer;
     
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = rigidbody2D.position;
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            timer = changeTime;
            direction = direction * -1;
        }

        if(vertical)
        {
            position.y = position.y + direction * speed * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + direction * speed * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }

        rigidbody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if(player != null)
        {
            player.ChangeHealth(-1);
        }    
    }
}
