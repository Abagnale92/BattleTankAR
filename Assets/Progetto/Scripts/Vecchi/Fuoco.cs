using UnityEngine;
using UnityEngine.UI;

public class Fuoco : MonoBehaviour {
    public int m_PlayerNumber = 1;              // Used to identify the different players.
    public Rigidbody m_Shell;
    public Transform m_FireTransform;

    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.
    float shoottimer = 0.0f;
    float setShootTimerTo = 0.5f;


    void Start() {
        m_FireButton = "Fire" + m_PlayerNumber;

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        m_ChargeSpeed = 1000;
    }

    // Update is called once per frame
    void Update()
    {

        shoottimer -= Time.deltaTime;
        if (Input.GetButtonDown(m_FireButton))
        {

            m_Fired = false;



        }


        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {
            if (shoottimer <= 0)
            {
                Fire();
                shoottimer = setShootTimerTo;
            }
        }

    }
        private void Fire()
        {
            // Set the fired flag so only Fire is only called once.
            m_Fired = true;

            // Create an instance of the shell and store a reference to it's rigidbody.
            Rigidbody shellInstance =
                Instantiate(m_Shell, m_FireTransform.position, m_FireTransform.rotation) as Rigidbody;


            // Set the shell's velocity to the launch force in the fire position's forward direction.
            shellInstance.velocity = new Vector3()*m_ChargeSpeed;


        }

       

    }

