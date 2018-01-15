Simple Progress Bar:

Scene includes: 	Canvas
			    -> RecepyImage
				-> Text (1)

			    -> ProgressionObject(2)
				-> ProgressBar

			EventSystem (3)

(1) Text object may be used for recepy, with option to place icons, images or additional UI elements into the RecepyImage object.

(2) "ProgressionObject" includes ProgressMenuScript which controlls the childObject "ProgressBar".

	Doc:	- ProgressMenuScript.setProgressVal(float value) 
			type: (public static void)
			description: sets the value of the ProgressBar slider object. Value must be 					between 0 and 1.
		
		- ProgressMenuScript.setColorKeys(float yellowEnd, float greenEnd, float orangeEnd)
			type: (public static void)
			description: sets color keys (starting with the set percentual value).
			values must be between at least 0 but can be bigger than 1.
			example: ProgressMenuScript.setColorKeys(0.5f, 0.9f, 1.1f)
					- Starting with value 0.5f the ProgressBar color would change 							from yellow to green. From 0.9f upwards, color changes to orange.
					Over 1.1f the color changes to red.

		- ProgressMenuScript.setRecepyText(string)
			type: (public void)(must be referenced via object.getComponent<>())
			description: OPTIONAL, may be used to change the recepy text.

(3) Every Unity scene that uses UI Canvas must include an Event system.