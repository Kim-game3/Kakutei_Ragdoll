using UnityEngine;

/*�쐬�ҁ@�ؑ�*/
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
