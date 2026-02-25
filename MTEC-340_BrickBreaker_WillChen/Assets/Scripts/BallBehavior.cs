using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    private AudioSource _source;
    [SerializeField] private AudioClip _paddleHit;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _brickHit;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _source = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        _rb.simulated = GameBehavior.Instance.GameMode == Utilities.GameState.Play;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            _source.PlayOneShot(_wallHit);
        }
        else if (collision.gameObject.CompareTag("Paddle"))
        {
            _source.PlayOneShot(_paddleHit);
        }
        else if (collision.gameObject.CompareTag("Brick"))
        {
            _source.PlayOneShot(_brickHit);
        }
    }
}