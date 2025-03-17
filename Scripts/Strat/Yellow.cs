using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;//声明渲染器
    public Sprite[] sprites;//精灵渲染器数组
    private int spriteIndex;//跟踪数组的索引S

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//获取Player渲染器
    }
    // Start is called before the first frame update
    void Start()
    {
        //重复调用 每隔零点一五秒调用一次AnimateSprite函数
        //AnimateSprite函数：专门用于简化使用jQuery进行精灵图（sprites）动画的创建 通过简单的API调用 可以轻松地实现复杂而流畅的动画效果 核心功能在于解析和控制精灵图中的各个帧，使其按照设定的速度和顺序动态展示。
        InvokeRepeating(nameof(AnimateSprite), 0.2f, 0.2f);
    }

    private void AnimateSprite()//飞翔动画
    {
        spriteIndex++;

        if (spriteIndex >= sprites.Length)
        {
            spriteIndex = 0;
        }

        spriteRenderer.sprite = sprites[spriteIndex];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
