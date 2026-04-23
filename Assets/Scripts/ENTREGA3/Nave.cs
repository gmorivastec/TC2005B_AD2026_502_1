using UnityEngine;
using UnityEngine.Assertions;

public class Nave : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    // serialize field - 
    // habilita la capacidad de editar un valor desde el editor
    [SerializeField]
    private float _velocidad = 5;

    // creación dinámica de objetos
    // cuando creamos nuevos objetos en Unity generalmente clonamos un objeto predefinido
    // necesitamos un original
    [SerializeField]
    private GameObject _original;

    void Awake()
    {
        inputActions = new InputSystem_Actions();
        Assert.IsNotNull(_original, "ORIGINAL ES NULO EN NAVE, VERIFICAR.");
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
        
    }

    // Update is called once per frame
    void Update()
    {
        // mismo código que habíamos utilizado para desplazamiento
        Vector2 movimiento = inputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(movimiento * Time.deltaTime * _velocidad, Space.World);

        // esto lo vamos a usar para crear proyectiles
        if(inputActions.Player.Jump.triggered)
        {
            print("PEW PEW!");
            Instantiate(
                _original,
                transform.position,
                transform.rotation
            );
        }
    }
}
