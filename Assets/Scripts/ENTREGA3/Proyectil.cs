using UnityEngine;

public class Proyectil : MonoBehaviour
{

    [SerializeField]
    private float _velocidad = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocidad * Time.deltaTime, 0, 0);    
    }
}
