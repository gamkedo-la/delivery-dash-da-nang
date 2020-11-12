var scooterImage = document.createElement("img");
var scooterImageLoaded = false;

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

function loadImages()
{
	scooterImage.onload = function()
	{
		scooterImageLoaded = true;
	}
	scooterImage.src = 'images/raw/Scooter/scooter-auto-spritesheet-16.png';

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
}

//scooter spritesheet source dimensions
//total width: 3232, individual frame: 202
//height: 197