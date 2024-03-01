using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessing : MonoBehaviour
{
    private Vignette vign;
    private PostProcessVolume volume;
    // Start is called before the first frame update
    void Start()
    {
        volume = GameObject.Find("PostProcessing").GetComponent<PostProcessVolume>();
        vign = volume.profile.GetSetting<Vignette>();
        vign.enabled.Override(false);

    }

    public void DamageTakeEffect()
    {
        vign.enabled.Override(true);
        vign.intensity.value = 0.2f;
        StartCoroutine(reduceVignette());
    }

    public IEnumerator reduceVignette()
    {
        while (vign.intensity.value > 0)
        {
            vign.intensity.value = vign.intensity.value - 0.005f;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
