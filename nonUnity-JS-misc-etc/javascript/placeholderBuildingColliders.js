var centerSquareColliderBox, southernSquareColliderBox;
var arrayOfBuildingColliderBoxes = [];

function BuildingColliderBox(startingTile, numberOfColumnsWide,numberOfRowsHigh)
{
	this.startingTile = startingTile;
	this.width = numberOfColumnsWide*TRACK_WIDTH;
	this.height = numberOfRowsHigh*TRACK_HEIGHT;

	this.boxCoordinatesReferencePoint = pickupAndDeliveryManager.getWaypointBoxStartingTileCoordinatesReferencePoint(this.startingTile);

	this.leftEdge = this.boxCoordinatesReferencePoint.x;
	this.topEdge = this.boxCoordinatesReferencePoint.y;
	this.rightEdge = this.leftEdge + this.width;
	this.bottomEdge = this.topEdge + this.height;

	this.draw = function()
	{
		canvasContext.strokeStyle = 'green';
		canvasContext.lineWidth = 5;
		canvasContext.strokeRect(this.leftEdge,this.topEdge, this.width,this.height);
	}
}