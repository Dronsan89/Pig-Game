using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] protected float _maxSpeed;
    [SerializeField] private float _maxTimerDirty;

    protected bool _isDirty = false;
    protected float _beginSpeed;

    private SpriteRenderer _spriteRenderer;
    private Vector2 _direction;
    private float _currentTimerDirty;

    protected virtual void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _beginSpeed = _maxSpeed;
    }

    protected virtual void Update()
    {
        _currentTimerDirty -= Time.deltaTime;

        if(_currentTimerDirty <= 0 && _isDirty)
        {
            _isDirty = false;
            _maxSpeed = _beginSpeed;
        }
    }

    protected void SetDirectionSprite(Sprite[] sprites)
    {
            if (_direction.x > 0)
            {
                _spriteRenderer.sprite = sprites[0];
            }
            else if (_direction.x < 0)
            {
                _spriteRenderer.sprite = sprites[1];
            }
            else if (_direction.y < 0)
            {
                _spriteRenderer.sprite = sprites[2];
            }
            else if (_direction.y > 0)
            {
                _spriteRenderer.sprite = sprites[3];
            }
    }

    protected Vector2 GetTargetPosition(Vector2 direction)
    {
        _direction = direction;

        Vector2 targetPosition = transform.position;

        if (direction.y != 0)
        {
            targetPosition = new Vector2(transform.position.x + 0.222f * direction.y, transform.position.y + 1.956f * direction.y);
        }
        else if (direction.x != 0)
        {
            targetPosition = new Vector2(transform.position.x + direction.x, transform.position.y);
        }

        return targetPosition;
    }

    public void SetDirty()
    {
        _currentTimerDirty = _maxTimerDirty;
        _isDirty = true;
        _maxSpeed /= 2;
    }
}
