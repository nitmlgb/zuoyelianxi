using UnityEngine;

public class ParaBax : MonoBehaviour
{
    private MeshRenderer meshRenderer;//������Ⱦ��
    public float animationSpeed = 1f;//Background�����ٶ�

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();//��ȡMesh Reandererλ��
    }

    private void Update()
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0);//�ƶ�

    }
}
