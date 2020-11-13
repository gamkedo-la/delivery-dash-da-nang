var scooterImage = document.createElement("img");
var scooterImageLoaded = false;

var cubScooterImage = document.createElement("img");
var cubScooterImageLoaded = false;

var roadImage = document.createElement("img");
var roadImageLoaded = false;

var roadWithHorizontalDashImage = document.createElement("img");
var roadWithHorizontalDashImageLoaded = false;

var roadWithVerticalDashImage = document.createElement("img");
var roadWithVerticalDashImageLoaded = false;

var sidewalkImage = document.createElement("img");
var sidewalkImageLoaded = false;

var hannahsImage = document.createElement("img");
var hannahsImageLoaded = false;

var seasandImage = document.createElement("img");
var seasandImageLoaded = false;

var randoBuildingImage = document.createElement("img");
var randoBuildingImageLoaded = false;

var funeSushiImage = document.createElement("img");
var funeSushiImageLoaded = false;

var carFacingRightImage = document.createElement("img");
var carFacingRightImageLoaded = false;

var carFacingLeftImage = document.createElement("img");
var carFacingRightImageLoaded = false;

var carFacingDownImage = document.createElement("img");
var carFacingRightImageLoaded = false;

var carFacingUpImage = document.createElement("img");
var carFacingRightImageLoaded = false;

var chipsImage = document.createElement("img");
var chipsImageLoaded = false;


function loadImages()
{
	scooterImage.onload = function()
	{
		scooterImageLoaded = true;
	}
	scooterImage.src = 'images/raw/Scooter/scooter-auto-spritesheet-16.png';

	cubScooterImage.onload = function()
	{
		cubScooterImageLoaded = true;
	}
	cubScooterImage.src = 'images/raw/scooter-auto/scooter-cub-top-spritesheet-16.png';

	roadImage.onload = function()
	{
		roadImageLoaded = true;
	}
	roadImage.src = 'images/raw/Placeholder/Road/road.png';

	roadWithHorizontalDashImage.onload = function()
	{
		roadWithHorizontalDashImageLoaded = true;
	}
	roadWithHorizontalDashImage.src = 'images/raw/Placeholder/Road/road_with_horizontal_dash.png';

	roadWithHorizontalDashImage.onload = function()
	{
		sidewalkImageLoaded = true;
	}
	sidewalkImage.src = 'images/raw/Placeholder/Road/sidewalk.png';

	roadWithVerticalDashImage.onload = function()
	{
		roadWithVerticalDashImageLoaded = true;
	}
	roadWithVerticalDashImage.src = 'images/raw/Placeholder/Road/road_with_vertical_dash.png';

	hannahsImage.onload = function()
	{
		hannahsImageLoaded = true;
	}
	hannahsImage.src = 'images/raw/Placeholder/Buildings/hannahs.png';

	seasandImage.onload = function()
	{
		seasandImageLoaded = true;
	}
	seasandImage.src = 'images/raw/Placeholder/Buildings/seasand.png';

	randoBuildingImage.onload = function()
	{
		randoBuildingImageLoaded = true;
	}
	randoBuildingImage.src = 'images/raw/Placeholder/Buildings/randoBuilding.png';

	funeSushiImage.onload = function()
	{
		funeSushiImageLoaded = true;
	}
	funeSushiImage.src = 'images/raw/Placeholder/Buildings/fune.png';

	carFacingRightImage.onload = function()
	{
		carFacingRightImageLoaded = true;
	}
	carFacingRightImage.src = 'images/raw/Placeholder/Vehicles/carFacingRight.png';

	carFacingLeftImage.onload = function()
	{
		carFacingLeftImageLoaded = true;
	}
	carFacingLeftImage.src = 'images/raw/Placeholder/Vehicles/carFacingLeft.png';

	carFacingDownImage.onload = function()
	{
		carFacingDownImageLoaded = true;
	}
	carFacingDownImage.src = 'images/raw/Placeholder/Vehicles/carFacingDown.png';

	carFacingUpImage.onload = function()
	{
		carFacingUpImageLoaded = true;
	}
	carFacingUpImage.src = 'images/raw/Placeholder/Vehicles/carFacingUp.png';

	chipsImage.onload = function()
	{
		chipsImageLoaded = true;
	}
	chipsImage.src = 'images/raw/Placeholder/Buildings/chips.png';
}

//scooter spritesheet source dimensions
//total width: 3232, individual frame: 202
//height: 197