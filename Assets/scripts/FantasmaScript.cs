using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    Vector3 posicionInicial;
    GameObject personaje;
    public float velocidadFantasma = 2.0f;

    void Start()
    {
        posicionInicial = transform.position;
        personaje = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distancia = Vector3.Distance(transform.position, personaje.transform.position);

        if (distancia <= 4.1f)
        {
            // Si la distancia es menor de 4, perseguir al personaje
            Vector3 direccion = (personaje.transform.position - transform.position).normalized;
            transform.position += direccion * velocidadFantasma * Time.deltaTime;
        }
        else
        {
            // Si la distancia es mayor de 4, volver a la posición inicial
            transform.position = Vector3.MoveTowards(transform.position, posicionInicial, velocidadFantasma * Time.deltaTime);
        }
    }
}