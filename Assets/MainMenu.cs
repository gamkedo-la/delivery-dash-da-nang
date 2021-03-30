using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject main, gamecreation;
    public GameObject clickStartButtonInvisible, creditsButton;

    public static int playerCount;
    public Text playerCountstring;

    public GameObject player1, player2, player3, player4;
    public static int player1Character, player2Character, player3Character, player4Character;
     
    public GameObject level;
    LevelLoader levelLoader;

    public bool characterSelectionScreenIsActuallyFocusedOn = false;

    public GameObject audioManager;


    public GameObject titleScreenMusic;
    public AudioSource titleScreenMusicAudioSource;
    TitleScreenFadeOut titleScreenFadeOutScript;

    public AudioClip phoneButtonPressedAudioClip;

    public GameObject invisibleButton;


    private void Start()
    {
        titleScreenFadeOutScript = titleScreenMusic.GetComponent<TitleScreenFadeOut>();
        titleScreenMusicAudioSource = titleScreenMusic.GetComponent<AudioSource>();
        Time.timeScale = 1;
        playerCount = 1;

        audioManager.SetActive(false);
    }

    private void Update()
    {
        if (playerCount == 1)
        {
            player1.SetActive(true);
            player2.SetActive(false);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (playerCount == 2)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(false);
            player4.SetActive(false);
        }

        if (playerCount == 3)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(false);
        }

        if (playerCount == 4)
        {
            player1.SetActive(true);
            player2.SetActive(true);
            player3.SetActive(true);
            player4.SetActive(true);
        }

        //if (Input.anyKeyDown)
        //{
        //    GameCreate();
        //}
    }

    public void GameCreate()
    {
        main.SetActive(false);
        gamecreation.SetActive(true);
        characterSelectionScreenIsActuallyFocusedOn = true;
        //AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, main, volume: 0.5f);
    }

    public void gameCreateBack()
    {
        main.SetActive(true);
        gamecreation.SetActive(false);
        characterSelectionScreenIsActuallyFocusedOn = false;
    }

    public void startGame()
    {

        //save player character 
        //save player count (this is stored in playerCount)
        print("PlayerCount:" + playerCount);
        print("Player1Char:" + player1Character);
        print("Player2Char:" + player2Character);
        print("Player3Char:" + player3Character);
        print("Player4Char:" + player4Character);
        level.SetActive(true);
        levelLoader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
        levelLoader.LoadNextLevel();

        //audioManager.GetComponent<MusicManager>().


        //StartCoroutine()
        //.musicPrefab.GetComponent<AudioSource>()
        
        
        MusicManager musicManagerScript = audioManager.GetComponent<MusicManager>();

        StartCoroutine(TitleScreenFadeOut.FadeOut(titleScreenMusicAudioSource, 1f));
        StartCoroutine(DelayMainMusicBecauseLoadingTime());

        //StartCoroutine(musicManagerScript.StebsFadeIn(musicManagerScript.currentAudioSource, 9f, audioManager));
        StartCoroutine(musicManagerScript.FadeIn(musicManagerScript.musicPrefab.GetComponent<AudioSource>(), 5f));
    }

    IEnumerator DelayMainMusicBecauseLoadingTime()
    {
        yield return new WaitForSeconds(1.5f);
        audioManager.SetActive(true);
        
    }

    public void HandleStartButton()
    {
        if(clickStartButtonInvisible) {
            clickStartButtonInvisible.SetActive(false);
        }
        if(creditsButton) {
            creditsButton.SetActive(false);
        }
        if (main.activeSelf)
        {
            GameCreate();
        }
        else if (gamecreation.activeSelf)
        {
            startGame();
        }
    }

    public void increasePlayerCount()
    {
        //AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject, volume: 0.5f);

        playerCount++;
        if (playerCount > 4)
        {
            playerCount = 1;
        }
        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }

    public void decreasePlayerCount()
    {
        //AudioManager.Instance.PlaySoundSFX(phoneButtonPressedAudioClip, gameObject, volume: 0.5f);

        playerCount--;
        if (playerCount < 1)
        {
            playerCount = 4;
        }

        playerCountstring.text = "Player Count: " + playerCount.ToString();
    }
}
