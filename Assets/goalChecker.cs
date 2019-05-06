using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goalChecker : MonoBehaviour
{
    public GameObject unityChan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Goalしたときの処理
    private void OnTriggerEnter(Collider other)
    {
        // 物理演算をoff
        other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        // Unityちゃんへの処理
        unityChan.transform.LookAt(Camera.main.transform);
        unityChan.GetComponent<Animator>().SetTrigger("Goal");
    }
}
