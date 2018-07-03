using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask WhatIsGround;
    [SerializeField] private bool m_AirControl = true;
    const float GroundedRadius = .2f;
    public Animator Anim;
    public float maxVelocidade;
    public float JumpForce;
    public static Rigidbody2D AdcForce;
    private Rigidbody2D corpo2D;
    private bool estaOlhandoParaDireita = true;
    public bool estaNaPlataforma = false;
    private bool estaNoChao;
    private Transform GroundCheck;
    private Vector3 posicao;
    private bool estaMorto = false;
    private bool pular;
    private SaveControler saveControler;
    public Text SaveGame;
    public AudioSource moveSfx;
    public AudioClip[] moveClipSfx;
    public AudioSource JumpSfx;
    public AudioSource DeathSfx;
    public float timeMove;
    private float atualTimeMove;
    private bool IsMuted = false;
   
        
   

    private void Awake()
    {
        saveControler = FindObjectOfType(typeof(SaveControler)) as SaveControler;
        saveControler.EscolherPosicaoInicial();
        if (PlayerPrefs.HasKey("VOLUME"))
            IsMuted = ((PlayerPrefs.GetInt("VOLUME") == 1) ? false : true);
        else 
            PlayerPrefs.SetInt("VOLUME", 1);
        AudioListener.volume = IsMuted ?0:1;

        
        GroundCheck = transform.Find("GroundCheck");

        corpo2D = GetComponent<Rigidbody2D>();
        AdcForce = GetComponent<Rigidbody2D>();
        SaveGame.enabled = false;
    }
    private void Start()
    {
        posicao = saveControler.GetPosicaoPlayer();
        this.transform.position = new Vector3(posicao.x, posicao.y, 0);
    }

    private void Update()
    {
        if (!estaNoChao && estaNaPlataforma)
        {
            LeavePlataforma();
        }
        if (!pular)
        {
            pular = CrossPlatformInputManager.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.Space);
        }

    }
    private void FixedUpdate()
    {

        estaNoChao = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                estaNoChao = true;
        }
        Anim.SetBool("estaNoChao", estaNoChao);

        if (!estaMorto)
        {
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            Move(h, pular);
            pular = false;
        }
    }
    public void Move(float move, bool jump)
    {
        if (estaNoChao || m_AirControl)
        {
            Anim.SetFloat("Velocidade", Mathf.Abs(move));
            corpo2D.velocity = new Vector2(move * maxVelocidade, corpo2D.velocity.y);
            atualTimeMove += Time.deltaTime;
            if ((Mathf.Abs(move) > 0.5f || Mathf.Abs(move) < -0.5f) && (atualTimeMove >= timeMove))
                SelectAudioPlay(moveClipSfx);
            if (move > 0 && !estaOlhandoParaDireita)
            {
                Girar();
            }
            else if (move < 0 && estaOlhandoParaDireita)
            {
                Girar();
            }
        }

        if (estaNoChao && jump && Anim.GetBool("estaNoChao"))
        {
            JumpSfx.Play();
            estaNoChao = false;

            Anim.SetBool("estaNoChao", false);
            corpo2D.velocity = (new Vector2(corpo2D.velocity.x, JumpForce));

        }
    }

    private void Girar()
    {
        estaOlhandoParaDireita = !estaOlhandoParaDireita;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void SelectAudioPlay(AudioClip[] audios)
    {
        float randomVolume = Random.Range(0.4f, 1f);
        int randomIndex = Random.Range(0, audios.Length);
        moveSfx.volume = randomVolume;
        moveSfx.clip = audios[randomIndex];
        if (!estaMorto && estaNoChao)
            moveSfx.Play();
        atualTimeMove = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Armadilha")
        {
            if (estaMorto == false)
            {
                Morrer();
            }
        }
        if (collision.gameObject.CompareTag("Save"))
        {
            SaveGame.enabled = true;
            saveControler.SetPosicaoPlayer(collision.transform.position);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Save"))
        {
            SaveGame.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Morrer();
        }
        if (collision.gameObject.CompareTag("Barril"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("AtivadorBarril");
        }
        if (collision.gameObject.CompareTag("PlataformaDestruivel"))
        {
            collision.gameObject.GetComponent<Animator>().SetTrigger("Destroy");
            StartCoroutine(Recriar(collision));
        }
        if (collision.gameObject.layer != 8 && estaNaPlataforma == true)
        {
            estaNaPlataforma = false;
        }
        if (collision.gameObject.layer == 9)
        {
            estaNaPlataforma = false;
        }
        if (collision.gameObject.layer == 8)
        {
            estaNaPlataforma = true;
            if (estaNaPlataforma)
            {
                transform.SetParent(collision.transform, true);
                estaNaPlataforma = true;
                CameraControler.estaNaPlataforma = true;
            }
        }

    }

    public void Morrer()
    {
        DeathSfx.Play();
        BoxCollider2D[] boxes = gameObject.GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D box in boxes)
        {
            box.enabled = false;
        }
        corpo2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        Time.timeScale = 0.5f;

        gameObject.GetComponentInChildren<Animator>().SetBool("Morreu", true);
        estaMorto = true;
        StartCoroutine(GameLose());
    }

    private void LeavePlataforma()
    {
        CameraControler.estaNaPlataforma = false;
        transform.SetParent(null);
    }
    public IEnumerator Recriar(Collision2D collision)
    {
        yield return new WaitForSecondsRealtime(2);
        collision.gameObject.GetComponent<Animator>().SetTrigger("Recriar");
        collision.gameObject.GetComponent<Animator>().ResetTrigger("Destroy");

    }
    public IEnumerator GameLose()
    {

        yield return new WaitForSecondsRealtime(2);
        GameControler.instance.MudarEstado(GAME_STATE.ENDGAMELOSE);

    }

}


