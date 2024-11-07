using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class KarakterKontrol : MonoBehaviour
{
    // Ad Soyad: 
    // Öğrenci Numarası: 


    // Soru 1: Karakteri yön tuşları ile hareket ettiren kodu, HareketEt fonksiyonu içerisine yazınız.
    // Soru 2: Karakterin zıplamasını sağlaması beklenen Zipla metodu doğru bir şekilde çalışmıyor, koddaki hatayı düzeltin.
    // Soru 3: Karakterin 'Engel' tag'ine sahip objeye temas ettiğinde metin objesine "Oyun Bitti!" yazısını yazdırınız.
    // Soru 4: Karakterin 'Puan' tag'ine sahip objeye temas ettiğinde skoru 1 arttırınız ve metin objesine yazdırınız.

    // Not: Engel ve Puan nesnelerinin isTrigger özelliği aktiftir.


    public TMP_Text metin;
    private Rigidbody2D karakterRb;

    public float hiz = 5f;
    public float ziplamaGucu = 5f;

    public int skor = 0;

    void Start()
    {
        karakterRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HareketEt();
        Zipla();

    }

    void HareketEt()
    {
        if (Input.GetKey(KeyCode.D))
        {
            karakterRb.AddForce(UnityEngine.Vector2.left * ( hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.A))
        {
            karakterRb.AddForce(UnityEngine.Vector2.right * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            karakterRb.AddForce(UnityEngine.Vector2.up * (hiz * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.S))
        {
            karakterRb.AddForce(UnityEngine.Vector2.down * (hiz * Time.deltaTime));
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Soru 3 ve soru 4 burada çözülecek.
        if (other.gameObject.CompareTag("Engel"))
        {
            Debug.Log("Oyun Biti");
           
        }
        if (other.gameObject.CompareTag("Puan")) 
        {
            Destroy(other.gameObject);
            skor++;
            metin.text = "skor:" + skor;
        }
    }

    void Zipla()
    {
        // Space tuşuna basınca karakter zıplamalı ancak aşağıdaki kod hatalı.
        if (Input.GetKey(KeyCode.Space))
        {
            karakterRb.AddForce(UnityEngine.Vector2.up * (ziplamaGucu * Time.deltaTime));
        }
    }
}