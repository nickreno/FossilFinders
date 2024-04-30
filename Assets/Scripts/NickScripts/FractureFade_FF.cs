using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FractureFade_FF : MonoBehaviour
{

    public float fadeDuration2 = 3f;
    public Color fadeColor2;
    private Renderer rend2;
    public GameObject fadeThisObjectOut;

    private void Start()
    {
        rend2 = fadeThisObjectOut.GetComponent<Renderer>();
    }

    public void FadeOut()
    {

        Fade(1, 0);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer2 = 0;
        while (timer2 <= fadeDuration2)
        {
            Color newColor = fadeColor2;
            newColor.a = Mathf.Lerp(alphaIn, alphaOut, timer2 / fadeDuration2);
            rend2.material.SetColor("_BaseColor", newColor);

            timer2 += Time.deltaTime;
            yield return null;
        }
        Color newColor2 = fadeColor2;
        newColor2.a = alphaOut;
        rend2.material.SetColor("_BaseColor", newColor2);
        yield return null;
    }


}
