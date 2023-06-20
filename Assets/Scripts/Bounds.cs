using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform vectorback;
    public Transform vectorforward;
    public Transform vectorleft; 
    public Transform vectorright;

    public void LateUpdate() //fizik i�lemlerinde lateupdate kullan�l�r
    {
        Vector3 viewPos= transform.position;
        viewPos.z = Mathf.Clamp(viewPos.z, vectorback.transform.position.z, vectorforward.transform.position.z);
        viewPos.x = Mathf.Clamp(viewPos.x, vectorleft.transform.position.x, vectorright.transform.position.x);
        transform.position = viewPos;
    }
    //minimum va maksimum de�erlerini hesaplayarak s�n�rlar� belirledik
}
 