using UnityEngine;

public class Pig : BaseCharacter
{
    [SerializeField] private Sprite[] _spritePig;
    [SerializeField] private Sprite[] _spriteDirtyPig;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private GameObject _bombPrefab;

    public ControlType controlType;
    public enum ControlType { PC, Android }

    private float _moveInputX;
    private float _moveInputY;
    private Vector2 _newDirection = Vector2.zero;
    private UI _ui;

    protected override void Start()
    {
        base.Start();

        if (controlType == ControlType.PC)
        {
            _joystick.gameObject.SetActive(false);
        }

        _ui = FindObjectOfType<UI>();
    }

    protected override void Update()
    {
        base.Update();

        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, GetTargetPosition(_newDirection), _maxSpeed * Time.deltaTime);

        if (controlType == ControlType.PC)
        {
            _moveInputX = Input.GetAxisRaw("Horizontal");
            _moveInputY = Input.GetAxisRaw("Vertical");

            if (_moveInputX == 0) _newDirection = new Vector2(0, _moveInputY);
            else _newDirection = new Vector2(_moveInputX, 0);
        }
        else if (controlType == ControlType.Android)
        {
            _moveInputX = _joystick.Horizontal;
            _moveInputY = _joystick.Vertical;

            if (Mathf.Abs(_moveInputX) > Mathf.Abs(_moveInputY))
            {
                _newDirection = new Vector2(_moveInputX, 0);
            }
            else _newDirection = new Vector2(0, _moveInputY);
        }

        if (_isDirty) SetDirectionSprite(_spriteDirtyPig);
        else SetDirectionSprite(_spritePig);
    }

    public void TakeDamage()
    {
        DataLevel.HP--;

        _ui.UpdateHealth();

        if(DataLevel.HP <= 0)
        {
            _ui.Loss();
        }

    }

    public void SetBomb()
    {
        if (DataLevel.CountBomb > 0)
        {
            Instantiate(_bombPrefab, transform.position, Quaternion.identity);

            DataLevel.CountBomb--;
            _ui.SetCountBomb();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            DataLevel.Score++;
            _ui.UpdateScoreAndLevel();
        }
    }
}
