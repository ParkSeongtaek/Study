using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   

    


    static GameManager _instance;
    public static GameManager instance { get { Init(); return _instance; } }

    SoundManager _soundManager = new SoundManager();
    
    public SoundManager soundManager { get { Init(); return _soundManager; } }

    InputManager _inputManager = new InputManager();
    public InputManager inputManager { get { Init(); return _inputManager; } }


    UiManager _uiManager = new UiManager();
    public UiManager uiManager { get { Init(); return _uiManager; } }


    [SerializeField]
    GameObject _player;
    public  GameObject player { get { Init(); return _player; } }





    static void Init()
    {
        if (_instance == null)
        {
            GameObject GM = GameObject.Find("GameManager");
            if (GM == null)
            {
                GM = new GameObject { name = "GameManager" };
                GM.AddComponent<GameManager>();
            }
            DontDestroyOnLoad(GM);
            _instance = GM.GetComponent<GameManager>();

            _instance._soundManager.Init();
            _instance._uiManager.Init();
            _instance._inputManager.Init();


            if (_instance._player == null)
            {
                _instance._player = Resources.Load<GameObject>("Prefab/Player");
                _instance._player = Instantiate(_instance._player, Vector3.zero, new Quaternion());
            }
        }
    }

    private void Awake()
    {
        Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instance.inputManager.InputUpdate();
    }
}
