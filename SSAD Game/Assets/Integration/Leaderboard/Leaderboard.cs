using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Leaderboard : MonoBehaviour
{


    //score of last game played

    public int recentScore = 00000;
    //type of last game played ('puzzle' or 'hydro')
    public string recentType = "error";
    public string playerName = "Player";

    [SerializeField]
    private TextMesh scoreOne;
    [SerializeField]
    private TextMesh scoreTwo;
    [SerializeField]
    private TextMesh scoreThree;
    [SerializeField]
    private TextMesh scoreFour;
    [SerializeField]
    private TextMesh scoreFive;

    public int[] scores = { 0, 0, 0, 0, 0 };
    public string[] usernames = { "x", "x", "x", "x", "x" };
    private int maxScores = 5;

    DatabaseReference reference;


    // Start is called before the first frame update
    void Start()
    {
        
        //email me at gstowers@elon.edu if u wanna see the database
        // Set up the Editor before calling into the realtime database.
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://integration-db.firebaseio.com/");

        // Get the root reference location of the database.
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        WriteNewScore("Gage", 69);
        WriteNewScore("GOd", 80);
        WriteNewScore("GOd", 85);
        WriteNewScore("GOd", 90);
        WriteNewScore("GOd", 74);
        WriteNewScore("GOd", 30);
        WriteNewScore("GOd", 28);



    }

    // Update is called once per frame
    void Update()
    {
        //retrieves highest five scores
        FirebaseDatabase.DefaultInstance
       .GetReference("scores").OrderByChild("score").LimitToLast(maxScores)
       .ValueChanged += HandleValueChanged;

        //updates scoreboard values
        scoreOne.text = usernames[4] + ": " + scores[4].ToString();
        scoreTwo.text = usernames[3] + ": " + scores[3].ToString();
        scoreThree.text = usernames[2] + ": " + scores[2].ToString();
        scoreFour.text = usernames[1] + ": " + scores[1].ToString();
        scoreFive.text = usernames[0] + ": " + scores[0].ToString();
    }

    //checks for updates automatically
    void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        int i = 0;
        foreach (DataSnapshot leader in args.Snapshot.Children)
        {
            scores[i] = Convert.ToInt32(leader.Child("score").Value);
            usernames[i] = leader.Child("uid").Value.ToString();
            i++;
        }


    }


    //enter username and score 
    private void WriteNewScore(string userId, int score)
    {
      
        string key = score.ToString();
        LeaderBoardEntry entry = new LeaderBoardEntry(userId, score);
        Dictionary<string, System.Object> entryValues = entry.ToDictionary();

        Dictionary<string, System.Object> childUpdates = new Dictionary<string, System.Object>();
        childUpdates["/scores/" + key] = entryValues;


        reference.UpdateChildrenAsync(childUpdates);

    }


}

