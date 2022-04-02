using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;
    [SerializeField] float minSecondsBetween;
    [SerializeField] float maxSecondsBetween;
    UnityEngine.Experimental.Rendering.Universal.Light2D myLight;

    private void Start()
    {
        myLight = GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>();
        StartCoroutine(LightFlickerTime());
    }

    IEnumerator LightFlickerTime()
    {
        yield return new WaitForSeconds(Random.Range(minSecondsBetween, maxSecondsBetween));
        myLight.intensity = Random.Range(minIntensity, maxIntensity);
        StartCoroutine(LightFlickerTime());
    }
}
