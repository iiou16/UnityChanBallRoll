﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    int count;
    public Text countText;
    AudioSource getSE;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        getSE = GetComponent<AudioSource>();
    }

    // fpsによらず一定間隔でUpdate
    void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveH, 0, moveV);
        rb.AddForce(move * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // アイテムを取得したときの処理
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();

            getSE.Play();
        }
        // 落ちたとき(GameOver)の処理
        else if (other.gameObject.CompareTag("Bottom"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    void SetCountText()
    {
        countText.text = "ゲット数：" + count.ToString();
    }
}
