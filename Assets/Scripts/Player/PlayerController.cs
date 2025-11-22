using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class PlayerController : Singleton<PlayerController>
{   
    //publics
    [Header("Lerp")]
    public Transform target;
    public float lerpSpeed = 1f;

    public float speed = 1f;

    public string tagToCheckEnemy = "Enemy";
    public string tagToCheckEndLine = "EndLine";

    public GameObject endScreen;

    public TextMeshPro uiTextPowerUp;

    public bool invencible = false;

    [Header("Coin Setup")]
    public GameObject coinCollector;


    [Header("Aniamtion")]
    public AnimationManager animationManager;
    private bool _isDead = false;

    [Header("VFX")]
    public ParticleSystem vfxDeath;

    [Header("Limits")]
    public float limit = 4;


    //privates
    private bool _canRun;
    private Vector3 _pos;
    private float _currentSpeed;
    private Vector3 _startPosition;
    private float _baseSpeedToAnimation = 9;

    [SerializeField] private BounceHelper _bounceHelper;

    private void Start()
    {
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 1f).SetEase(Ease.OutBack);
        _startPosition = transform.position;
        ResetSpeed();
    }

    public void Bounce()
    {
        if(_bounceHelper != null)
        _bounceHelper.Bounce();
    }

    public void OnJump()
    {
        transform.DOScale(0.8f, 0.2f).SetEase(Ease.InOutSine).OnComplete(() =>
        {
            transform.DOScale(1, 0.2f).SetEase(Ease.InOutSine);
        });
    }

    void Update()
    {
        if (!_canRun) return;

        _pos = target.position;
        _pos.y = transform.position.y;
        _pos.z = transform.position.z;

        if (_pos.x < -limit) _pos.x = -limit;
        else if (_pos.x > limit) _pos.x = limit;

        transform.position = Vector3.Lerp(transform.position, _pos, lerpSpeed * Time.deltaTime);
        transform.Translate(transform.forward * _currentSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == tagToCheckEnemy)
        {
            if (!invencible)
            {
                MoveBack(collision.transform);
                EndGame(AnimationManager.AnimationType.DEATH);
            }
        }
    }

    private void MoveBack(Transform t)
    {
        t.DOMoveZ(1f, .3f).SetRelative();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheckEndLine)
        {
            if (!invencible) EndGame();
        }
    }

    private void EndGame(AnimationManager.AnimationType animationType = AnimationManager.AnimationType.IDLE)
    {
        if (_isDead) return;

        _isDead = true;

        _canRun = false;
        endScreen.SetActive(true);
        animationManager.Play(animationType);
        if(vfxDeath != null) vfxDeath.Play();
    }

    public void StartToRun()
    {
        _canRun = true;
        animationManager.Play(AnimationManager.AnimationType.RUN, _currentSpeed / _baseSpeedToAnimation);
    }

    #region POWER UPS
    public void OnPowerUpCollected()
    {
        transform.DOScale(1.2f, 0.3f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            transform.DOScale(1, 0.3f).SetEase(Ease.OutBack);
        });
    }


    public void SetPowerUpText(string s)
    {
        uiTextPowerUp.text = s;
    }

    public void PowerUpSpeedUp(float f)
    {
        _currentSpeed = f;
    }

    public void ResetSpeed()
    {
        _currentSpeed = speed;
    }

    public void SetInvencible(bool b = true)
    {
        invencible = b;
    }

    public void ChangeHeight(float amount, float duration, float animationDuration, Ease ease)
    {
        /*var p = transform.position;
        p.y = _startPosition.y + amount;
        transform.position = p;*/

        transform.DOMoveY(_startPosition.y + amount,animationDuration).SetEase(ease);
        //.OnComplete(ResetHeight);a
        Invoke(nameof(ResetHeight), duration);
    }

    public void ResetHeight()
    {
        transform.DOMoveY(_startPosition.y, .1f);
    }

    public void ChangeCoinCollectorSize(float amount)
    {
        coinCollector.transform.localScale = Vector3.one * amount;
    }
    #endregion
}

