using System.Collections;
using UnityEngine;

public class Enemy : BaseCharacter
{
    [SerializeField] private bool isHorizontal;
    [SerializeField] private Sprite[] spriteEnemy;
    [SerializeField] private Sprite[] spriteDirtyEnemy;
    [SerializeField] private Sprite[] spriteAngryEnemy;

    private bool isAngry;

    private Vector2 direction = Vector2.right;

    protected override void Start()
    {
        base.Start();

        if (isHorizontal)
        {
            direction = Vector2.right;
        }
        else if (!isHorizontal)
        {
            direction = Vector2.up;
        }
    }

    protected override void Update()
    {
        base.Update();

        Move();
    }

    private void Move()
    {
        if (!isAngry)
        {
            if (_isDirty) SetDirectionSprite(spriteDirtyEnemy);
            else SetDirectionSprite(spriteEnemy);
        }
        else
        {
            SetDirectionSprite(spriteAngryEnemy);
        }

        transform.position = Vector2.MoveTowards(transform.position, GetTargetPosition(direction), _maxSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Border"))
        {
            direction *= -1;
        }
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(SetAngry());
            collision.GetComponent<Pig>().TakeDamage();
        }
    }

    IEnumerator SetAngry()
    {
        isAngry = true;
        _maxSpeed = 0;
        yield return new WaitForSeconds(2);
        direction *= -1;
        _maxSpeed = _beginSpeed;
        isAngry = false;
    }
}
