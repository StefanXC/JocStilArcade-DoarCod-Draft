using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 distantaCamera;
    public Vector3 distantaCamera2;
    public Vector3 rotatie; //rotatia camerei
    public float viteza = 0.1f;
    public bool start;
    public float margineX;
    public float margineZ;

    public float maxX;
    public float minX; 
    public float maxZ;
    public float minZ;

    void Start()
    {
        //distantaCamera = transform.position - player.position;
    }

    void Update()
    {


        if (player.position.x <= minX)
        {
            margineX = minX;
        }
        else if (player.position.x >= maxX)
        {
            margineX = maxX;
        }
        else
            margineX = player.position.x;


        /*if (distantaCamera2.z + player.position.z <= minZ)
        {
            margineZ = minZ;
        }
        else if (distantaCamera2.z + player.position.z >= maxZ)
        {
            margineZ = maxZ;
        }
        else
            margineZ = distantaCamera2.z + player.position.z;
        */



        //if (start == false)
        //{
        //    Vector3 pozitieDorita = new Vector3(player.position.x + distantaCamera.x, distantaCamera.y, player.position.z + distantaCamera.z);
        //    Vector3 pozitieFina = Vector3.Lerp(transform.position, pozitieDorita, viteza);
        //    transform.position = pozitieFina; //controlul camerei in timpul numaratoarei
        //}
        //else
        //{
        Vector3 pozitieNoua = new Vector3(/*distantaCamera2.x + player.position.x*/ margineX, transform.position.y, /*margineZ */ distantaCamera2.z + player.position.z);
            transform.position = pozitieNoua; //controlul camerei dupa numaratoarea inversa
        //}
    }

}
