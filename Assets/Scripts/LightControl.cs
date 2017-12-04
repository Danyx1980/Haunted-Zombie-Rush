using System;
using System.Collections;
using UnityEngine;

public class LightControl : MonoBehaviour {

    private new Light light;
    float minIntensity = 0.6f;
    float maxIntensity = 1f;
    float pulseDuration = 1f;

    float minXRotation = -25f;
    float maxXRotation = -15f;
    float minYRotation = -5f;
    float maxYRotation = 5f;
    float rotationDuration = 7.5f; 

	// Use this for initialization
	void Start () {
        light = GetComponent<Light>(); 
        StartCoroutine(FadeLight(getNewIntensity()));
        StartCoroutine(ChangeAngle(getNewAngle())); 
    }
    
    private IEnumerator FadeLight(float target)
    {
        float counter = 0f;
        float currentIntensity = light.intensity; 

        while(counter < pulseDuration)
        {
            counter += Time.deltaTime;

            light.intensity = Mathf.Lerp(currentIntensity, target, counter / pulseDuration);

            yield return null;
        }

        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(FadeLight(getNewIntensity())); 

    }

    private IEnumerator ChangeAngle(Vector3 target)
    {
        Quaternion currentAngle = transform.rotation;
        float counter = 0;
        print(counter);
        print(rotationDuration);
        while (counter < rotationDuration)
        {
            counter += Time.deltaTime; 
            transform.rotation = Quaternion.Lerp(currentAngle, Quaternion.Euler(target), counter / rotationDuration);

            yield return null; 
        }
        yield return StartCoroutine(ChangeAngle(getNewAngle())); 
    }

    private Vector3 getNewAngle()
    {
        float newX = UnityEngine.Random.Range(minXRotation, maxXRotation);
        float newY = UnityEngine.Random.Range(minYRotation, maxYRotation);

        return new Vector3(newX, newY, 0); 
    }

    private float getNewIntensity()
    {
        return UnityEngine.Random.Range(minIntensity, maxIntensity); 
    }
}
