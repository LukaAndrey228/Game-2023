using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DebugController : MonoBehaviour
{

    bool showConsole = true;
    bool showHelp;

    string input = "";

    public static DebugCommand<int> MOVE_LEFT; //в видосе второй код
    public static DebugCommand<int> MOVE_DOWN; //в видосе второй код
    public static DebugCommand<int> MOVE_RIGHT; //в видосе второй код
    public static DebugCommand<int> MOVE_UP; //в видосе второй код
    public static DebugCommand HELP; //в видосе второй код
    public static DebugCommand RESTART; //в видосе второй код
    public static DebugCommand PACKET; //в видосе второй код
    public bool myObject;
    public GameObject image_Box;
    private GameObject exit;
    //private GameObject children;



    public List<object> commandList;

    GameObject PlayerObj;


    public void mover(int x, int y) {
        Player PlayerClass = PlayerObj.GetComponent<Player>();
        PlayerClass.horizontal = x;
        PlayerClass.vertical = y;

    }

    public void openQuestForm()
    {
        GameObject QuestionsForm = GameObject.FindWithTag("Questions");
        Vector3 positionForm = QuestionsForm.transform.position;

        QuestionsForm.transform.position = new Vector3(positionForm.x, positionForm.y, 0);

       
    }


    private void Awake(){ //в видосе второй код
        PlayerObj = GameObject.Find("Player");
        image_Box = GameObject.Find("image_Box");
        image_Box.SetActive(showHelp);

        MOVE_LEFT = new DebugCommand<int>("move_left", "Removes all heroes from the scene.", "move_left", (int step) =>
        {
            StartCoroutine(MovePlayerByStep(step, -1, 0));
        });
        MOVE_DOWN = new DebugCommand<int>("move_down", "Removes all heroes from the scene.", "move_down", (int step) =>
        {
            StartCoroutine(MovePlayerByStep(step, 0, -1));

        });
        MOVE_RIGHT = new DebugCommand<int>("move_right", "Removes all heroes from the scene.", "move_right", (int step) =>
        {
            StartCoroutine(MovePlayerByStep(step, 1, 0));
        });
        MOVE_UP = new DebugCommand<int>("move_up", "Removes all heroes from the scene.", "move_up", (int step) =>
        {
            StartCoroutine(MovePlayerByStep(step, 0, 1));
        });

        HELP = new DebugCommand("help", "Shows a list of commands", "help", () =>
        {
            Debug.Log("HELP");
            showHelp = true;
            image_Box.SetActive(showHelp);
        });
        RESTART = new DebugCommand("restart", "Shows a list of commands", "restart", () =>
        {
            GameManager.instance.GameRestart();

        });
        // 
        PACKET = new DebugCommand("packet", "Shows a list of commands", "packet", () =>
        {
            
            Player PlayerClass = PlayerObj.GetComponent<Player>();

            GameObject packet = PlayerClass.findNearObject("Wall",15);//TODO

            if (packet!=null) 
            {
                PlayerClass.currentPacket = packet;
                openQuestForm();
                PlayerClass.generateQuestion();
            }
        });

        commandList = new List<object>
        {
            MOVE_LEFT,MOVE_DOWN,MOVE_RIGHT,MOVE_UP,HELP,RESTART,PACKET
         };
    }                


    private void OnGUI()
    {
        float y=0f;

        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);

        if (Event.current.type == EventType.KeyDown && Event.current.character == '\n')
        {
            HandleInput();
            input = "";
        }
    }

    private void HandleInput()
    {
        string[] properties = input.Split(' ');

        int step = 0;

        

        for (int i = 0; i<commandList.Count; i++ )
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;
            
            if (input.Contains(commandBase.commandId))
            {
                if (commandBase.commandIsGenerated)
                {
                    bool isNumeric = int.TryParse(properties[1], out step);
                    (commandList[i] as DebugCommand<int>).command.Invoke(step);
                    
                }
                else
                {
                    
                    (commandList[i] as DebugCommand).command.Invoke();
                }

            }

        }
    }

    IEnumerator MovePlayerByStep(int step,int x,int y)
    {
        float turnDelay =.25f;
        yield return new WaitForSeconds(turnDelay);
        if (step == 0)
        {
            yield return new WaitForSeconds(turnDelay);
        }

        for (int i = 0; i < step; i++)
        {
            mover(x, y);
            yield return new WaitForSeconds(turnDelay);
        }

       
    }

}
