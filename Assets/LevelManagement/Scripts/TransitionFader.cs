using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionFader : ScreenFader
{

    [SerializeField] private float _lifetime = 1f;
    [SerializeField] private float _delay = 0.3f;

    public float Delay { get { return _delay; } }

    protected void Awake()
    {
        _lifetime = Mathf.Clamp(_lifetime, FadeOnDuration + FadeOffDuration + Delay, 10f);
    }

    private IEnumerator PlayRoutine()
    {
        SetAlpha(_clearAlpha);
        yield return new WaitForSeconds(Delay);
        FadeOn();
        float onTime = _lifetime - (FadeOffDuration + Delay);
        yield return new WaitForSeconds(onTime);
        FadeOff();
        Object.Destroy(gameObject, FadeOffDuration);
    }

    public void Play()
    {
        StartCoroutine(PlayRoutine());
    }

    public static void PlayTransition(TransitionFader transitionFaderPrefab)
    {
        if (transitionFaderPrefab != null)
        {
            TransitionFader instance = Instantiate(transitionFaderPrefab, Vector3.zero, Quaternion.identity);
            instance.Play();
        }
    }
}
