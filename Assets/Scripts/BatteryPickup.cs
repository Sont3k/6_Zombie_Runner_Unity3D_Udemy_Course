using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    public float restoreAngle = 70f;
    public float restoreIntensity = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<Flashlight>().RestoreLightAngle(restoreAngle);
            FindObjectOfType<Flashlight>().AddLightIntensity(restoreIntensity);

            Destroy(gameObject);
        }
    }
}
