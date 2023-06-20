using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    //Destroy bir objeyi tamamen siler oyunu kasmaya neden olur
    //Setactive bir �eyi g�r�nmez eder

    public void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Unttagged")|| hit.gameObject.CompareTag("Obstacles"))
        {
            hit.gameObject.SetActive(false);
        }
    }
}
