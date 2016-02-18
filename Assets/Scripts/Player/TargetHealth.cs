using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetHealth : MonoBehaviour {

    public LivingEntity player;

    private Text m_targetHealth;


    // Use this for initialization
    void Start()
    {
        m_targetHealth = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player.target != null && player.target.tag == "Enemy")
        {
            m_targetHealth.text = "Health:" + player.target.health;
        }
    }
}
