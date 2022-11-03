using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }
    IEnumerator FadeIn()
    {
        float t = 1f * 0.5f;
        while(t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(191, 136, 110, a);
            yield return 0;
        }
    }
    public void FadeTo(int sceneIndex)
    {
        StartCoroutine(FadeOut(sceneIndex));
    }
    IEnumerator FadeOut(int sceneIndex)
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime * 2f;
            float a = curve.Evaluate(t);
            img.color = new Color(191, 136, 110, a);
            yield return 0;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}
