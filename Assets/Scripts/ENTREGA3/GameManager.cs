using UnityEngine;

public class GameManager : MonoBehaviour
{

    // singletons 
    // https://en.wikipedia.org/wiki/Singleton_pattern

    // patrón de diseño que limita la creación de instancias a sólo 1

    // en Unity no podemos manipular el constructor - las instancias de monobehaviour están creadas por el motor
    // necesita un constructor default 

    // en Unity hacemos una versión correctiva - eliminamos objetos de una clase que ya tenga una instancia disponible


    // property C#
    // property es un mecanismo para regular el acceso a una variable
    // divide la capacidad de acceder a leer / escribir a una variable

    // 2 variantes
    // con variable declarada explícitamente y con variable declarada implícitamente

    // en un juego los managers son objetos encargados de centralizar lógica / datos
    // ejemplo típico: el estado del juego
    private int _ejemplo;

    [SerializeField]
    private int _proyectilesDestruidos = 0;

    // esta declaración de una propiedad
    public int Ejemplo
    {
        get
        {
            return _ejemplo;
        }

        private set
        {
            _ejemplo = value;    
        }
    }

    public static GameManager Instance
    {
        get;
        private set;
    }



    void Awake()
    {
        // versión correctiva va aquí! 
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // en el uso la propiedad sintácticamente es idéntica a una variable

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ejemplo = 6;
        print(Ejemplo);
    }

    public void AgregarProyectilDestruido()
    {
        _proyectilesDestruidos++;
    }

}
