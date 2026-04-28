using UnityEngine;

public class MúsicaFundo : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static MúsicaFundo instance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
