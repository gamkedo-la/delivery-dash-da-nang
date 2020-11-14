var snatchApp;

function SnatchApp()
{
	this.arrayOfCustomers = [];
	this.arrayOfRestaurants = [];

	this.currentCustomer = undefined;
	this.currentRestaurant = undefined;
	this.currentWaypoint = undefined;

	this.initialize = function()
	{
		this.arrayOfCustomers.push(sarahWhitecotton,josephRoberts);
		this.arrayOfRestaurants.push(hannahs,fune);
		this.startOrderCycle();
	}

	this.pickACustomer = function()
	{
		let randomCustomerIndex = getRandomInt(0, this.arrayOfCustomers.length);
		this.currentCustomer = this.arrayOfCustomers[randomCustomerIndex];
	}

	this.pickARestaurant = function()
	{
		let randomRestaurantIndex = getRandomInt(0, this.arrayOfRestaurants.length);
		this.currentRestaurant = this.arrayOfRestaurants[randomRestaurantIndex];
		currentWaypointReferenceTile = this.currentRestaurant.startingTile;
	}

	this.setCustomerOrderBasedOnRestaurant = function()
	{
		console.log('inside call to set order');
		if (this.currentRestaurant.name === 'Hannahs')
		{
			console.log('should be setting hannahs order');
			console.log('this.currentCustomer.orderFromHannahs: ' + this.currentCustomer.orderFromHannahs);
			this.currentCustomer.currentOrder = this.currentCustomer.orderFromHannahs;
		}
		else if (this.currentRestaurant.name === 'Fune')
		{
			console.log('should be setting fune order');
			console.log('this.currentCustomer.orderFromFune: ' + this.currentCustomer.orderFromFune);
			this.currentCustomer.currentOrder = this.currentCustomer.orderFromFune;
		}
	}

	this.randomizeAnOrder = function()
	{
		this.pickARestaurant();
		this.pickACustomer();
		this.setCustomerOrderBasedOnRestaurant();
		this.currentCustomer.defineOrderMessagesForSnatchApp();
		this.currentWaypoint = this.currentRestaurant;
	}

	this.waitingMessage = 'Waiting for an order';

	this.currentMessageLine1 = this.waitingMessage;
	this.currentMessageLine2 = undefined;

	this.status = 'waiting';

	this.startOrderCycle = function()
	{
		let timeToNextOrder = getRandomInt(3000, 5000);
		this.randomizeAnOrder();
		console.log('this.currentCustomer: ' + this.currentCustomer);
		setTimeout( 
			function() 
			{
				snatchApp.status = 'picking up';
				snatchApp.currentMessageLine1 = snatchApp.currentCustomer.currentOrderMessageLine1;
				snatchApp.currentMessageLine2 = snatchApp.currentCustomer.currentOrderMessageLine2;
				orderAlertSFXAudioTag.play();
			}, 
			timeToNextOrder);
	}

	this.drawMessage = function()
	{
		let fontSize = 50;
		canvasContext.font = fontSize + 'px Helvetica';
		canvasContext.fillStyle = 'blue';
		let messageLine1Width = canvasContext.measureText(this.currentMessageLine1).width;
		let messageLine1StartingX = canvas.width/2 - messageLine1Width/2;
		let messageLine1StartingYWithFillTextOffset = fontSize;
		canvasContext.fillText(this.currentMessageLine1, messageLine1StartingX,messageLine1StartingYWithFillTextOffset);


		if (this.currentMessageLine2 !== undefined)
		{
			let messageLine2Width = canvasContext.measureText(this.currentMessageLine2).width;
			let messageLine2StartingX = canvas.width/2 - messageLine2Width/2;
			let messageLine2StartingYWithFillTextOffset = fontSize*2;
			canvasContext.fillText(this.currentMessageLine2, messageLine2StartingX,messageLine2StartingYWithFillTextOffset);
		}
	}
}