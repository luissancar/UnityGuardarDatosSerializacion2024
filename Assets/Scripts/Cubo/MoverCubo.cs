using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCubo : MonoBehaviour
{
     public float speed = 0.5f; // Velocidad de movimiento

    private Rigidbody rb;
    
 

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
        GameObject cubeObject = GameObject.Find("Partida"); 
        RestaurarPosocion();
    }

    void Update()
    {
        // Movimiento del cubo
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            RestaurarPosocion();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            GuardaPosicion();
        }
    }

    private void GuardaPosicion()
    {
      SaveManager.SavePlayerData(this);
        
    }

    private void RestaurarPosocion()
    {
        GameData datosLeidos = SaveManager.LoadPlayerData();
        rb.MovePosition(new Vector3(datosLeidos.x,datosLeidos.y,datosLeidos.z));
    }

    public float X()
    {
        return  rb.position.x;
    }
    
    public float Y()
    {
        return  rb.position.y;
    }
    public float Z()
    {
        return  rb.position.z;
    }
}
