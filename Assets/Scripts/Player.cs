using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SIMSEK
{
    public class Player : MonoBehaviour
    {
        public CameraShake camerashake;
        public UIManager uimanager;

        public GameObject cam;
        public GameObject vectorback;
        public GameObject vectorforward;

        private Rigidbody rb;

        private Touch touch;
        [Range(12,40)] //player speed aralýðý
        public int speedModifier;
        public int forwardSpeed;

        private bool speedballforward = false;

        public void Start() //rigibody ye dýþarýdan eriþmeyi engeller
        {
            rb = GetComponent<Rigidbody>();
        }


        public void Update()
        {
            if (Variables.firsttouch ==1 && speedballforward == false) //playeri ve kamereyi hareketlnedirme
            {
                transform.position += new Vector3(0, 0, forwardSpeed*Time.deltaTime);
                cam.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
                vectorback.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);
                vectorforward.transform.position += new Vector3(0, 0, forwardSpeed * Time.deltaTime);



            }     
            if (Input.touchCount > 0) 
            {
                touch = Input.GetTouch(0); //ilk dokunuþ kontrolü

                if (touch.phase== TouchPhase.Began) 
                {
                    Variables.firsttouch = 1;
                }
                else if (touch.phase == TouchPhase.Moved) //parmaðýmýzla playerinin poziyonu ayný olmasý için yadým
                {
                    rb.velocity = new Vector3(touch.deltaPosition.x * speedModifier * Time.deltaTime,
                        transform.position.y,
                        touch.deltaPosition.y * speedModifier * Time.deltaTime);

                }
                else if(touch.phase == TouchPhase.Ended) //parmaðýmý çektiðim an
                {
                    //rb.velocity = new Vector3(0,0,0);
                    rb.velocity = Vector3.zero;
                }
            }
        }

        public GameObject[] FractureItems; //playerýn daðýlan her parçasý
        public void OnCollisionEnter(Collision hit) //nesneye çarpýþma
        {
            if (hit.gameObject.CompareTag("Obstacles"))
            {
                camerashake.CameraShakeCall();
                uimanager.StartCoroutine("WhiteEffect");
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
                foreach (GameObject item in FractureItems)
                {
                    item.GetComponent<SphereCollider>().enabled = true;
                    item.GetComponent<Rigidbody>().isKinematic = false;
                    //topun patlamasý için 
                }
                StartCoroutine(TimeScaleControl());

            }
        }

        public IEnumerator TimeScaleControl()
        {
            speedballforward = true;
            yield return new UnityEngine.WaitForSecondsRealtime(0.4f);
            Time.timeScale = 0.4f;
            yield return new UnityEngine.WaitForSecondsRealtime(0.6f);
            uimanager.RestartButtonActive();
            rb.velocity=Vector3.zero;
        }
    }
}
