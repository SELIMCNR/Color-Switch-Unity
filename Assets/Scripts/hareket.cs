using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class hareket : MonoBehaviour
{

    public Rigidbody2D top;
    public float ziplamaGucu;
    public float yatayHiz; // Yatay hareket h�z�
    public Color turkuazRenk, Sar�Renk, morRenk, pembeRenk;
    public string mevcutRenk;
    public SpriteRenderer ressam;
    public Transform degistirici;
    public TextMeshProUGUI skorYazisi;
    public int skor;
    public AudioSource ziplamaSesi;

    public Transform cember1;
    public Transform cember2;
    public Transform kontrol1;
    public Transform kontrol2;

    public TextMeshProUGUI highScoreYazi;
    [SerializeField]
    public int highScore;

    private void Start()
    {
        highScoreYazi.text = "Y�ksek skor " + highScore.ToString();
        dondurme.donusHizi = 1f;
        RastgeleRenk();
        skor = 0;
    }

    // Update is called once per frame
    void Update()
    {

        skorYazisi.text = "Skor : " + skor;

        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            top.velocity = Vector2.up * ziplamaGucu; // bo�luk tu�una bas�nca yukar� z�pla
            ziplamaSesi.Play();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            top.velocity = new Vector2(-yatayHiz, top.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            top.velocity = new Vector2(yatayHiz, top.velocity.y); // sa�a hareket et
        }

        /* Mobil kontrol
         * 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            top.velocity = new Vector2(top.velocity.x, ziplamaGucu); // bo�luk tu�una bas�nca yukar� z�pla
        }

        float hareket = Input.GetAxis("Horizontal"); // Yatay hareket i�in mobil kontroller
        top.velocity = new Vector2(hareket * yatayHiz, top.velocity.y);

         */
        highScoreYazi.text = "Y�ksek skor " + highScore.ToString();
    }


    void OnTriggerEnter2D (Collider2D temas){
        //Temasa ge�ince 
        if (temas.tag != mevcutRenk && temas.tag != "RenkDegistirici" && temas.tag != "Kontrol1" && temas.tag != "Kontrol2")
        {
          
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        if(temas.tag == "RenkDegistirici")
        {
            skor++;
            degistirici.position = new Vector3 (degistirici.position.x, degistirici.position.y + 3.5f,degistirici.position.z);
            dondurme.donusHizi += 0.1f;
           // Destroy(temas.gameObject);
            RastgeleRenk();
            highScore = skor;
            highScoreYazi.text = "Y�ksek skor " + highScore.ToString();
        }

        if(temas.tag == "Kontrol1") { 
            kontrol1.position = new Vector3(kontrol1.position.x,kontrol1.position.y + 7f,kontrol1.position.z);   
            cember1.position = new Vector3(cember1.position.x,cember1.position.y + 7f, cember1.position.z);
        }
        if (temas.tag == "Kontrol2")
        {
            kontrol2.position = new Vector3(kontrol2.position.x, kontrol2.position.y + 7f, kontrol2.position.z);
            cember2.position = new Vector3(cember2.position.x, cember2.position.y + 7f, cember2.position.z);
        }
    }


    void RastgeleRenk()
    {
        int rastgele = Random.Range(0, 4);

        switch (rastgele)
        {
            case 0:
                mevcutRenk = "turkuaz";
                ressam.color = turkuazRenk;
                break;
            case 1:
                mevcutRenk = "sar�";
                ressam.color = Sar�Renk;
                break;
            case 2:
                mevcutRenk = "mor";
                ressam.color = morRenk;
                break;
            case 3:
                mevcutRenk = "pembe";
                ressam.color = pembeRenk;
                break;
        }
    }
}
