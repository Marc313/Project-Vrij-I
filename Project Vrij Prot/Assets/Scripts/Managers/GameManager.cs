using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public enum GameState { NOTSTARTED, STARTED, ENDED }

    [HideInInspector] public GameState state = GameState.NOTSTARTED;
    public Camera treeBuildCamera;
    public Camera birdCamera;
    public Layer[] Layers;

    public int CurrentHeight { get; private set; }

    public static event Action LayerChange;
    public static event Action<GameState> PhaseChange;

    private static int numOfLayers;
    public static int currentLayerIndex;

    private bool isPaused;
    private PathMovement movement;
    public Layer currentLayer;

    private void Awake()
    {
        Instance = this;
        movement = FindObjectOfType<PathMovement>();
    }

    private void Start()
    {
        state = GameState.NOTSTARTED;
        numOfLayers = Layers.Length;

        if (!CutsceneManager.Instance.PlayIntroCutscene)
        {
            StartGame();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                UnpauseGame();
                isPaused = false;
            } else
            {
                PauseGame();
                isPaused = true;
            }
        }
    }

    public void StartGame()
    {
        state = GameState.STARTED;
        currentLayer = Layers[0];

        movement.SetSpeed(currentLayer.printerSpeed);
        movement.currentWaypointSet = currentLayer.waypoints;   // Make a setter
        currentLayer.gameObject.SetActive(true);
        movement.StartMovement();
    }

    public void MoveToNextLayer()
    {
        LayerChange?.Invoke();
        if (currentLayerIndex < numOfLayers - 1)
        {
            // Do things with the layer that is over
            if (currentLayer.IncreaseHeightAfterLayer)
            {
                IncreaseCurrentHeight();
                MoveCamUp();
            }

            ChangeLayer();
        }
        else
        {
            state = GameState.ENDED;
            // Zoom out and hide all the layers. Disable movement script.
            Layers[currentLayerIndex].gameObject.SetActive(false);
            CameraZoomOut();
            movement.gameObject.SetActive(false);

            // Check for endings
            ShowEnding();
        }
    }

    private void ShowEnding()
    {
        RelationBarManager.Ending ending = RelationBarManager.Instance.DecideEnding();

        if (ending == RelationBarManager.Ending.BOOMMACHT)
        {
            CutsceneManager.Instance.PlayMachtEnding();
        }
        else if (ending == RelationBarManager.Ending.NATURE)
        {
            CutsceneManager.Instance.PlayNatureEnding();
        }
    }

    private void ChangeLayer()
    {
        currentLayer.gameObject.SetActive(false);

        // Assign new Layer
        currentLayerIndex++;
        currentLayer = Layers[currentLayerIndex];

        // Do things with new layer
        currentLayer.transform.SetYPosition(CurrentHeight);
        currentLayer.gameObject.SetActive(true);
        movement.SetSpeed(currentLayer.printerSpeed);
        movement.StartNewLayer(currentLayer.waypoints);
        GridManager.Instance.currentLayer = currentLayer;
    }

    private void CameraZoomOut()
    {
        treeBuildCamera.orthographicSize = 13;
        treeBuildCamera.transform.position -= Layers.Length/2 * Vector3.up;
    }

    public void PauseGame()
    {
        if (state == GameState.NOTSTARTED) return;

        isPaused = true;
        movement.PauseMovement();
    }

    public void UnpauseGame()
    {
        if (state == GameState.ENDED)
        {
            LoadMenu();
            return;
        }

        isPaused = false;
        if (state == GameState.NOTSTARTED)
        {
            StartGame();
        } else
        {
            movement.ContinueMovement();
        }
    }

    public void StartHiveMovement(float moveSpeed)
    {
        movement.SetSpeed(moveSpeed);
    }

    public void StopHiveMovement()
    {
        float currentLayerSpeed = currentLayer.printerSpeed;
        movement.SetSpeed(currentLayerSpeed);
    }

    public void IncreaseCurrentHeight()
    {
        CurrentHeight++;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void MoveCamUp()
    {
        treeBuildCamera.transform.position += Vector3.up;
        birdCamera.transform.position += Vector3.up;
    }
}
