using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIllagerCray : MonoBehaviour
{
    float speed = 1f;
    float changeDirectionTime;
    float timeElapsed = 0f;
    float vertical;
    float horizontal;
    Rigidbody2D _rb;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        changeDirectionTime = Random.Range(1f, 6f);
        SetNewDirection();
    }

    void SetNewDirection()
    {
        // sVector2 target = _rb.position;
        horizontal = Random.Range(-1, 2);
        vertical = Random.Range(-1, 2);
        animator.SetFloat("Look X", horizontal);
        animator.SetFloat("Look Y", vertical);
        if (horizontal != 0 & vertical != 0)
            animator.SetBool("isMoving", true);
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > changeDirectionTime)
        {
            SetNewDirection();
            changeDirectionTime = Random.Range(1f, 8f);
            timeElapsed = 0f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        horizontal = 0;
        vertical = 0;
        animator.SetBool("isMoving", false);
    }
    private void FixedUpdate()
    {
        Vector2 position = _rb.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        // Vector2.MoveTowards(position, target, speed * timeElapsed);
        _rb.MovePosition(position);
    }
}
