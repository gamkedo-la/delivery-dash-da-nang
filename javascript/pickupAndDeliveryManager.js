let currentWaypointReferenceTile = undefined;

var pickupAndDeliveryManager;

function PickupAndDeliveryManager()
{
	this.currentWaypointLeftX = undefined;
	this.currentWaypointRightX = undefined;
	this.currentWaypointTopY = undefined;
	this.currentWaypointBottomY = undefined;

	this.getWaypointBoxStartingTileCoordinatesReferencePoint = function(tileNumber)
	{
		for (let rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
		{
			for (let columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
			{
				if (trackGrid.grid[columnIndex + rowIndex*NUMBER_OF_COLUMNS] === tileNumber)
				{
					let waypointCoordinates = {x: TRACK_WIDTH*columnIndex,y: TRACK_HEIGHT*rowIndex};
					
					return {x: TRACK_WIDTH*columnIndex,y: TRACK_HEIGHT*rowIndex};

				}
			}
		}
	}

	this.drawNorthOfBuildingWaypointBox = function(waypointBoxMessage)
	{
		let waypointBoxCoordinatesReferencePoint = this.getWaypointBoxStartingTileCoordinatesReferencePoint(currentWaypointReferenceTile);

		let placeholderHorizontalSidewalkHeight = 120;
		let waypointBuildingWidth = snatchApp.currentWaypoint.width;

		let waypointBoxStartingY = waypointBoxCoordinatesReferencePoint.y - placeholderHorizontalSidewalkHeight;

		this.currentWaypointLeftX = waypointBoxCoordinatesReferencePoint.x;
		this.currentWaypointRightX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth;
		this.currentWaypointTopY = waypointBoxStartingY;
		this.currentWaypointBottomY = waypointBoxStartingY + placeholderHorizontalSidewalkHeight;

		canvasContext.strokeStyle = 'green';
		canvasContext.lineWidth = 10;
		canvasContext.strokeRect(waypointBoxCoordinatesReferencePoint.x,waypointBoxStartingY, 
								 waypointBuildingWidth,placeholderHorizontalSidewalkHeight);

		canvasContext.font = '75px Helvetica';
		
		let waypointBoxMessageWidth = canvasContext.measureText(waypointBoxMessage).width;
		let waypointBoxCenterX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth/2;
		let waypointBoxMessageStartingX = waypointBoxCenterX - waypointBoxMessageWidth/2;
		let waypointBoxMessageStartingY = waypointBoxStartingY + 75;
		canvasContext.fillText(waypointBoxMessage, waypointBoxMessageStartingX,waypointBoxMessageStartingY);
	}

	this.drawEastOfBuildingWaypointBox = function(waypointBoxMessage)
	{
		let waypointBoxCoordinatesReferencePoint = this.getWaypointBoxStartingTileCoordinatesReferencePoint(currentWaypointReferenceTile);

		let placeholderSidewalkWidth = 120;
		let waypointBuildingWidth = snatchApp.currentWaypoint.width;
		let waypointBuildingHeight = snatchApp.currentWaypoint.height;

		canvasContext.strokeStyle = 'green';
		canvasContext.lineWidth = 10;
		canvasContext.strokeRect(waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth - 30,
								 waypointBoxCoordinatesReferencePoint.y, 
								 placeholderSidewalkWidth,waypointBuildingHeight);

		this.currentWaypointLeftX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth;
		this.currentWaypointRightX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth + placeholderSidewalkWidth;
		this.currentWaypointTopY = waypointBoxCoordinatesReferencePoint.y;
		this.currentWaypointBottomY = waypointBoxCoordinatesReferencePoint.y + waypointBuildingHeight;

		canvasContext.font = '40px Helvetica';
		
		let waypointBoxMessageWidth = canvasContext.measureText(waypointBoxMessage).width;
		let waypointBoxCenterX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth + placeholderSidewalkWidth/2;
		
		let waypointBoxCenterY = waypointBoxCoordinatesReferencePoint.y + waypointBuildingHeight/2;
		
		let waypointBoxMessageStartingX = waypointBoxCenterX - waypointBoxMessageWidth/2;
		let waypointBoxMessageStartingY = waypointBoxCenterY;

		canvasContext.save();
		canvasContext.translate(waypointBoxMessageStartingX + waypointBoxMessageWidth/2,waypointBoxMessageStartingY);
		canvasContext.rotate(-1.5708);
		canvasContext.translate(-waypointBoxMessageStartingX - waypointBoxMessageWidth/2,-waypointBoxMessageStartingY)
		canvasContext.fillText(waypointBoxMessage, waypointBoxMessageStartingX,waypointBoxMessageStartingY);
		canvasContext.restore();
	}

	this.drawWestOfBuildingWaypointBox = function(waypointBoxMessage)
	{
		let waypointBoxCoordinatesReferencePoint = this.getWaypointBoxStartingTileCoordinatesReferencePoint(currentWaypointReferenceTile);

		let placeholderSidewalkWidth = 120;
		let waypointBuildingWidth = snatchApp.currentWaypoint.width;
		let waypointBuildingHeight = snatchApp.currentWaypoint.height;

		canvasContext.strokeStyle = 'green';
		canvasContext.lineWidth = 10;
		canvasContext.strokeRect(waypointBoxCoordinatesReferencePoint.x - placeholderSidewalkWidth - 30,
								 waypointBoxCoordinatesReferencePoint.y, 
								 placeholderSidewalkWidth,waypointBuildingHeight);

		this.currentWaypointLeftX = waypointBoxCoordinatesReferencePoint.x - placeholderSidewalkWidth;
		this.currentWaypointRightX = waypointBoxCoordinatesReferencePoint.x;
		this.currentWaypointTopY = waypointBoxCoordinatesReferencePoint.y;
		this.currentWaypointBottomY = waypointBoxCoordinatesReferencePoint.y + waypointBuildingWidth;

		canvasContext.font = '40px Helvetica';
		
		let waypointBoxMessageWidth = canvasContext.measureText(waypointBoxMessage).width;
		let waypointBoxCenterX = waypointBoxCoordinatesReferencePoint.x + waypointBuildingWidth + placeholderSidewalkWidth/2;
		
		let waypointBoxCenterY = waypointBoxCoordinatesReferencePoint.y + waypointBuildingHeight/2;
		
		let waypointBoxMessageStartingX = waypointBoxCenterX - (2.2*(waypointBoxMessageWidth));
		let waypointBoxMessageStartingY = waypointBoxCenterY;

		canvasContext.save();
		canvasContext.translate(waypointBoxMessageStartingX + waypointBoxMessageWidth/2,waypointBoxMessageStartingY);
		canvasContext.rotate(1.5708);
		canvasContext.translate(-waypointBoxMessageStartingX - waypointBoxMessageWidth/2,-waypointBoxMessageStartingY)
		canvasContext.fillText(waypointBoxMessage, waypointBoxMessageStartingX,waypointBoxMessageStartingY);
		canvasContext.restore();
	}

	this.drawSouthOfBuildingWaypointBox = function(waypointBoxMessage)
	{

	}

	this.drawWaypoints = function()
	{
		let waypointBoxMessage = undefined;
		if (snatchApp.status === 'picking up')
		{
			waypointBoxMessage = 'Pickup Here';
		}
		else if (snatchApp.status === 'dropping off')
		{
			waypointBoxMessage = 'Dropoff Here';
		}

		if (snatchApp.status === 'waiting')
		{
			return;
		}
		else if (snatchApp.status === 'picking up')
		{
			if (snatchApp.currentRestaurant.waypointBoxDirection === 'north')
			{
				this.drawNorthOfBuildingWaypointBox(waypointBoxMessage);
			}
			else if (snatchApp.currentRestaurant.waypointBoxDirection === 'east')
			{
				
				this.drawEastOfBuildingWaypointBox(waypointBoxMessage);
			}
			else if (snatchApp.currentRestaurant.waypointBoxDirection === 'south')
			{
				this.drawSouthOfBuildingWaypointBox(waypointBoxMessage);
			}
			else if (snatchApp.currentRestaurant.waypointBoxDirection === 'west')
			{
				this.drawWestOfBuildingWaypointBox(waypointBoxMessage);
			}
			
		}
		else if (snatchApp.status === 'dropping off')
		{
			if (snatchApp.currentCustomer.waypointBoxDirection === 'north')
			{
				this.drawNorthOfBuildingWaypointBox(waypointBoxMessage)
			}
			else if (snatchApp.currentCustomer.waypointBoxDirection === 'east')
			{
				this.drawEastOfBuildingWaypointBox(waypointBoxMessage)
			}
			else if (snatchApp.currentCustomer.waypointBoxDirection === 'south')
			{
				this.drawSouthOfBuildingWaypointBox(waypointBoxMessage)
			}
			else if (snatchApp.currentCustomer.waypointBoxDirection === 'west')
			{
				this.drawWestOfBuildingWaypointBox(waypointBoxMessage)
			}
		}
	}

	this.checkForWaypointArrivals = function()
	{
		if (snatchApp.status === 'waiting')
		{
			return;
		}

		else if (snatchApp.status === 'picking up')
		{

			if (scooter.centerX > this.currentWaypointLeftX && scooter.centerX < this.currentWaypointRightX &&
				scooter.centerY > this.currentWaypointTopY && scooter.centerY < this.currentWaypointBottomY &&
				scooter.speed === 0)
			{
				console.log('pick up arrival detected');
				snatchApp.status = 'dropping off';
				currentWaypointReferenceTile = snatchApp.currentCustomer.apartmentBuildingTile;
				snatchApp.currentWaypoint = snatchApp.currentCustomer;
				pickupOrDropoffSFXAudioTag.play();
			}
		}
		else if (snatchApp.status === 'dropping off') 
		{
			if (scooter.centerX > this.currentWaypointLeftX && scooter.centerX < this.currentWaypointRightX &&
				scooter.centerY > this.currentWaypointTopY && scooter.centerY < this.currentWaypointBottomY &&
				scooter.speed === 0)
			{
				console.log('drop off arrival detected');
				snatchApp.status = 'waiting';
				snatchApp.currentMessageLine1 = snatchApp.waitingMessage;
				snatchApp.currentMessageLine2 = undefined;
				snatchApp.startOrderCycle();
				pickupOrDropoffSFXAudioTag.play();
			}
		}

		
	}
}