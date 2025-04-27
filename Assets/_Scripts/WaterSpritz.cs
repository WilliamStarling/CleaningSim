using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction.HandGrab;
using UnityEngine;
using Oculus.Interaction;

public class WaterSpritz : MonoBehaviour, IHandGrabUseDelegate
{
    public ParticleSystem waterSpritzEffect;
    private float _dampedUseStrength = 0;
    private float _lastUseTime;
    private AnimationCurve _strengthCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
    [SerializeField] private float _triggerSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        waterSpritzEffect = GetComponentInChildren<ParticleSystem>();
        if (waterSpritzEffect == null)
        {
            Debug.LogError("WaterSpritz: ParticleSystem not found in children.");
        }
    }
    public void BeginUse()
    {
        _dampedUseStrength = 0f;
        _lastUseTime = Time.realtimeSinceStartup;
        // Logic to start using the water spritz
        //Debug.Log("Water spritz started!");
        waterSpritzEffect.Play();
    }
    public void EndUse()
    {

    }
    public float ComputeUseStrength(float strength)
    {
                    float delta = Time.realtimeSinceStartup - _lastUseTime;
            _lastUseTime = Time.realtimeSinceStartup;
            if (strength > _dampedUseStrength)
            {
                _dampedUseStrength = Mathf.Lerp(_dampedUseStrength, strength, _triggerSpeed * delta);
            }
            else
            {
                _dampedUseStrength = strength;
            }
            float progress = _strengthCurve.Evaluate(_dampedUseStrength);
            return progress;
    }
}
