# Unity-radial-progressbar
A radial progress bar that fills the circle in sectors, like a PIE-CHART.
 
## How to use?
Simply clone the repository into the 'Assets' folder of a Unity project and you're good to go.

* In the prefabs folder, place the "Progressbar" prefab in your scene.
* Add a reference to the script or object from any other Object in the scene.
* Call the function SetQuestionsCount with the number of sectors the circle should be divided with. This will set the base required over which we can increment the progress.
* Whenever there is a progress, call the "IncreaseProgress" Method.
* To reset this, just call the "SetQuestionsCount" again.

## About

 This is not dependent on any timer. This is not for those looking for a progress bar with timer.  

## Contributing

I have made this radial progressbar for a very specific function. This has a potential to be modified and used however you like.

Modify as you wish and let me know how it works and send me a PR.

