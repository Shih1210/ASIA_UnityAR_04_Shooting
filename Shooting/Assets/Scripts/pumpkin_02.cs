using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pumpkin_02 : MonoBehaviour
{
    public static Transform target;

    [Header("南瓜旋轉部位")]
    public Transform pumpkin_02Rotation;
    [Header("閃爍")]
    public ParticleSystem psShine;
    [Header("血量"), Range(100, 500)]
    public float hp;
    [Header("血條")]
    public Image hpBar;
    [Header("結束畫面")]
    public GameObject final;
    [Header("數量")]
    public Text textCount;

    private int count;
    private float hpMax;

    private void Start()
    {
        hpMax = hp;
    }

    private void Update()
    {
        Attack();
    }

    private void Attack()
    {
        if(target && hp > 0)
        {
            Vector3 pos = target.position;
            pos.y = pumpkin_02Rotation.position.y;
            psShine.Play();

            pumpkin_02Rotation.LookAt(pos);

            count++;

        }
    }

    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / hpMax;

        if (hp <= 0)
        {
            final.SetActive(true);
            textCount.text = "擊殺怪物數量:" + count;
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene("遊戲場景");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
