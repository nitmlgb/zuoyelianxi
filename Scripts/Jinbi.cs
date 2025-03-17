using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinbi : MonoBehaviour
{
    private float leftEdge;

    public static float initialSpeed = 5f; // 初始速度
    // Start is called before the first frame update
    void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    // Update is called once per frame
    void Update()
    {
        jinbimove();
        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
    private void jinbimove()
    {
        transform.position += Vector3.left * initialSpeed * Time.deltaTime;//金币移动
    }
    private void OnTriggerEnter2D(Collider2D other)//碰撞器检测金币消失
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject) ;
        }
    }
}
