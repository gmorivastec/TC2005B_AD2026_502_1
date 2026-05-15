using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProyectilPool : MonoBehaviour
{

    // OBJECT POOLING
    // pool?
    // componendio / conjunto de objetos comunes que se prestan y se regresan (como en biblioteca)
    // intención - reusar objetos sin construir / destruir

    // ventaja - performance. Construcción / destrucción requieren más recursos que habilitar / deshabilitar
    // desventaja - complejidad, uso de memoria

    // cuándo usarlo - cuando nuestro juego requiera mucha creación y destrucción dinámica (estilo bullet hell)

    [Serialize]
    private GameObject _original;

    [Serialize]
    private int _poolSize = 5;

    private Queue<GameObject> _pool;

    public static ProyectilPool Instance
    {
        get;
        private set;
    }

    void Awake()
    {
        if(Instance == null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
