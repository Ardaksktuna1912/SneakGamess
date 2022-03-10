using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChickenController : MonoBehaviour
{
    [SerializeField] private float minX, minY,maxX,MaxY;
    [SerializeField] private SnakeController _snake;
   
   void Start()
    {
        RandomChickenPosition();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Snake"))
        {
            RandomChickenPosition();
            _snake.CreateSegment();
        }
    }
    private void RandomChickenPosition()
    {
        transform.position = new Vector2(Mathf.Round(Random.Range(minX,maxX))+0.5f, Mathf.Round (Random.Range(minY,MaxY))+0.5f);
        

    }
}
