using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    private SpriteRenderer _spriterender;
    private int _spriteindex;
    public Sprite[] sprites; 
    public float gravity = -9.8f;
    public float strenght = 5f;

    private void Awake()
    {
        _spriterender = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        _direction = Vector3.zero;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _direction = Vector3.up * strenght;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * strenght;
            }
        }

        _direction.y += gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        _spriteindex++;

        if (_spriteindex >= sprites.Length)
        {
            _spriteindex = 0;
        }

        _spriterender.sprite = sprites[_spriteindex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }

        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
