using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    public Canvas damageCanvas;
    public float hideDelay = 0.5f;

    public IEnumerator ToggleDamageCanvas()
    {
        damageCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(hideDelay);
        damageCanvas.gameObject.SetActive(false);
    }
}
