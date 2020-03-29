using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;

public class Leaderboard : MonoBehaviour
{
    DatabaseReference reference;

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

    private string name = "Gage";
    private string score = "69";

    // Start is called before the first frame update
    void Start()
    {
        // Set up the Editor before calling into the realtime database.
        //email me at gstowers@elon.edu for database permissions
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://integration-db.firebaseio.com/");

        // Get the root reference location of the database.
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        reference.Child("Name").SetValueAsync(name);
        reference.Child("Value").SetValueAsync(score);
        scoreOne.text="xxx";
    }

    // Update is called once per frame
    void Update()
    {
       // LoadData();
    }
    public void SaveData()
    {

      
    }
    public void LoadData()
    {
        FirebaseDatabase.DefaultInstance.GetReference("Name").ValueChanged += HandleValueChanged;

    }
    public void HandleScores(){
       // FirebaseDatabase.DefaultInstance.orderByChild("Value").LimitToFirst(5).ValueChanged+=HandleValueChanged;
    }



    private void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
       if(args.DatabaseError!=null){
           Debug.LogError(args.DatabaseError.Message);
           return;
       }
      // scoreOne.text=args.Snapshot("Name").GetValue(true).ToString();
    }
}

