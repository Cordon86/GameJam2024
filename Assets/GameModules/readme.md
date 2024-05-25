## Instructions for testing.

 - Find the sample scene in SaveSystem/ExampleScene folder, you will see a `SaveManager` and a player prefab in the scene already to run.

 - Press play
 - Press play again to stop playing
 - navigate to `Application.persistentDataPath` which should be shown in the console Something like `C:/users/<username>/Appdata/LocalLow/DefaultCompany/<gamename>/` on windows
 - you should see a file 'data.json' you can change this in the SaveManager inspector. You can inspect this file and it should look like

 ```json
 {
    "score": 0,
    "lives": 0
}
```

 - to see it working edit the values in the player object in scene after you press play to start the game, and then stop the game and re-inspect the save file.

### Instruction manual for full usage will come later.