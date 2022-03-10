using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeController : MonoBehaviour
{
    private Vector2 _direction;
    [SerializeField] private GameObject _segmentpre;
    private List<GameObject> _segments = new List<GameObject>();
    void Start()
    {
        Reset();
        ResetSegment();
    }


    void Update()
    {
        GetusuerInput();

    }
    void FixedUpdate()
    {
        SnakeMove();
        FollowSnake();
    }
    private void Reset()
    {
        _direction = Vector2.right;
        Time.timeScale = 0.1f;

    }
    private void ResetSegment()
    {
        for (int i = 1; i <_segments.Count; i++)
        {
            Destroy(_segments[i]);
        }
        _segments.Clear();
        _segments.Add(gameObject);
        for (int i = 0; i < 3 ; i++) //diledigin kadar kuyruk olustur
        {
            CreateSegment();
        }

    }
    private void SnakeMove()
    {
        float x, y;
        x = transform.position.x + _direction.x;
        y = transform.position.y + _direction.y;

        transform.position = new Vector2(x, y);
    }
    public void CreateSegment()
    {
        GameObject newsegment = Instantiate(_segmentpre);
        newsegment.transform.position = _segments[_segments.Count - 1].transform.position;
        _segments.Add(newsegment);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void GetusuerInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }



    }
    private void FollowSnake()
    {
        for (int i = _segments.Count-1; i > 0; i--)
        {
            _segments[i].transform.position = _segments[i - 1].transform.position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            RestartGame();
        }
    }
}
