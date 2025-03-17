using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jinbi : MonoBehaviour
{
    private float leftEdge;

    public static float initialSpeed = 5f; // ��ʼ�ٶ�
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
        transform.position += Vector3.left * initialSpeed * Time.deltaTime;//����ƶ�
    }
    private void OnTriggerEnter2D(Collider2D other)//��ײ���������ʧ
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject) ;
        }
    }
}
