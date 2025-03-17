using UnityEngine;

public class ParaBax : MonoBehaviour
{
    private MeshRenderer meshRenderer;//网格渲染器
    public float animationSpeed = 1f;//Background播放速度

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();//获取Mesh Reanderer位置
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);//移动

    }
}
