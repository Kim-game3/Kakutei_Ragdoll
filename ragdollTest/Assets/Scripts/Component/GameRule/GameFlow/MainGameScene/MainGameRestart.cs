using UnityEngine;

/*ì¬Ò@–Ø‘º*/
public class MainGameRestart : MonoBehaviour
{
    [SerializeField] private Transform Restartpoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

        }
    }

}
