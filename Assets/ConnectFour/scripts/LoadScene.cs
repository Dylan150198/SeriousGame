using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    private bool loadScene = false;

    [SerializeField]
    private string scene;
    
    [SerializeField]
    private Text loadingText;

    [SerializeField] 
    private TextMeshProUGUI instructions;

    private int step = 0;


    // Updates once per frame
    void Update() {

        // If the player has pressed the space bar and a new scene is not loading yet...
        if (Input.GetMouseButtonUp(0) && loadScene == false)
        {
            step++;
            if (step == 1)
            {
                instructions.text = "Het doel is om met zo min mogelijk stafpunten te winnen. je stafpunten gaan elke seconde, en na elke beurt omhoog. ";
            }
            
            if (step == 2)
            {
                instructions.text = "In deze versie van 4-op-een-rij is het iets moeilijker dan normaal, je kunt namelijk niet het verschil in de kleuren zien. als je een hint nodig hebt zal deze automatisch activeren na een aantal seconden wachten. (maar dit kost wel een hoop strafpunten).";
            }

            if (step == 3)
            {
                // ...set the loadScene boolean to true to prevent loading a new scene more than once...
                loadScene = true;
            
                // ...change the instruction text to read "Loading..."
                loadingText.text = "Loading...";

                // ...and start a coroutine that will load the desired scene.
                StartCoroutine(LoadNewScene());
            }

        }

        // If the new scene has started loading...
        if (loadScene == true) {

            // ...then pulse the transparency of the loading text to let the player know that the computer is still working.
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

        }

    }


    // The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
    IEnumerator LoadNewScene() {

        // This line waits for 3 seconds before executing the next line in the coroutine.
        // This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
        yield return new WaitForSeconds(1);

        // Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
        AsyncOperation async = SceneManager.LoadSceneAsync(scene);

        // While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
        while (!async.isDone) {
            yield return null;
        }

    }

}