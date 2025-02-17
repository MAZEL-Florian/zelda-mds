using UnityEngine;

public class Player : MonoBehaviour
{    
    private Vector2 _movement;
    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 15f;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {
        Debug.Log("Start player");
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _movement = new Vector2(horizontal, vertical).normalized;
        
        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Velocity", _movement.sqrMagnitude);
        
    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _movement * moveSpeed;
    }
}
