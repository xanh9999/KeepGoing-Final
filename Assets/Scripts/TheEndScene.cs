using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEndScene : MonoBehaviour
{
    
    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(8);
        SceneManager.LoadScene("The End");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(ChangeScene());
        }
    }
}
