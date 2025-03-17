using UnityEngine;

public class Pipes : MonoBehaviour
{
    private float leftEdge;
    
    public static float initialSpeed = 5f; // 初始速度
    
    private void Start()
    {
        //将屏幕空间位置改为世界空间位置
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x-1f;
    }
    private void Update()
    {
        pipesmove();

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
    private void pipesmove()
    {
        transform.position += Vector3.left * initialSpeed * Time.deltaTime;//管道移动
    }
}
