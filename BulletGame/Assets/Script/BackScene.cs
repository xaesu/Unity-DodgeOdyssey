using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackScene : MonoBehaviour, IPointerClickHandler
{
    public string sceneName;

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(sceneName);
    }
}
