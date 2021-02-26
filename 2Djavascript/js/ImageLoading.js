var carPic = document.createElement("img");
var greenCarPic = document.createElement("img");
var trackPics = [];

var picsToLoad = 0;

function countLoadedImagesAndLaunchIfReady(){
		picsToLoad--;
		console.log(picsToLoad);
		if(picsToLoad == 0) {
			imageLoadingDoneSoStartGame();
	}
}

function beginLoadingImage(imgVar, fileName) {
	imgVar.onload = countLoadedImagesAndLaunchIfReady;
	imgVar.src = "images/" + fileName;
}

function loadImageForTrackCode(trackCode, fileName)  {
	trackPics[trackCode] = document.createElement("img");
	beginLoadingImage(trackPics[trackCode], fileName);	
}

function loadImages() {
	
		var imageList = [
			{trackType: TRACK_ROAD,  theFile: "trackRoad.png"},
			{trackType: TRACK_NORTH_WALL, theFile:  "wallNorth.png"},
			{trackType: TRACK_SOUTH_WALL, theFile: "wallSouth.png"},
			{trackType: TRACK_WEST_WALL, theFile: "wallWest.png"},
			{trackType: TRACK_EAST_WALL, theFile: "wallEast.png"},
			{trackType: TRACK_GRASS, theFile: "grass.png"},
			{trackType: TRACK_FINISH, theFile: "finishLine.png"},
			{trackType: TRACK_START, theFile: "start.png"},
			{varName: carPic, theFile: "player1car.png"},
			{varName: greenCarPic, theFile: "player2car.png"}
		];
			
	picsToLoad = imageList.length;

	for(var i=0; i<imageList.length; i++) {
		if(imageList[i].varName != undefined) {
			beginLoadingImage(imageList[i].varName, imageList[i].theFile);
		} else {
			loadImageForTrackCode( imageList[i].trackType, imageList[i].theFile );
		}
	}
}