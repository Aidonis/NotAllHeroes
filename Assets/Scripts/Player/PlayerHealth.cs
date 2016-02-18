using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public LivingEntity player;

    private Text m_playerHealth;


	// Use this for initialization
    void Start()
    {
        m_playerHealth = GetComponent<Text>();
    }
	// Update is called once per frame
	void Update ()
	{
	    m_playerHealth.text = "Health:" + player.health;
	}
}
