using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public Button start;
    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(onClick);
    }

    public void onClick()
    {
        SceneManager.LoadScene("FlayBird");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
