using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Logger logger;

    // Update is called once per frame
    void Update()
    {
        if (InputUtilities.fireButtonPushed())
        {
            logger.Log("FIRE!",this);
        }
    }

    

}
