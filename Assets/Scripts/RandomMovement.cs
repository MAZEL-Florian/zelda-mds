using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    public float speed = 9f;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    void Start()
    {
        var x = UnityEngine.Random.Range(-1.0f, 1.0f);
        var y = UnityEngine.Random.Range(-1.0f, 1.0f);
        var movement = new Vector2(x, y).normalized;
        _rigidbody2D.linearVelocity = movement * speed;
    }
}