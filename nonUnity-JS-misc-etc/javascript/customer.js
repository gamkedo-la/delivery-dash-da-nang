var sarahWhitecotton, josephRoberts;

function Customer(name, apartmentBuildingName, apartmentBuildingTile, apartmentBuildingWidth, apartmentBuildingHeight,
				  waypointBoxDirection, orderFromHannahs,orderFromFune)
{
	this.name = name;
	this.apartmentBuildingName = apartmentBuildingName;
	this.apartmentBuildingTile = apartmentBuildingTile;
	this.width = apartmentBuildingWidth;
	this.height = apartmentBuildingHeight;
	this.waypointBoxDirection = waypointBoxDirection;

	this.orderFromHannahs = orderFromHannahs;
	this.orderFromFune = orderFromFune;

	this.currentOrder = undefined;

	this.currentOrderMessageLine1 = name + ' wants ' + this.currentOrder;
	this.currentOrderMessageLine2 = 'Drop off at ' + this.apartmentBuildingName;

	this.defineOrderMessagesForSnatchApp = function()
	{
		this.currentOrderMessageLine1 = name + ' wants ' + this.currentOrder + ' from ' + snatchApp.currentRestaurant.name;
		this.currentOrderMessageLine2 = 'Drop off at ' + this.apartmentBuildingName;
	}
}