using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Database;
using Firebase.Unity.Editor;


public class LeaderBoardEntry {
    public string uid;
    public int score = 0;

    public LeaderBoardEntry() {
    }

    public LeaderBoardEntry(string uid, int score) {
        this.uid = uid;
        this.score = score;
    }

    public Dictionary<string, System.Object> ToDictionary() {
        Dictionary<string, System.Object> result = new Dictionary<string, System.Object>();
        result["uid"] = uid;
        result["score"] = score;

        return result;
    }
}
