const TRACK_W = 40;
const TRACK_H = 40;
const TRACK_COLS = 20;
const TRACK_ROWS = 15;
const TRACK_GAP = 2;
var levelOne = [6,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,1,1,1,6,
				 3,0,0,0,0,0,0,4,3,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,0,0,0,0,4,3,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,6,6,0,0,4,3,0,0,6,2,2,2,2,6,0,0,4,
				 3,0,0,4,3,0,0,4,3,0,0,4,6,6,6,6,3,0,0,4,
				 3,0,0,4,3,0,0,0,0,0,0,4,6,6,6,6,3,0,0,4,
				 3,0,0,4,3,0,0,0,0,0,0,4,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,2,2,2,2,2,2,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,1,1,6,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,3,0,0,0,0,0,4,
				 3,5,5,6,1,1,1,1,1,1,1,1,1,6,0,0,0,0,0,4,
				 3,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,6,2,2,6,
				 3,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,4,6,6,6,	
				 6,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6,6,6,6];	

 var levelTwo = [6,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,6,
				 3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,5,5,4,1,1,1,1,1,1,1,1,1,1,1,6,3,0,0,4,
				 3,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,7,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,	
				 6,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6];	
				 
var levelThree = [6,1,1,1,1,1,1,6,6,1,1,1,1,1,1,1,1,1,1,6,
				 3,0,0,0,0,0,0,4,3,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,0,0,0,0,4,3,0,0,0,0,0,0,0,0,0,0,4,
				 3,0,0,6,6,0,0,4,3,0,0,6,2,2,2,2,6,0,0,4,
				 3,0,0,4,3,0,0,4,3,0,0,4,6,6,6,6,3,0,0,4,
				 3,7,7,4,3,0,0,0,0,0,0,4,6,6,6,6,3,0,0,4,
				 3,0,0,4,3,0,0,0,0,0,0,4,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,2,2,2,2,2,2,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,6,6,3,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,6,1,1,6,0,0,4,
				 3,0,0,4,6,6,6,6,6,6,6,6,6,3,0,0,0,0,0,4,
				 3,5,5,6,1,1,1,1,1,1,1,1,1,6,0,0,0,0,0,4,
				 3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,6,2,2,6,
				 3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,4,6,6,6,	
				 6,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,6,6,6,6];	

var levelList = [levelOne, levelTwo, levelThree];
var levelNow = 0;
var trackGrid = [];

const TRACK_ROAD = 0;
const TRACK_NORTH_WALL = 1;
const TRACK_SOUTH_WALL = 2;
const TRACK_WEST_WALL = 3;
const TRACK_EAST_WALL = 4;
const TRACK_PLAYERSTART = 5;
const TRACK_GRASS = 6;
const TRACK_FINISH = 7;
const TRACK_START = 8;

function returnTileTypeAtColRow(col, row) {
	if(col >= 0 && col < TRACK_COLS &&
		row >= 0 && row < TRACK_ROWS) {
		 var trackIndexUnderCoord = rowColToArrayIndex(col, row);
		 return trackGrid[trackIndexUnderCoord];
	} else {
		return TRACK_NORTH_WALL;
	}
} 

function carTrackHandling(whichCar) {

	var carTrackCol = Math.floor(whichCar.x / TRACK_W);
	var carTrackRow = Math.floor(whichCar.y / TRACK_H);
	var trackIndexUnderCar = rowColToArrayIndex(carTrackCol, carTrackRow);

	if(carTrackCol >= 0 && carTrackCol < TRACK_COLS &&
		carTrackRow >= 0 && carTrackRow < TRACK_ROWS) {
		var tileHere = returnTileTypeAtColRow(carTrackCol, carTrackRow);

		if(tileHere == TRACK_FINISH) {
			console.log(whichCar.name + "WINS!");
			nextLevel();
		} else if(tileHere != TRACK_ROAD) {
			whichCar.x -= Math.cos(whichCar.ang) * whichCar.speed;
			whichCar.y -= Math.sin(whichCar.ang) * whichCar.speed;
			whichCar.speed *= -.5;
		} // end of track found
	}
} // end of carTrackHandling func


function rowColToArrayIndex(col, row) {
	return col + TRACK_COLS * row;
}

function drawTracks () {
	var arrayIndex = 0;
	var drawTileX = 0;
	var drawTileY = 0;
	for(var eachRow=0; eachRow<TRACK_ROWS;eachRow++) {
		for(var eachCol=0;eachCol<TRACK_COLS; eachCol++) {
			var tileKindHere = trackGrid[arrayIndex];	
			var useImg = trackPics[tileKindHere];		
			
			canvasContext.drawImage(useImg, drawTileX, drawTileY);
			drawTileX += TRACK_W;
			arrayIndex++;
		}  // end of for each track
		drawTileY += TRACK_H;
		drawTileX = 0;
	} //end of each row		
} // end of drawTracks func
