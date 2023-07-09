using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;


public class PlayerBasics : MonoBehaviour, ISubject
{


    public static PlayerBasics instance;

    public Player _scriptablePlayer;
    private Renderer _renderer;
    private Animator _animator;
    public GameObject shiel;
    public bool shieldState;
    
    public int life;
    public int currency;

    #region ChargeScriptableObject

    public void chargeScriptableObject()
    {
        life = _scriptablePlayer._life;
        //_renderer.material = _scriptablePlayer._Material[0];
    }

    #endregion

    private void Awake()
    {
        instance = this;
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        chargeScriptableObject();
        currency = StaticVar.Currency;
        SetLife(StaticVar.Life);
    }

    public void AddToLife(int AmountLife)
    {
        life = life + AmountLife;
        StaticVar.Life = life;
    }

    #region observer

    List<Iobserver> observers = new List<Iobserver>();

    public void NotifyTo(string ActionToMake)
    {
        for (int i = 0; i < observers.Count; i++)
        {
            observers[i].OnNotify(ActionToMake);
        }
    }

    public void Subscribe(Iobserver ObserverName)
    {
        if (!observers.Contains(ObserverName))
        {
            observers.Add(ObserverName);
        }
    }

    public void Unsuscribe(Iobserver ObserverName)
    {
        if (observers.Contains(ObserverName))
        {
            observers.Remove(ObserverName);
        }
    }

    private void Update()
    {
        if (life <= 0)
        {
            Time.timeScale = 0;
            AudioManager.instance.stop("MainTheme");
        }
    }

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") && StaticVar.IsDestructable == true)
        {
            if (shieldState == false)
            {
                if (life > 0)
                {
                    life = life - 1;
                    NotifyTo("GetHit");
                    AudioManager.instance.play("GetHit");
                }

                if (life <= 0)
                {
                    AudioManager.instance.play("GameOver");
                    NotifyTo("PlayerDied");
                }

            }
            else
            {
                AudioManager.instance.play("BlockDamage");
                ShieldState(false);

            }
        }

        if (other.gameObject.TryGetComponent(out IEnemyToSpawn enemyToSpawn))
        {
            if (other.gameObject.CompareTag("BooEnemy") && StaticVar.IsDestructable == true)
            {
                if (shieldState == true)
                {
                    ShieldState(false);
                }
                else
                {
                    life = life - 1;
                }
                SubstractCoins(5);
                AudioManager.instance.play("BooSound");
                NotifyTo("LooseCoins");

            }

            if (other.gameObject.CompareTag("FrozenEn") && StaticVar.IsDestructable == true)
            {
                if (shieldState == true)
                {
                    ShieldState(false);
                }
                else
                {
                    life = life - 1;
                    NotifyTo("GetHit");
                    AudioManager.instance.play("GetHit");
                    
                }
                StartCoroutine("FreezeEffect");
                Debug.Log(StaticVar.CanMove);

            }
            var e = other;
            
        }

        if (other.gameObject.TryGetComponent(out IUpgradeToSpawn upgradeToSpawn))
        {
            
            if (other.gameObject.CompareTag("Coin"))
            {
                AddCoins(1);
                NotifyTo("GetCoin");
                AudioManager.instance.play("PickCoin");
            }

            if (other.gameObject.CompareTag("LifeUpg"))
            {
                if (StaticVar.Life >= 3)
                {
                    
                }
                else
                {
                    AddToLife(1);
                }
                NotifyTo("GetLife");
                AudioManager.instance.play("PickALife");

            }

            if (other.gameObject.CompareTag("ShieldUpg"))
            {
                ShieldState(true);
                AudioManager.instance.play("GetShield");
            }
            
            if (other.gameObject.CompareTag("UnbreakableEn"))
            {
                StartCoroutine(Indestrable());
                AudioManager.instance.play("GetShield");
            }
        }

        //Switch

    }

    IEnumerator Indestrable()
    {
        StaticVar.IsDestructable = false;
        _animator.SetBool("Unbreak",true);
        yield return new WaitForSeconds(3f);
        StaticVar.IsDestructable = true;
        _animator.SetBool("Unbreak",false);
    }

    IEnumerator FreezeEffect()
    {
        SetMovement(false);
        yield return new WaitForSeconds(3f);
        SetMovement(true);
    }
    public void ShieldState(bool shieldstate)
    {
        shiel.SetActive(shieldstate);
        shieldState = shieldstate;
    }

    public void AddCoins(int amountToGet)
    {
        currency = currency + amountToGet;
        StaticVar.Currency = currency;
    }

    public void SubstractCoins(int amountToSubstract)
    {
        if (currency - amountToSubstract < 0)
        {
            currency = 0;
        }

        StaticVar.Currency = currency;
    }

    public void SetCurrency(int value)
    {
        if (StaticVar.Currency <= 0)
        {
            currency = 0;
        }
        else
        {
            currency = value;
        }

        StaticVar.Currency = currency;
        NotifyTo("GetCoin");
    }

    public void SetLife(int value)
    {
        life = value;
        NotifyTo("GetLife");
    }

    public void SetMovement(bool a)
    {
        StaticVar.CanMove = a;
    }
    

}
