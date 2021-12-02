using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorEsferas : MonoBehaviour
{
    int esfera = 0;
    public Image barra;
    public int maxEsfera = 4;
    public Text texto;

    void OnCollisionEnter(Collision other)
    {
        //Chequear que collisionamos con una Esfera
        if (other.gameObject.tag == "Sphere")
        {
            Destroy(other.gameObject); //Destruir el otro objeto
            esfera ++;
            Debug.Log("Las esferas: " + esfera);
            if(esfera == 4)
            {
                texto.text = "Todas esferas!";
            }
        }
        ActualizarBarra();
    }

    void ActualizarBarra()
    {
        float esferaParaImagen = (float)esfera / maxEsfera;

        //Asignar el resultado a la imagen
        barra.fillAmount = esferaParaImagen;
    }
}
