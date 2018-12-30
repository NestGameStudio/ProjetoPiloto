using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBodyExperience: MonoBehaviour
{
    [HideInInspector]
    public static OutOfBodyExperience Instance;

    [HideInInspector]
    public List<GameObject> EspiritualObjects = new List<GameObject>();

    private GameObject player;
    private GameObject body;
    private GameObject spirit;

    public static OutOfBodyExperience getInstance() { return Instance; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        player = GameObject.FindGameObjectWithTag("Player");

        foreach (GameObject Object in GameObject.FindGameObjectsWithTag("Espiritual Object"))
        {
            EspiritualObjects.Add(Object);
            //Object.SetActive(false);
        }

        foreach(Transform child in player.GetComponentsInChildren<Transform>(true)) {

            if (child.CompareTag("Physical Body")) {
                body = child.gameObject;
            } else if (child.CompareTag("Spirit Body")) {
                spirit = child.gameObject;
            }
        }

    }

    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - ativa a instancia do espírito na frente (ou direção desejada) do player
    // - o target do controle é assumido para o espírito
    // - uma segunda camera é criada e passa a seguir e olhar para o espírito
    // - ativa a visibilidade de objetos espirituais

    public void ReleaseSpirit() {

        body.SetActive(false);
        spirit.SetActive(true);

        if (this.GetComponent<Inventory>().CheckIfCrystalAvailable(TipoCristal.Espiritual)) {
            spirit.transform.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(true);
        }
        else {
            spirit.transform.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(false);
        }
    }

    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - o target do controle é assumido para o corpo
    // - uma segunda camera é destruida inativa e reativa a primeira camera
    // - desativa visão dos objetos espirituais

    public void RetrieveSpirit()
    {

        spirit.SetActive(false);
        body.SetActive(true);

        if (this.GetComponent<Inventory>().CheckIfCrystalAvailable(TipoCristal.Fisico))
        {
            body.transform.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(true);
        }
        else
        {
            body.transform.gameObject.GetComponentInChildren<ParticleSystem>(true).transform.parent.gameObject.SetActive(false);
        }
    }

    public GameObject getCurrentStateBody() {
        
        if (spirit.activeSelf) {
            return spirit;
        } else {
            return body;
        }
    }

    public bool IsInSpiritState()
    {
        return spirit.activeSelf;
    }

}
