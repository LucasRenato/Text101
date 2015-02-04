using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

    public Text text;
    public bool hairclip;
    
	private enum States {
		cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, corridor_0, stairs_0, door, floor, corridor_1,
		stairs_1, in_closet, corridor_2, corridor_3, stairs_2, courtyard
		};
	private States myState;
    
    // Use this for initialization
	void Start () {
	    myState = States.cell;
	    hairclip = false;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.cell) 		{cell();}
		else if (myState == States.sheets_0) 	{sheets_0();}
		else if (myState == States.sheets_1) 	{sheets_1();}
		else if (myState == States.lock_0) 		{lock_0();}
		else if (myState == States.lock_1) 		{lock_1();}
		else if (myState == States.mirror) 		{mirror();}
		else if (myState == States.cell_mirror) {cell_mirror();}
		else if (myState == States.corridor_0) 	{corridor_0();}
		else if (myState == States.stairs_0)	{stairs_0();}
		else if (myState == States.door)	{door();}
		else if (myState == States.floor)		{floor();}
		else if (myState == States.corridor_1)	{corridor_1();}
		else if (myState == States.stairs_1)	{stairs_1();}
		else if (myState == States.in_closet)	{in_closet();}
		else if (myState == States.corridor_2)	{corridor_2();}
		else if (myState == States.stairs_2)	{stairs_2();}
		else if (myState == States.corridor_3)	{corridor_3();}
		else if (myState == States.courtyard)	{courtyard();}
		
	}
	
	void cell () {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press S to view Sheets, M to view Mirror and L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.M)) 	{myState = States.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_0;}
    }
    
	void mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press T to Take the mirror, or R to Return to cell" ;
		if 		(Input.GetKeyDown(KeyCode.T)) 	{myState = States.cell_mirror;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell;}
    }
    
	void cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and that pesky door is still there, and firmly locked!\n\n" +
					"Press S to view Sheets, or L to view Lock" ;
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.sheets_1;}
		else if (Input.GetKeyDown(KeyCode.L)) 	{myState = States.lock_1;}
    }
   
    void sheets_0 () {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press R to Return to roaming your cell" ;
        if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;}
    }
    
	void sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell_mirror;}
    }
    
    void lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press R to Return to roaming your cell" ;
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.cell;}
    }
    
	void lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press O to Open, or R to Return to your cell" ;
		if 		(Input.GetKeyDown(KeyCode.O)) 	{myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.R)) 	{myState = States.cell_mirror;}
    }
    
    void freedom () {
		text.text = "You Are FREE! Go eat a McDonald's!\n\n" + 
		"Press P to Play Again" ;
		if (Input.GetKeyDown(KeyCode.P)) {myState = States.cell;}
    }
    
    void corridor_0 () {
    	text.text = "You are in a large hall, and see a door and a stair.\n\n" + 
    				"Press S to the Stairs, D for the door and W to keep walking.";
    				
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.D)) {myState = States.door;}
		else if (Input.GetKeyDown(KeyCode.W)) {myState = States.floor;}
    }
    
    void stairs_0 () {
		text.text = "This stairs takes to the cell. Take care\n\n" + 
					"Press R to Return.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
    }
    
    void door () {
		string message;
		if (hairclip) {message = "\n";}
		else {message = "Wait a hair clip, maybe it can help me.\n\nPress T to Take a hair clip or ";}
		text.text = "Oh no, dead room!\n" + message +
					"Press R to Return.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_0;}
		else if (Input.GetKeyDown(KeyCode.T)) {hairclip = true;}
	}
	
	void floor () {
		string message = "";
		if (!hairclip) {message = ", but I don't have it";}
		text.text = "A door, but is closed. Maybe a hair clip can open it" + message + ".\n\n" + 
					"Press H to use a hair clip or R to return";
					
		if (Input.GetKeyDown (KeyCode.H)) {if (hairclip){myState = States.corridor_1;}}
		else if (Input.GetKeyDown (KeyCode.R)) {myState = States.corridor_0;}
	}
	
	void corridor_1 () {
		text.text = "Other Corridor! I see a stairs and a closet.\n\n" +
					"Press S to Stairs or C to Closet.";
		if (Input.GetKeyDown(KeyCode.S)) {myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.C)) {myState = States.in_closet;}
	}
	
	void stairs_1 () {
		text.text = "Nothing Here, better come back!\n\n" + 
			"Press R to Return.";
		if (Input.GetKeyDown(KeyCode.R)) {myState = States.corridor_1;}
	}
	
	void in_closet() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
					"Seems like your day is looking-up.\n\n" +
					"Press D to Dress up, or R to Return to the corridor";
		if 		(Input.GetKeyDown(KeyCode.R)) 	{myState = States.corridor_2;}
		else if (Input.GetKeyDown(KeyCode.D)) 	{myState = States.corridor_3;}
	}
	
	void corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
			"Press C to revisit the Closet, and S to climb the stairs";
		if 		(Input.GetKeyDown(KeyCode.C)) 	{myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) 	{myState = States.stairs_2;}
	}
	
	void stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
			"a hairclip (now badly bent). Even these achievements together don't give " +
				"you the courage to climb up the staris to your death!\n\n" +
				"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) 		{myState = States.corridor_2;}
	}
	
	void corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
			"You strongly consider the run for freedom.\n\n" +
				"Press S to take the Stairs, or U to Undress";
		if 		(Input.GetKeyDown(KeyCode.S)) 	{myState = States.courtyard;}
		else if (Input.GetKeyDown(KeyCode.U))	{myState = States.in_closet;}
	}
	
	void courtyard () {
		text.text = "You walk through the courtyard dressed as a cleaner. " +
			"The guard tips his hat at you as you waltz past, claiming " +
				"your freedom. You heart races as you walk into the sunset.\n\n" +
				"Press P to Play again." ;
		if (Input.GetKeyDown(KeyCode.P)) 		{myState = States.cell;}
	}
}
