
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;//������Ⱦ��
    public Sprite[] sprites;//������Ⱦ������
    private int spriteIndex;//�������������S

    private Vector3 direction;//����
    public float gravity = -9.8f;//����

    public float strength = 5f;//ǿ��


    public float scaleDownFactor = 0.5f; // ��С�ı�������
    public float duration = 3f; // ������ʱ�䣨�룩

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//��ȡPlayer��Ⱦ��
    }

    private void Start()
    {
        //ÿ�����һ�������һ��AnimateSprite����
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        //���ո�����ߵ������
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        //�ֻ�����
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if(touch.phase == TouchPhase.Began)
        //    {
        //        direction=Vector3.up * strength;
        //    }
        //}

        direction.y += gravity * Time.deltaTime;//С��ͨ������һֱ����
        transform.position += direction * Time.deltaTime;//λ�ñ任������
    }

    private void AnimateSprite()//���趯��
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)//��ײ�������Ϸ����
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();

        }else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }else if(other.gameObject.tag == "jinbi")
        {

            // ���̽�������С��һ��
            Vector2 scaledScale = transform.localScale; // ��ȡ��ǰ��scale
            scaledScale.x *= scaleDownFactor; // ��Сһ��
            scaledScale.y *= scaleDownFactor; // ��Сһ��
            transform.localScale = scaledScale; // �����µ�scale

            // �ȴ������ָ�ԭ��С
            StartCoroutine(ScaleBackCoroutine());
        }
    }
    IEnumerator ScaleBackCoroutine()
    {
        yield return new WaitForSeconds(duration); // �ȴ�����
        transform.localScale = new Vector2(0.5f, 0.5f); // �ָ�ԭ��С
    }
}
