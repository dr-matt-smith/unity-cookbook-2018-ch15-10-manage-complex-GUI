using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

// adapted from answers.unity.com sample code posted by 'Statememt' (Dec 2013)
// https://answers.unity.com/questions/601131/editorgui-editorguilayout-gui-guilayout-pshhh-when.html
public class MyEditorWindow : EditorWindow 
 {
     GUITextField username;
     GUITextField realname;
     GUIButton registerButton;
     GUIFlexibleSpace flexibleSpace;

     // Optional, but may be convenient.
     List<IMyGUI> gui = new List<IMyGUI>();

     [MenuItem("Example/Show Window")]
     public static void ShowWindow () {
         GetWindow<MyEditorWindow>("My Reg Panel", true);
     }

     // setup all our GUI obejcts
     void OnEnable()
     {
        username = new GUITextField ();
        username.label.text = "Username";
        username.text = "JDoe";
        
        realname = new GUITextField ();
        realname.label.text = "Real name";
        realname.text = "John Doe";
                
        registerButton = new GUIButton ();
        registerButton.label.text = "Register";
         // add RegisterUser() to button's OnClick event broadcaster
        registerButton.OnClick += RegisterUser;
        
        bool centerFully = true;
        gui.Add(new GUILabel("Unity 2018 is great", centerFully));
        
        gui.Add (username);
        gui.Add (realname);
        gui.Add(new GUIFlexibleSpace());
        gui.Add (registerButton);        
     }

     // remove method RegisterUser() from button's OnClick event broadcaster
     private void OnDisable()
     {
         registerButton.OnClick -= RegisterUser;
     }

     // actions to perform when button clicked
     void RegisterUser()
     {
         var msg = "Registering " + realname.text + " as " + username.text;
         Debug.Log (msg);
     }

     // loop through to display all GUI controls each frame
     void OnGUI() {
         foreach (var item in gui)
             item.OnGUI();
     }
 }
