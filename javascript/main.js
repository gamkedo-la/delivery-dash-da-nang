var canvas, canvasContext, framesPerSecond, frameRate, camera;

window.onload = function()
{
	canvas = document.getElementById('gameCanvas');
	canvasContext = canvas.getContext('2d');

	console.log(window.innerWidth);
	
	loadImages();
	initializeGame();
}

function initializeGame()
{
	framesPerSecond = 30;
	frameRate = 1000/framesPerSecond;

	background = new Background();
	background.initialize();

	trackGrid = new TrackGrid();
	trackGrid.initialize();

	scooter = new Scooter();
	scooter.initialize();

	npcScooter1 = new NPCScooter(NPCSCOOTER1_STARTING_TILE,PLAIN_ROAD_TILE, 'right');
	npcScooter1.initialize();

	npcScooter2 = new NPCScooter(NPCSCOOTER2_STARTING_TILE,PLAIN_ROAD_TILE, 'left');
	npcScooter2.initialize();

	npcScooter3 = new NPCScooter(NPCSCOOTER3_STARTING_TILE,PLAIN_ROAD_TILE, 'up');
	npcScooter3.initialize();

	npcScooter4 = new NPCScooter(NPCSCOOTER4_STARTING_TILE,PLAIN_ROAD_TILE, 'down');
	npcScooter4.initialize();

	pickupAndDeliveryManager = new PickupAndDeliveryManager();

	snatchApp = new SnatchApp();
	snatchApp.startOrderCycle();

	canvas.addEventListener('mousemove', updateMousePosition);
	document.addEventListener('keydown', handleKeyPress);
	document.addEventListener('keyup', handleKeyRelease);

	camera = new Camera();

	setInterval(gameLoop, frameRate);
}

function updateEverything()
{
	npcScooter1.update();
	npcScooter2.update();
	npcScooter3.update();
	npcScooter4.update();
	scooter.update();
	camera.follow(canvas, scooter);
	pickupAndDeliveryManager.checkForWaypointArrivals();
}

function drawEverything()
{
	background.draw();
	// camera.startPan(canvasContext);
	canvasContext.save();
	
	canvasContext.translate(-scooter.centerX + canvas.width/2,-scooter.centerY + canvas.height/2);
	trackGrid.draw();
	npcScooter1.draw();
	npcScooter2.draw();
	npcScooter3.draw();
	npcScooter4.draw();
	pickupAndDeliveryManager.drawWaypoints();

	canvasContext.restore();
	// camera.endPan(canvasContext);
	
	snatchApp.drawMessage();
	scooter.draw();
	

	if (debugOn)
	{
		drawDebugStuff();
	}
}

function gameLoop()
{
	updateEverything();
	drawEverything();
}