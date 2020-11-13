var sarahWhitecotton, josephRoberts;

function Customer(name, apartmentBuildingName, apartmentBuildingTile, orderFromHannahs,orderFromFune)
{
	this.name = name;
	this.apartmentBuildingName = apartmentBuildingName;
	this.apartmentBuildingTile = apartmentBuildingTile;
	this.orderFromHannahs = orderFromHannahs;
	this.orderFromFune = orderFromFune;

	this.currentOrder = undefined;

	this.currentOrderMessageLine1 = name + ' wants ' + this.currentOrder;
	this.currentOrderMessageLine2 = 'Drop off at ' + this.apartmentBuildingName;
}