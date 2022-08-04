using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject lightBulb;

    [SerializeField] private Material emissiveMaterial;
    [SerializeField] private Renderer objectToChange;
    
    void Start()
    {
        emissiveMaterial = objectToChange.GetComponent<Renderer>().material;
    }

    public void TurnEmissionOff()
    {
        emissiveMaterial.DisableKeyword("_EMISSION");
    }

    public void TurnEmissionOn()
    {
        emissiveMaterial.EnableKeyword("_EMISSION");
    }

    public void TurnLightOff()
    {
        lightBulb.SetActive(false); 
    }

    public void TurnLightOn()
    {
        lightBulb.SetActive(true);
    }
}
