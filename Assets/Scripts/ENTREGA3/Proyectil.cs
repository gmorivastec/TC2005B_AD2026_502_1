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
        Destroy(gameObject);       
    }
}
