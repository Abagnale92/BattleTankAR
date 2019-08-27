using UnityEngine;


public class Fuoco2 : MonoBehaviour
{
            
    public Rigidbody m_Shell;
    public Transform m_FireTransform;

    private string m_FireButton;                // The input axis that is used for launching shells.
    private float m_ChargeSpeed;                // How fast the launch force increases, based on the max charge time.
    private bool m_Fired;                       // Whether or not the shell has been launched with this button press.




    void Start()
    {
        m_FireButton = "Fire2";

        // The rate that the launch force charges up is the range of possible forces by the max charge time.
        m_ChargeSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown(m_FireButton))
        {

            m_Fired = false;



        }


        else if (Input.GetButtonUp(m_FireButton) && !m_Fired)
        {

            Fire();
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
        shellInstance.velocity = m_ChargeSpeed * m_FireTransform.forward; ;


    }
}