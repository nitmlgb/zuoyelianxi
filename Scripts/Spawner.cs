using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;//管道预制体

    public GameObject jinbi;//金币预制体

    public static float spawnRate = 1f;//管道生成频率

    public float jinbiRate = 0.5f;//金币生成频率

    //管道生成位置范围
    public float minHeight = -1f;
    public float maxHeight = 1f;


    private void OnEnable()//开始时重复
    {
        InvokeRepeating(nameof(Spawn), spawnRate,spawnRate);//重复调用
        InvokeRepeating(nameof(jinbisc), jinbiRate, jinbiRate);
    }
    private void OnDisable()//结束时取消生成
    {
        CancelInvoke(nameof(Spawn));//取消调用
        CancelInvoke(nameof(jinbisc));
    }
    private void jinbisc()
    {
        GameObject jinbis = GameObject.Instantiate(jinbi, transform.position, transform.rotation);//金币生成
        jinbis.transform.position = Vector3.up * Random.Range(0.7f, 0.7f) + transform.position;//随机位置
    }
    private void Spawn()
    {
        GameObject pipes = GameObject.Instantiate(prefab, transform.position,transform.rotation);//管道生成
          
        pipes.transform.position=Vector3.up * Random.Range(minHeight,maxHeight)+transform.position;//随机位置
    }
   
}
