var canvas, canvasContext;

var redCar = new carClass();
var greenCar = new carClass();

window.onload = function() {
	canvas = document.getElementById('gameCanvas');
	canvasContext = canvas.getContext('2d');
	
	colorRect(0,0, canvas.width,canvas.height, 'orange'); // startup page
	
	loadImages();
}

function imageLoadingDoneSoStartGame() {	
	var framesPerSecond = 30;
	setInterval(updateAll, 1000/framesPerSecond);
	
	setupInput();
	
	loadLevel(levelOne);

}

function nextLevel() {
	levelNow++;
	if(levelNow >= levelList.length) {
		levelNow = 0;
	}
	loadLevel(levelList[levelNow]);
}

function loadLevel(whichLevel) {	
	trackGrid = whichLevel.slice();
	redCar.reset(carPic, "Red Car");
	greenCar.reset(greenCarPic, "Green Car");
}

function updateAll() {
	moveAll();
	drawAll();
}

function moveAll() {
	redCar.move();
	greenCar.move();
	carTrackHandling(redCar);
	carTrackHandling(greenCar);
}

function drawAll() {
	
	drawTracks();
	redCar.draw();
	greenCar.draw();
}