using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageEffect : MonoBehaviour
{
    private Image _effectImage;

    private void Awake()
    {
        _effectImage = GetComponent<Image>();
    }
    public void StartEffect()
    {
        StartCoroutine(Effect());
    }

    private IEnumerator Effect()
    {
        _effectImage.enabled = true;
        for (float i = 1; i > 0; i -= Time.deltaTime * 1.5f)
        {
            _effectImage.color = new Color(1, 0, 0, i);
            yield return null;
        }
        _effectImage.enabled = false;
    }
}
