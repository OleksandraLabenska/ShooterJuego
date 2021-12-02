using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparosFPS : MonoBehaviour
{
    public AudioSource elSonido;
    public AudioClip sonido;


    void Update()
    {
        //Disparar presionando el botón de ratón
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DispararConrayo();
        }
    }

    void DispararConrayo()
    {
        //Disparar
        RaycastHit resultRayo;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out resultRayo, 100))
        {
            elSonido.clip = sonido;
            elSonido.Play();

            //Destruir enemigos
            if (resultRayo.transform.tag == "Enemigo")
            {
                Destroy(resultRayo.transform.gameObject);
            }
        }
        else
        {
            Debug.Log("No collision");
            elSonido.clip = sonido;
            elSonido.Play();
        }

    }
}
