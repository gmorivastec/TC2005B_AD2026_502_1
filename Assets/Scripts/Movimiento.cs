// C#
// POO 
// .net 
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    // nosotros NO controlamos el flujo de la logica
    // los componentes tienen un ciclo de vida
    // una serie de metodos que el motor invoca en el momento apropiado
    // y donde podemos inyectar logica

    // NOTA - no vamos a manipular el constructor porque 
    // las instancias de nuestros componentes las crea el engine

    private InputSystem_Actions inputActions;

    // valores que funcionan como parámetros desde el editor
    // puedo poner la variable pública 

    // ¿por qué querría exponer una variable al editor?

    [SerializeField]
    private float _velocidad = 5;

    void Awake()
    {
        
        // el primer metodo en ser invocado en la vida del monobehaviour
        // despues de su creacion
        // invocado una sola vez
        // se utiliza para setup
        // no hay manera de saber cual Awake corre antes que otro
        print("AWAKE");
        inputActions = new InputSystem_Actions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // el segundo que corre 
        // igual que awake no sabemos cual start va primero que otro
        // sabemos que CUALQUIER awake va a correr antes que CUALQUIER start
        Debug.Log("START");
    }

    // Update is called once per frame
    void Update()
    {
        // se ejecuta una vez por frame (fotograma)
        // frame?!
        // cuantas veces se corre?
        // depende del framerate (fps)
        // realtime - 30 fps 
        // para juegos - 60+ fps

        // tratamos de mantener el update muy magro / minimo
        // - input
        // - movimiento
        //print("UPDATE");

        // desplazamiento
        // cualquier operacion espacial correo por parte de 
        // el componente transform
        // transform - objeto que heredamos de MonoBehaviour (o alguien en la jerarquia)
        // que es una referencia al trnasform en el mismo game object
        // Transform - la clase que define al componente transform
        
        // Time.deltaTime - el tiempo que transcurrio entre el cuadro anterior y el actual
        // en operaciones espaciales se utiliza para escalar apropiadamente
        // de manera independiente al performance
        
        // capturar el vector de entrada
        // en entrada el rango está normalizado [-1, 1]
        Vector2 movimiento = inputActions.Player.Move.ReadValue<Vector2>();
        
        //transform.Translate(1 * Time.deltaTime, 0, 0);
        transform.Translate(movimiento * Time.deltaTime * _velocidad, Space.World);


        if(inputActions.Player.Jump.triggered)
        {
            print("JUMP");
        }
    }

    void LateUpdate()
    {
        // se ejecuta al terminar de ejecutar TODOS los updates
        //print("LATE UPDATE");
    }

    void FixedUpdate()
    {
        // se ejecuta en intervalos pseudoregulares
        //print("FIXED UPDATE");
    }

    // colisiones
    // es un evento que sucede cuando dos volúmenes coinciden
    // en alguna parte en el espacio en un frame

    // requisitos:
    // 1. todos los involucrados tienen collider
    // 2. al menos uno tiene rigidbody
    // 3. el que tiene rigidbody se está moviendo

    // rigidbody es un componente que "suscribe" a un objeto 
    // al motor de la física

    // método que se invoca cuando se detecta una colisión
    // puede ser invocado en todos los involucrados en la misma
    // sólo se detona en el frame en el que los objetos involucrados
    // empezaron a colisionar
    void OnCollisionEnter(Collision collision)
    {
        // recibe un objeto de tipo collision
        // el objeto collision tiene información de la colisión
        // velocidad, fuerza, puntos de contacto, etc
        print("COLLISION ENTER");

        // info útil para colisiones 
        // cómo filtrar por categorías
        print(collision.gameObject.tag);
        print(collision.gameObject.layer);
    }

    void OnCollisionStay(Collision collision)
    {
        print("COLLISION STAY");
    }

    void OnCollisionExit(Collision collision)
    {
        print("COLLISION EXIT");
    }

    // si me interesa verificar una colisión
    // pero no me interesa una reacción física 
    // puedo usar triggers

    void OnTriggerEnter(Collider other)
    {
        print("TRIGGER ENTER");
    }

    void OnTriggerStay(Collider other)
    {
        print("TRIGGER STAY");
    }

    void OnTriggerExit(Collider other)
    {
        print("TRIGGER EXIT");
    }
}
