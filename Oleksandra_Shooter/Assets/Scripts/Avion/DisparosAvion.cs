using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparosAvion : MonoBehaviour
{

    public GameObject balaOriginal;
    public GameObject puntoDeDisparo;
    public float tiempoEntreDisparos;

    public AudioSource elSonido;
    public AudioClip son1;

    void Update()
    {
        Disparar();
    }


    void Disparar()
    {
        tiempoEntreDisparos += Time.deltaTime;
        //Gestion de disparos y tiempo entre disparo
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (tiempoEntreDisparos > 0.5f)
            {
                tiempoEntreDisparos = 0;
                GameObject g = Instantiate(balaOriginal, puntoDeDisparo.transform.position, this.transform.rotation);

                //Añadimos el sonido
                elSonido.clip = son1;
                elSonido.Play();

                //Añadimos la fuerza a la bala
                g.GetComponent<Rigidbody>().AddForce(g.transform.forward * 400);
            }
        }
    }
}
