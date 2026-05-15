using UnityEngine;

public class Proyectil : MonoBehaviour
{

    [SerializeField]
    private float _velocidad = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // todos los objetos que son creados deben ser destruidos
        // por cuestión de salud de la memoria
        // siempre que haya instantiate debe haber destroy

        // estrategias de destrucción:
        // - tiempo de vida
        // - distancia
        // - colisión
        // - si salió del espacio visible

        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_velocidad * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter(Collision collision)
    {
        // avisar que otro proyectil va a ser destruido
        // es necesario buscar al GameManager
        // GameObject.Find(); - es relativamente lento
        // Complejidad mínimo O(logN)

        // acceso - ??
        // O(1)
        GameManager.Instance.AgregarProyectilDestruido();
        

        // destruir el gameobject
        Destroy(gameObject);       
    }
}
