using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Tower : MonoBehaviour
{
    [Header("Shoot")]
    [SerializeField]private float triggerRange;
    [SerializeField] private float timeToShoot = 0.3f;
    [SerializeField] private Transform rotationPart;
    [SerializeField] private Transform shootPosition;
    [SerializeField] private Enemy currentTarget;
    [SerializeField] private Bullet bullet;
    [SerializeField] private List<Enemy> currentTargets = new List<Enemy>();

    [Header("Life")]
    [SerializeField] private Image fillLifeImage;
    [SerializeField] private float maxLife = 50;
    [SerializeField] private float currentLife = 0;
    [SerializeField] private bool isDead;

    private void Awake()
    {
        isDead = false;
    }
    private void Start()
    {
        currentLife = maxLife;
        StartCoroutine(ShootTimer());
    }
    private void Update()
    {
        if(GameManager.GM.isGameOver == false)
        {
            EnemyDetection();
            LookRotation();
        }
    }

    private void EnemyDetection()
    {
        
        //Lista de enemigos que traspasaron el rango de disparo
        currentTargets = Physics.OverlapSphere(transform.position, triggerRange).Where(currentEnemy => currentEnemy.GetComponent<Enemy>()).Select(currentEnemy => currentEnemy.GetComponent<Enemy>()).ToList();

        if (currentTargets.Count > 0)
        {
            currentTarget = currentTargets[0];
            
        }
            
        else if (currentTargets.Count == 0)
        {
            currentTarget = null;
        }
    }
    private void LookRotation()
    {
        if(currentTarget)
        {
           rotationPart.LookAt(currentTarget.transform);
        }
    }

    private void Shoot()
    {
        if(isDead == false)
        {
            var bulletGo = Instantiate(bullet, shootPosition.position, shootPosition.rotation);
            bulletGo.setBullet(currentTarget);
        }
        
    }

    private IEnumerator ShootTimer()
    {
        while(true)
        {
            if(currentTarget)
            {
                Shoot();
                yield return new WaitForSeconds(timeToShoot);
            }

            yield return null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position, triggerRange);
    }

    public void TakeDamage(float damage)
    {
        var newLife = currentLife - damage;
        if (isDead)
            return;

        if(newLife <= 0)
        {
            OnDead();
        }
        currentLife = newLife;

        var fillvalue = currentLife * 1 / 50;
        fillLifeImage.fillAmount = fillvalue;
    }

    private void OnDead()
    {
        isDead = true;
        currentLife = 0;
        fillLifeImage.fillAmount = 0;
        GameManager.GM.isGameOver = true;
        UIManager.uiManager.gameOver.SetActive(true);
        UIManager.uiManager.restart.SetActive(true);
        UIManager.uiManager.menu.SetActive(true);

    }
}
