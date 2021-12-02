using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PatrullaCubosRojos : MonoBehaviour
{
    //Puntos de patrulla
    public GameObject p1;
    public GameObject p2;
    public int destinoActual;
    public NavMeshAgent miAgente;
    public float margen = 1;
    public int vel;
    //Referencia del jugador
    public GameObject jugador;
    public float rango = 10;
    public AudioSource elSonido;
    public AudioClip son1;
    float tiempoEntreDisparos = 50;
    void Start()
    {
        miAgente = this.GetComponent<NavMeshAgent>();    
    }

    void Update()
    {
        Patrulla();
    }

    void Patrulla()
    {
        //Detectar la distancia quer falta al destino
        //Distancia al destino
        Vector3 dist = this.transform.position - miAgente.destination;
        Vector3 distPlayer = jugador.transform.position - this.transform.position;  //Vector del jugador a la ia

        if (dist.magnitude < margen)
        {
            //Llegamos al destino
            if (destinoActual == 1)
            {
                destinoActual = 2;
                miAgente.SetDestination(p2.transform.position);
            }
            else if(destinoActual == 2)
            {
                destinoActual = 1;
                miAgente.SetDestination(p1.transform.position);
            }
           
        }
        //Si el jugador esta cerca - ir a su direccion y disparar
        else if(distPlayer.magnitude < rango)
        {
          
          miAgente.SetDestination(jugador.transform.position);
            
            tiempoEntreDisparos--;
            if(tiempoEntreDisparos == 0)
            {
                DispararConrayo();
                tiempoEntreDisparos = 50;

            }
        }
    }

    void DispararConrayo()
    {
        //Disparar
        RaycastHit resultRayo;
        if (Physics.Raycast(this.transform.position, this.transform.forward, out resultRayo, 100))
        {
            elSonido.clip = son1;
                elSonido.Play();
        }
    }
}
