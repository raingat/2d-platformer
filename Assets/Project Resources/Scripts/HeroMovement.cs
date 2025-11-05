using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GroundChecker _groundChecker;

    private Rigidbody2D _rigidbody;

    private InputReader _inputReader = new();

    private float _direction;

    private bool _isGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = _inputReader.GetHorizontalDirection();
        _isGrounded = _groundChecker.IsGrounded();

        if (CanMove(_direction) && _isGrounded)
            Move(_direction);

        if (_inputReader.IsJump() && _isGrounded)
            Jump();

    }

    private void Move(float direction)
    {
        float distance = direction * _speed * Time.fixedDeltaTime;

        Rotate(direction);

        Vector2 velocity = new Vector2(distance, _rigidbody.velocity.y);
        _rigidbody.velocity = velocity;
    }

    private bool CanMove(float direction)
    {
        float stand = 0.0f;

        return direction != stand;
    }

    private void Rotate(float direction)
    {
        float degreesRotate;

        if (direction < 0.0f)
        {
            degreesRotate = 180.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
        else if (direction > 0.0f)
        {
            degreesRotate = 0.0f;

            transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
        }
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
    }
}
