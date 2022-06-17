using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    #region Singleton
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject[] rooms;
    public GameObject currRoom;

    public List<GameObject> enemiesInRoom;

    bool doorAreDisabled;

    private void Start()
    {
        OpenRoom();
    }

    public void OpenRoom()
    {
        foreach(GameObject r in rooms)
        {
            if(r.name != currRoom.name)
            {
                r.SetActive(false);
            }
            else
            {
                r.SetActive(true);
            }
        }
        
        enemiesInRoom.Clear();
        enemiesInRoom.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));

        if(enemiesInRoom.Count > 0)
        {
            DoorsManagment(false);
        } else
        {
            DoorsManagment(true);
        }
    }

   void Update()
    {
        if(enemiesInRoom.Count == 0 && doorAreDisabled)
        {
            Debug.Log("No enemies");
            DoorsManagment(true);
        }
    }

    public void NextRoom(GameObject room)
    {
        currRoom = room;
        OpenRoom();
    }

    public void DoorsManagment(bool state)
    {
        doorAreDisabled = !state;

        Door[] doorsInRoom = Resources.FindObjectsOfTypeAll<Door>();

        foreach (Door d in doorsInRoom)
        {
            d.gameObject.SetActive(state);
        }
    }
}