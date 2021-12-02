using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguimientoIA : MonoBehaviour
{
    //Referencia del jugador
    public GameObject jugador;
    //Referncia del componente NavMaesh
    public NavMeshAgent miAgente;
    public float rango = 10;
    float tiempoEntreDisparos = 50;
    public AudioSource elSonido;
    public AudioClip sonido;

    void Update()
    {
        //Seguimos el jugador
        miAgente.SetDestination(jugador.transform.position);

        //Si jugador esta cerca - disparar al jugador
        Vector3 distPlayer = jugador.transform.position - this.transform.position;  //Vector del jugador a la ia
        if (distPlayer.magnitude < rango)
        {
            //Gestión de disparo y sonidos, para evitar superposición dee sonidos

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
            elSonido.clip = sonido;
            elSonido.Play();
        }
    }
}
