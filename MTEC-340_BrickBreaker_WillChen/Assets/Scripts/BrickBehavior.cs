using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int _health = 3;
    [SerializeField] private Color[] _healthColors;

    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _healthColors[_health - 1];
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;

        _health--;

        if (_health <= 0)
        {
            GameBehavior.Instance.AddScore(1);
            Destroy(gameObject);
        }
        else
        {
            _spriteRenderer.color = _healthColors[_health - 1];
        }
    }
}