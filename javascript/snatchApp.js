var snatchApp;

function SnatchApp()
{
	this.arrayOfCustomers = [];
	this.arrayOfRestaurants = [];

	this.currentCustomer = undefined;
	this.currentRestaurant = undefined;

	this.initialize = function()
	{
		this.arrayOfCustomers.push(sarahWhitecotton,josephRoberts);
		this.arrayOfRestaurants.push(hannahs,fune);
		this.pickACustomer();
		this.pickARestaurant();
	}

	this.pickACustomer = function()
	{
		let randomCustomerIndex = getRandomInt(0, this.arrayOfCustomers.length - 1);
		this.currentCustomer = this.arrayOfCustomers[randomCustomerIndex];
	}

	this.pickARestaurant = function()
	{
		let randomRestaurantIndex = getRandomInt(0, this.arrayOfRestaurants.length - 1);
		this.currentRestaurant = this.arrayOfRestaurants[randomRestaurantIndex];
	}

	this.randomizeAnOrder = function()
	{
		this.pickACustomer();
		this.pickARestaurant();
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
				snatchApp.currentMessageLine1 = this.currentCustomer.currentOrderMessageLine1;
				snatchApp.currentMessageLine2 = this.currentCustomer.currentOrderMessageLine2;
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