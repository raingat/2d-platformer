using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HeroMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private HeroAnimation _heroAnimation;

    private Rigidbody2D _rigidbody;

    private InputReader _inputReader = new();

    private float _direction;

    private bool _iGrounded;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _direction = _inputReader.GetHorizontalDirection();
        _iGrounded = _groundChecker.IsGrounded();

        if (_iGrounded)
        {
            _heroAnimation.PlayAnimationJump(false);
            TryMove(_direction);
        }

        if (_inputReader.IsJump() && _iGrounded)
            Jump();
    }

    private void TryMove(float direction)
    {
        if (CanMove(direction))
        {
            float distance = direction * _speed * Time.fixedDeltaTime;

            Rotate(direction);

            Vector2 velocity = new Vector2(distance, _rigidbody.velocity.y);
            _rigidbody.velocity = velocity;

            _heroAnimation.PlayAnimationRun(true);
        }
        else
        {
            _heroAnimation.PlayAnimationRun(false);
        }
    }

    private bool CanMove(float direction)
    {
        float stand = 0.0f;

        return direction != stand;
    }

    private void Rotate(float direction)
    {
        float degreesRotate = 0.0f;

        if (direction < 0.0f)
            degreesRotate = 180.0f;

        transform.rotation = Quaternion.Euler(Vector2.up * degreesRotate);
    }

    private void Jump()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);

        _heroAnimation.PlayAnimationJump(true);
    }
}
