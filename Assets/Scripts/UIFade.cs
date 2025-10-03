using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    public CanvasGroup canvasGroups;
    [SerializeField]
    private float fadeDuration;
    public bool isFade;
    void Awake()
    {

    }

    void Update()
    {
        if (isFade == true)
            Fade();
    }


    public void Fade()
    {
        StartCoroutine(FadeCanvas(canvasGroups, 1, 0));
    }
    
    private System.Collections.IEnumerator FadeCanvas(CanvasGroup canvasGroup, float start, float end)
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = end;
    }

}
