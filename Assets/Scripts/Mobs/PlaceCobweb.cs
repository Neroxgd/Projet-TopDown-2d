using System.Collections;
using UnityEngine;

public class PlaceCobweb : MonoBehaviour
{
    [SerializeField] private GameObject cobweb;
    [SerializeField] private float speedInstantiateCobweb;

    void Start()
    {
        StartCoroutine(InstantiateCobweb());
    }

    IEnumerator InstantiateCobweb()
    {
        yield return new WaitUntil(()=> Vector3.Distance(PlayerStatistic.Instance.transform.position, transform.position) < 16);
        yield return new WaitForSeconds(speedInstantiateCobweb);
        Instantiate(cobweb, transform.position, Quaternion.identity, transform.parent);
        StartCoroutine(InstantiateCobweb());
    }

    // void OnDisable()
    // {
    //     PlayerStatistic.Instance.MoveSpeed = PlayerStatistic.Instance.GetComponent<PlayerMovement>().SpeedPlayer;
    // }
}
