using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellow : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;//������Ⱦ��
    public Sprite[] sprites;//������Ⱦ������
    private int spriteIndex;//�������������S

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();//��ȡPlayer��Ⱦ��
    }
    // Start is called before the first frame update
    void Start()
    {
        //�ظ����� ÿ�����һ�������һ��AnimateSprite����
        //AnimateSprite������ר�����ڼ�ʹ��jQuery���о���ͼ��sprites�������Ĵ��� ͨ���򵥵�API���� �������ɵ�ʵ�ָ��Ӷ������Ķ���Ч�� ���Ĺ������ڽ����Ϳ��ƾ���ͼ�еĸ���֡��ʹ�䰴���趨���ٶȺ�˳��̬չʾ��
        InvokeRepeating(nameof(AnimateSprite), 0.2f, 0.2f);
    }

    private void AnimateSprite()//���趯��
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
