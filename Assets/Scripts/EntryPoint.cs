using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    public string entryName;

    private void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        if (Player.instance.GetComponent<SceneEnter>().entryPointNameToGoTo.Equals(entryName))
        {
            Player.instance.transform.position = transform.position;
            Player.instance.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.mainCamera.transform.position = 
                new Vector3(Player.cameraTarget.position.x,
                            Player.cameraTarget.position.y,
                            Player.mainCamera.transform.position.z);
        }
    }
}
