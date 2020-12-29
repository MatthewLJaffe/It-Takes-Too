using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public static Player instance;
    public static Camera mainCamera;
    public static Transform cameraTarget;
    public static Transform IT;
    public UnityEvent OnRespawn;

    public Camera mainCam;
    public Transform camTarget;
    public Transform it;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        if (mainCamera == null)
        {
            mainCamera = mainCam;
        }
        else
        {
            Destroy(mainCam.gameObject);
        }

        if (cameraTarget == null)
        {
            cameraTarget = camTarget;
        }
        else
        {
            Destroy(camTarget.gameObject);
        }

        if (IT == null)
        {
            IT = it;
        }

        DontDestroyOnLoad(gameObject);

        mainCamera.transform.parent = null;
        DontDestroyOnLoad(mainCamera.gameObject);
    }

    public void respawn()
    {
        GetComponent<Health>().healToFull();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        OnRespawn.Invoke();
    }
}
