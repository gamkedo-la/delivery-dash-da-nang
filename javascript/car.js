var car1, car2, car3, car4;

function Car(startingTile,tileUnderStartingTile, movementDirection)
{
	this.startingTile = startingTile;
	this.tileUnderStartingTile = tileUnderStartingTile;
	this.movementDirection = movementDirection;
	this.startingIndexOnMap = undefined;
	this.startingTileX;
	this.startingTileY;
	this.width;
	this.height;
	this.topEdge;
	this.rightEdge;
	this.bottomEdge;
	this.leftEdge;
	this.centerX;
	this.centerY;

	this.isMovingRight = undefined;
	this.isMovingLeft = undefined;
	this.isMovingUp = undefined;
	this.isMovingDown = undefined;

	this.image = undefined;

	this.angle;
	
	this.speed;

	this.keyHeld_Gas = false;
	this.keyHeld_HandBrake = false;
	this.keyHeld_TurnLeft = false;
	this.keyHeld_TurnRight = false;

	this.initialize = function()
	{
		this.startingTileX = undefined;
		this.startingTileY = undefined;
		this.width = undefined;
		this.height = undefined;
		this.angle = 0;
		this.speed = 0;

		this.defineStartingIndexOnMap();
		this.resetPosition();

		this.initializeProperties();

	}

	this.defineStartingIndexOnMap = function()
	{
		for (let rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
		{
			for (let columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
			{
				var arrayIndex = convertRowsAndColumnsToGridIndex(columnIndex,rowIndex);
				if (trackGrid.grid[arrayIndex] === this.startingTile)
				{
					this.startingIndexOnMap = arrayIndex;
				}
			}
		}
	}

	this.resetPosition = function()
	{
		trackGrid.grid[this.startingIndexOnMap] = this.startingTile;

		for (let rowIndex = 0; rowIndex < NUMBER_OF_ROWS; rowIndex++)
		{
			for (let columnIndex = 0; columnIndex < NUMBER_OF_COLUMNS; columnIndex++)
			{

				var arrayIndex = convertRowsAndColumnsToGridIndex(columnIndex,rowIndex);

				if (trackGrid.grid[arrayIndex] === this.startingTile)
				{
					this.startingTileX = columnIndex * TRACK_WIDTH;
					this.startingTileY = rowIndex * TRACK_HEIGHT;
					
					trackGrid.grid[arrayIndex] = this.tileUnderStartingTile;
					

					this.centerX = this.startingTileX + TRACK_WIDTH/2;
					this.centerY = this.startingTileY + TRACK_HEIGHT/2;

					this.updateProperties();
					
				}
			}
		}
	}

	this.initializeProperties = function()
	{
		this.startingDrawX = this.centerX - this.width/2;
		this.startingDrawY = this.centerY - this.height/2;
		
		this.topEdge = this.centerY - this.height/2;
		this.rightEdge = this.centerX + this.width/2;
		this.bottomEdge = this.centerY + this.height/2;
		this.leftEdge = this.centerX - this.width/2;	

		if (this.movementDirection === 'right')
		{
			this.image = carFacingRightImage;
			this.width = 250;
			this.height = 140;
			this.isMovingRight = true;
		}
		else if (this.movementDirection === 'left')
		{
			this.image = carFacingLeftImage;
			this.width = 250;
			this.height = 140;
			this.isMovingLeft = true;
		}
		else if (this.movementDirection === 'up')
		{
			this.image = carFacingUpImage;
			this.width = 140;
			this.height = 250;
			this.isMovingUp = true;
		}
		else if (this.movementDirection === 'down')
		{
			this.image = carFacingDownImage;
			this.width = 140;
			this.height = 250;
			this.isMovingDown = true;
		}


	}


	this.handleWallCollisions = function()
	{

		let currentScooterTopEdgeColumnIndex = Math.floor( (this.startingDrawX + this.width/2)/TRACK_WIDTH );
		let currentScooterTopEdgeRowIndex = Math.floor(this.startingDrawY/TRACK_HEIGHT);

		let currentScooterRightEdgeColumnIndex = Math.floor( (this.startingDrawX + this.width)/TRACK_WIDTH );
		let currentScooterRightEdgeRowIndex = Math.floor( (this.startingDrawY + this.height/2)/TRACK_HEIGHT );

		let currentScooterBottomEdgeColumnIndex = Math.floor( (this.startingDrawX + this.width/2)/TRACK_WIDTH );
		let currentScooterBottomEdgeRowIndex = Math.floor( (this.startingDrawY + this.height)/TRACK_HEIGHT );

		let currentScooterLefttEdgeColumnIndex = Math.floor(this.startingDrawX/TRACK_WIDTH);
		let currentScooterLefttEdgeRowIndex = Math.floor( (this.startingDrawY + this.height/2)/TRACK_HEIGHT );

		let currentTopEdgeGridIndexUnderScooter = convertRowsAndColumnsToGridIndex(currentScooterTopEdgeColumnIndex,currentScooterTopEdgeRowIndex);
		let currentRightEdgeGridIndexUnderScooter = convertRowsAndColumnsToGridIndex(currentScooterRightEdgeColumnIndex,currentScooterRightEdgeRowIndex);
		let currentBottomEdgeGridIndexUnderScooter = convertRowsAndColumnsToGridIndex(currentScooterBottomEdgeColumnIndex,currentScooterBottomEdgeRowIndex);
		let currentLeftEdgeGridIndexUnderScooter = convertRowsAndColumnsToGridIndex(currentScooterLefttEdgeColumnIndex,currentScooterLefttEdgeRowIndex);

		let topEdgeScooterWallCollision = (currentTopEdgeGridIndexUnderScooter >= 0 && currentTopEdgeGridIndexUnderScooter < TRACK_COUNT && trackGrid.grid[currentTopEdgeGridIndexUnderScooter] === 1 );
		let rightEdgeScooterWallCollision = (currentRightEdgeGridIndexUnderScooter >= 0 && currentRightEdgeGridIndexUnderScooter < TRACK_COUNT && trackGrid.grid[currentRightEdgeGridIndexUnderScooter] === 1 );
		let bottomEdgeScooterWallCollision = (currentBottomEdgeGridIndexUnderScooter >= 0 && currentBottomEdgeGridIndexUnderScooter < TRACK_COUNT && trackGrid.grid[currentBottomEdgeGridIndexUnderScooter] === 1 );
		let leftEdgeScooterWallCollision = (currentLeftEdgeGridIndexUnderScooter >= 0 && currentLeftEdgeGridIndexUnderScooter < TRACK_COUNT && trackGrid.grid[currentLeftEdgeGridIndexUnderScooter] === 1 );
		
		if (topEdgeScooterWallCollision)
		{
			console.log('topEdge Wall Collision');
		}
		else if (rightEdgeScooterWallCollision)
		{
			console.log('rightEdgeScooterWallCollision');
		}
		else if (bottomEdgeScooterWallCollision)
		{
			console.log('bottomEdgeScooterWallCollision');
		}
		else if (leftEdgeScooterWallCollision)
		{
			console.log('leftEdgeScooterWallCollision');
		}

		if ( topEdgeScooterWallCollision || rightEdgeScooterWallCollision || bottomEdgeScooterWallCollision || leftEdgeScooterWallCollision)	
		{
			
			var previousX = this.startingDrawX - this.speed;
			var previousY = this.startingDrawY - this.speed;
			this.startingDrawX = previousX;
			this.startingDrawY = previousY;
			this.speed = -3;
		}
		
	}


	this.draw = function()
	{
			canvasContext.drawImage(this.image, this.startingDrawX,this.startingDrawY, this.width,this.height);
	}

	this.updateProperties = function()
	{
		this.startingDrawX = this.centerX - this.width/2;
		this.startingDrawY = this.centerY - this.height/2;
		
		this.topEdge = this.centerY - this.height/2;
		this.rightEdge = this.centerX + this.width/2;
		this.bottomEdge = this.centerY + this.height/2;
		this.leftEdge = this.centerX - this.width/2;		
	}

	this.move = function()
	{
		if (this.isMovingRight)
		{
			if (this.rightEdge < RIGHT_EDGE_OF_MAP)
			{
				this.centerX += 2;
			}
			else 
			{
				
				this.resetPosition();
			}
		}
		
		if (this.isMovingLeft)
		{
			if (this.leftEdge > 0)
			{
				this.centerX -= 2;
			}
			else 
			{
				
				this.resetPosition();
			}
		}

		if (this.isMovingUp)
		{
			if (this.topEdge > 0)
			{
				this.centerY -= 2;
			}
			else 
			{
				this.resetPosition();
			}
		}

		if (this.isMovingDown)
		{
			if (this.bottomEdge < BOTTOM_EDGE_OF_MAP)
			{
				this.centerY += 2;
			}
			else 
			{
				this.resetPosition();
			}
		}
	}

	this.update = function()
	{
		this.move();
		this.handleWallCollisions();
		this.updateProperties();
		
	}
}
