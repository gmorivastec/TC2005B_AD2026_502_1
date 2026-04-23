using UnityEngine;

public class Nave : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    // serialize field - 
    // habilita la capacidad de editar un valor desde el editor
    [SerializeField]
    private float _velocidad = 5;

    void Awake()
    {
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
        }
    }
}
