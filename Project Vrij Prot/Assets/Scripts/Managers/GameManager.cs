using System;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GamePhase { NotStarted, Water, TreeBuilder, Birds}

    [HideInInspector] public GamePhase CurrentPhase = GamePhase.NotStarted;
    public Camera treeBuildCamera;
    public Camera birdCamera;
    public Layer[] Layers;

    public int CurrentHeight { get; private set; }

    public static event Action LayerChange;
    public static event Action<GamePhase> PhaseChange;

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
        CurrentPhase = GamePhase.NotStarted;
        numOfLayers = Layers.Length;

        if (!CutsceneManager.Instance.PlayIntroCutscene)
        {
            StartGame();
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused)
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

    private void OnEnable()
    {
        PhaseChange += SwitchCamera;
    }
    private void OnDisable()
    {
        PhaseChange -= SwitchCamera;
    }

    public void StartGame()
    {
        CurrentPhase = GamePhase.TreeBuilder;
        currentLayer = Layers[0];

        movement.SetSpeed(currentLayer.printerSpeed);
        movement.currentWaypointSet = currentLayer.waypoints;   // Make a setter
        currentLayer.gameObject.SetActive(true);
        movement.StartMovement();
    }

    public void MoveToNextLayer()
    {
        if (currentLayerIndex < numOfLayers - 1)
        {
            // Do things with the layer that is over
            if (currentLayer.IncreaseHeightAfterLayer)
            {
                IncreaseCurrentHeight();
                MoveCamUp();
            }
            currentLayer.gameObject.SetActive(false);

            // Assign new Layer
            currentLayerIndex++;
            currentLayer = Layers[currentLayerIndex];

            // Do things with new layer
            currentLayer.transform.SetYPosition(CurrentHeight);
            currentLayer.gameObject.SetActive(true);
            movement.SetSpeed(currentLayer.printerSpeed);
            movement.StartNewLayer(currentLayer.waypoints);
            LayerChange?.Invoke();

        }
        else
        {
            // Zoom out and hide all the layers. Disable movement script.
            Layers[currentLayerIndex].gameObject.SetActive(false);
            treeBuildCamera.orthographicSize = 10;
            movement.gameObject.SetActive(false);
        }
    }

    public void PauseGame()
    {
        if (CurrentPhase == GamePhase.NotStarted) return;

        isPaused = true;
        movement.PauseMovement();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        if (CurrentPhase == GamePhase.NotStarted)
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

    private void MoveCamUp()
    {
        treeBuildCamera.transform.position += Vector3.up;
        birdCamera.transform.position += Vector3.up;
    }

    private void SwitchCamera(GamePhase phase)
    {
        if(phase == GamePhase.TreeBuilder)
        {
            treeBuildCamera.gameObject.SetActive(true);
            birdCamera.gameObject.SetActive(false);
        } 
        else if (phase == GamePhase.Birds) {
            birdCamera.gameObject.SetActive(true);
            treeBuildCamera.gameObject.SetActive(false);
        }
    }
}
