using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Controller : MonoBehaviour
{
    public float TimeEffect;
    public GameObject FX;
    public Transform posEffect;
    
    public void DestroyObject()
    {
        EffectCenter();
        Destroy(this.gameObject);
    }

    public void Deactivate()
    {
        Effect();
        this.gameObject.SetActive(false);
    }

    public void StartDeactivation(float seconds)
    {
        if (seconds < 0) return; 

        StartCoroutine(DeactivationAfterSeconds(seconds));
        Effect();
    }

    public IEnumerator DeactivationAfterSeconds(float seconds)
    {
        float s = 0;
        while (s < seconds)
        {
            s += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        this.gameObject.SetActive(false);
    }

    

    void Effect()
    {
        if (FX != null)
        {
            if (FX.GetComponent<ParticleSystem>() != null)
            {
                var ps = Instantiate(FX, transform.position, Quaternion.identity);
                ps.GetComponent<ParticleSystem>().Play();
                Destroy(ps, TimeEffect);
            }
        }
    }

    void EffectPos()
    {
        if (FX != null)
        {
            if (FX.GetComponent<ParticleSystem>() != null)
            {
                var ps = Instantiate(FX, posEffect.position, Quaternion.identity);
                ps.GetComponent<ParticleSystem>().Play();
                Destroy(ps, TimeEffect);
            }
        }
    }

    void EffectCenter()
    {
        if (FX != null)
        {
            if (FX.GetComponent<ParticleSystem>() != null)
            {
                var ps = Instantiate(FX, transform.position + transform.GetComponentInChildren<BoxCollider>().center, Quaternion.identity);
                ps.GetComponent<ParticleSystem>().Play();
                Destroy(ps, TimeEffect);
            }
        }
    }
}
