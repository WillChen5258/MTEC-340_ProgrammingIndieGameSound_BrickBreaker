using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    [SerializeField] private GameObject _ballPrefab;
    [SerializeField] private float _launchForce = 5.0f;
    [SerializeField] private TMP_Text _scoreTextUI;
    [SerializeField] private TMP_Text _pauseTextUI;
   
    private Utilities.GameState _gameMode;
    public Utilities.GameState GameMode
    {
        get => _gameMode;
        set
        {
            _gameMode = value;
            _pauseTextUI.enabled = GameMode != Utilities.GameState.Play;
        }
    }
    
    private int _score;
    public int ScoreValue
    {
        get => _score;
        set
        {
            _score = value;
            _scoreTextUI.text = "Score: " + _score.ToString();
        }
    }
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        ScoreValue = 0;
        GameMode = Utilities.GameState.Play;
        Serve();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameMode = GameMode == Utilities.GameState.Play ?
                Utilities.GameState.Pause :
                Utilities.GameState.Play;
        }
    }

    private void Serve()
    {
        GameObject ball = Instantiate(_ballPrefab, Vector3.zero, Quaternion.identity);

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();

        Vector2 direction = new Vector2(
            GetNonZeroRandomFloat(),
            GetNonZeroRandomFloat()
        ).normalized;

        rb.AddForce(direction * _launchForce, ForceMode2D.Impulse);
    }

    private float GetNonZeroRandomFloat(float min = -1.0f, float max = 1.0f)
    {
        float num;
        do
        {
            num = Random.Range(min, max);
        } while (Mathf.Approximately(num, 0.0f));

        return num;
    }
    
    
    public void Score()
    {
        Invoke(nameof(Serve), 2.0f);
    }
    
    public void AddScore(int amount)
    {
        ScoreValue += amount;
    }
}