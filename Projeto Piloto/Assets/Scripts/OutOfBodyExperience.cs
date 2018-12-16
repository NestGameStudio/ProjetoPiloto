using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBodyExperience: MonoBehaviour
{
    [HideInInspector]
    public static OutOfBodyExperience Instance;

    public GameObject body;
    public GameObject spirit;

    public static OutOfBodyExperience getInstance() { return Instance; }

    private bool isSpirit = false;

    [HideInInspector]
    public List<GameObject> EspiritualObjects = new List<GameObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        foreach (GameObject Object in GameObject.FindGameObjectsWithTag("Espiritual Object"))
        {
            EspiritualObjects.Add(Object);
            Object.SetActive(false);
        }

    }

    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - ativa a instancia do espírito na frente (ou direção desejada) do player
    // - o target do controle é assumido para o espírito
    // - uma segunda camera é criada e passa a seguir e olhar para o espírito
    // - ativa a visibilidade de objetos espirituais

    public void ReleaseSpirit()
    {
        spirit.transform.position = body.transform.position + Vector3.forward * 1;
        spirit.transform.rotation = Quaternion.Euler(-90, 0, 0);
        spirit.SetActive(true);

        // Ativa os objetos espirituais
        foreach (GameObject Object in EspiritualObjects)
        {
            Object.SetActive(true);
        }

        //body.GetComponent<Properties>().Camera.SetActive(false);
        //spirit.GetComponent<Properties>().Camera.SetActive(true);

        isSpirit = true;
    }

    // o corpo vai expulsar o espirito na frente do corpo (idealmente na direção que ele escolher) e terão essas mudanças:
    // - o target do controle é assumido para o corpo
    // - uma segunda camera é destruida inativa e reativa a primeira camera
    // - desativa visão dos objetos espirituais

    public void RetrieveSpirit()
    {
        //body.GetComponent<Properties>().Camera.SetActive(true);
        //spirit.GetComponent<Properties>().Camera.SetActive(false);

        // Desativa os objetos espirituais
        foreach (GameObject Object in EspiritualObjects)
        {
            Object.SetActive(false);
        }

        spirit.SetActive(false);

        isSpirit = false;
    }

    public bool IsInSpiritState()
    {
        return isSpirit;
    }

}
