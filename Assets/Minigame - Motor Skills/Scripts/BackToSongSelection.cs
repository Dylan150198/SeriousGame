using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToSongSelection : MonoBehaviour
{
    public Animator animator;
    public Image black;

    public void onButtonClick()
    {
        StartCoroutine(FadingLoadingScreen());
    }

    private IEnumerator FadingLoadingScreen()
    {
        animator.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        SceneManager.LoadScene("MotorSkills_SongSelection", LoadSceneMode.Single);
    }
}
