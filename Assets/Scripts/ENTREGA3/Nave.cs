using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.InputSystem;

public class Nave : MonoBehaviour
{

    // CORRUTINAS: mecanismo para pseudo concurrencia en Unity

    // USE CASES 2 categorías:
    // - esperar para ejecutar algo (puede ser código asíncrono)
    // - comportamiento cíclico

    // más notas de corrutinas:
    // - están relacionadas a un componente
    // - al destruir el componente se destruyen las corrutinas
    // - el componente puede iniciar y detener corrutinas
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

    private IEnumerator _enumeratorCiclico, _enumeratorDisparo;
    private Coroutine _coroutineCiclico;


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
        // una corrutina no se comporta como corrutina hasta que invocamos startcoroutine
        StartCoroutine(EjemploLineal());
        StartCoroutine("EjemploLineal");

        _enumeratorCiclico = EjemploCiclico();
        _coroutineCiclico = StartCoroutine(_enumeratorCiclico);

        _enumeratorDisparo = Disparo();

    }

    // Update is called once per frame
    void Update()
    {
        // mismo código que habíamos utilizado para desplazamiento
        Vector2 movimiento = inputActions.Player.Move.ReadValue<Vector2>();
        transform.Translate(movimiento * Time.deltaTime * _velocidad, Space.World);

        // esto lo vamos a usar para crear proyectiles
        if(inputActions.Player.Jump.WasPressedThisFrame())
        {
            StartCoroutine(_enumeratorDisparo);
        }

        // sólo como nota
        if(inputActions.Player.Jump.IsPressed())
        {
            // hacer algo mientras se mantenga presionado    
        }

        if(inputActions.Player.Jump.WasReleasedThisFrame())
        {
            StopCoroutine(_enumeratorDisparo);
        }

        // cómo detener todas las corrutinas
        if(inputActions.Player.Sprint.triggered)
        {
            print("PRESIONASTE shift");
            // presionó "shift"
            // detiene todas las corrutinas DEL COMPONENTE
            StopAllCoroutines();
        }

        // cómo detener una corrutina en particular
        if(inputActions.Player.Crouch.triggered)
        {
            // presionó "C"
            //StopCoroutine(_enumeratorCiclico);
            StopCoroutine(_coroutineCiclico);

        }
    }

    // las corrutinas se definen en métodos
    // la lógica se ejecuta hasta que hacemos StartCoroutine

    IEnumerator EjemploLineal()
    {

        // existe invoke como alternativa
        yield return new WaitForSeconds(2);
        print("HOLA");
    }

    IEnumerator EjemploCiclico()
    {

        // CUANDO HACER UNA CORRUTINA CICLICA
        // tenemos comportamiento recurrente que NO debe ir en update
        // (no es input, no es movimiento)

        // cómo decidir la frecuencia de ejecución (tiempo de espera)?
        // lo más largo posible que funcione

        WaitForSeconds espera = new WaitForSeconds(0.5f); 
        
        while(true)
        {
            print("LOOP");
            yield return espera;
                
        }
    }

    IEnumerator Disparo()
    {
        WaitForSeconds espera = new WaitForSeconds(0.5f); 
        
        while(true)
        {
            print("PEW PEW!");
            Instantiate(
                _original,
                transform.position,
                transform.rotation
            );
            yield return espera;
                
        }
    }
}
