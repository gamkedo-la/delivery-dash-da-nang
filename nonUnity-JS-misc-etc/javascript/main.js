var canvas, canvasContext, framesPerSecond, frameRate, camera;

window.onload = function()
{
	canvas = document.getElementById('gameCanvas');
	canvasContext = canvas.getContext('2d');

	document.addEventListener('click', handleClick);
	drawSplashScreen();
	loadImages();
	//initializeGame();
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

	npcScooter5 = new NPCScooter(NPCSCOOTER5_STARTING_TILE,PLAIN_ROAD_TILE, 'right');
	npcScooter5.initialize();

	
	car1 = new Car(CAR1_STARTING_TILE,PLAIN_ROAD_TILE, 'down');
	car1.initialize();

	car2 = new Car(CAR2_STARTING_TILE,PLAIN_ROAD_TILE, 'right');
	car2.initialize();

	car3 = new Car(CAR3_STARTING_TILE,PLAIN_ROAD_TILE, 'left');
	car3.initialize();

	car4 = new Car(CAR4_STARTING_TILE,PLAIN_ROAD_TILE, 'up');
	car4.initialize();

	sarahWhitecotton = new Customer('Sarah Whitecotton', 'Chips', CHIPS_STARTING_TILE, 120,120, 'west', 'Veggie Pasta Marinara', 'Veggie Sushi');
	josephRoberts = new Customer('Joseph Roberts', 'Seasand', SEASAND_STARTING_TILE, 175,142, 'east', 'Crumble Chicken', 'Philly Roll');

	hannahs = new Restaurant('Hannahs', HANNAHS_STARTING_TILE, 'north', 600,60);
	fune = new Restaurant('Fune', FUNE_STARTING_TILE, 'east', 120,120);

	pickupAndDeliveryManager = new PickupAndDeliveryManager();

	centerSquareColliderBox = new BuildingColliderBox(CHIPS_STARTING_TILE, 73,42);
	arrayOfBuildingColliderBoxes.push(centerSquareColliderBox);
	southernSquareColliderBox = new BuildingColliderBox(HANNAHS_STARTING_TILE, 73,16);
	arrayOfBuildingColliderBoxes.push(southernSquareColliderBox);

	snatchApp = new SnatchApp();
	snatchApp.initialize();

	canvas.addEventListener('mousemove', updateMousePosition);
	document.addEventListener('keydown', handleKeyPress);
	document.addEventListener('keyup', handleKeyRelease);

	camera = new Camera();

	sampleBackgroundMusicAudioTag.play();

	setInterval(gameLoop, frameRate);
}

function updateEverything()
{
	npcScooter1.update();
	npcScooter2.update();
	npcScooter3.update();
	npcScooter4.update();
	npcScooter5.update();
	car1.update();
	car2.update();
	car3.update();
	car4.update();
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
	pickupAndDeliveryManager.drawWaypoints();
	npcScooter1.draw();
	npcScooter2.draw();
	npcScooter3.draw();
	npcScooter4.draw();
	npcScooter5.draw();
	car1.draw();
	car2.draw();
	car3.draw();
	car4.draw();
	if (debugOn)
	{
		drawDebugStuff();
	}
	canvasContext.restore();
	// camera.endPan(canvasContext);
	
	snatchApp.drawMessage();
	scooter.draw();
	

	
}

function gameLoop()
{
	updateEverything();
	drawEverything();
}