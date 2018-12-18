using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerCamera : MonoBehaviour
{
    public Animator animacaoTorre;
    public Animator animacaoPlayer;
    public GameObject flowchartFinal;
    public GameObject mainCamera;
    public GameObject mainPlayerCamera;
    public GameObject cutsceneCam;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //mainCamera.SetActive(false);
            //mainPlayerCamera.SetActive(false);
            //cutsceneCam.SetActive(true);

            //animacaoTorre.gameObject.SetActive(true);
            animacaoPlayer.gameObject.SetActive(true);            

            //animacaoTorre.Play("animacaoFinal");
            //animacaoPlayer.Play("animacaoFinalPlayer");

            flowchartFinal.SetActive(true);

        }
    }
    public void toMenu() {
        SceneManager.LoadScene(0);
    }
}

