using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class scene_transfer : MonoBehaviour {

    public Image panel;
    public AnimationCurve curve;
    public float loadTIme;

    void Start()
    {
        StartCoroutine(fadeout());
    }

	public void sceneload(string loadscene) {

        StartCoroutine(fadein(loadscene));

	}

    IEnumerator fadeout()
    {
        float t = 0; 
        while (t <= loadTIme)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            panel.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0f);
        }
       
    }

    IEnumerator fadein(string _loadscene)
    {
        float t = loadTIme;
        while (t >= 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            panel.color = new Color(0, 0, 0, a);
            yield return new WaitForSeconds(0f);
        }
        SceneManager.LoadScene(_loadscene);
    }
}
