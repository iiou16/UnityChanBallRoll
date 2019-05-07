using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goalChecker : MonoBehaviour
{
    public GameObject unityChan;
    public AudioSource gameBGM;
    public AudioSource goalBGM;
    public GameObject retryButton;

    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
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

        // BGMの切り替え
        gameBGM.Stop();
        goalBGM.Play();

        // Goal時にretryボタンを表示
        retryButton.SetActive(true);
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
