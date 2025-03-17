
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;//声明渲染器
    public Sprite[] sprites;//精灵渲染器数组
    private int spriteIndex;//跟踪数组的索引S

    private Vector3 direction;//方向
    public float gravity = -9.8f;//重力

    public float strength = 5f;//强度


    public float scaleDownFactor = 0.5f; // 缩小的比例因子
    public float duration = 3f; // 持续的时间（秒）

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//获取Player渲染器
    }

    private void Start()
    {
        //每隔零点一五秒调用一次AnimateSprite函数
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        //按空格键或者单击左键
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * strength;
        }

        //手机触屏
        //if (Input.touchCount > 0)
        //{
        //    Touch touch = Input.GetTouch(0);

        //    if(touch.phase == TouchPhase.Began)
        //    {
        //        direction=Vector3.up * strength;
        //    }
        //}

        direction.y += gravity * Time.deltaTime;//小鸟通过重力一直下落
        transform.position += direction * Time.deltaTime;//位置变换及方向
    }

    private void AnimateSprite()//飞翔动画
    {
        spriteIndex++;

        if(spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)//碰撞器检测游戏结束
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();

        }else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncreaseScore();
        }else if(other.gameObject.tag == "jinbi")
        {

            // 立刻将物体缩小到一半
            Vector2 scaledScale = transform.localScale; // 获取当前的scale
            scaledScale.x *= scaleDownFactor; // 缩小一半
            scaledScale.y *= scaleDownFactor; // 缩小一半
            transform.localScale = scaledScale; // 设置新的scale

            // 等待三秒后恢复原大小
            StartCoroutine(ScaleBackCoroutine());
        }
    }
    IEnumerator ScaleBackCoroutine()
    {
        yield return new WaitForSeconds(duration); // 等待三秒
        transform.localScale = new Vector2(0.5f, 0.5f); // 恢复原大小
    }
}
