var splashscreenShouldBeShowing = true;

function drawSplashScreen()
{
	canvasContext.fillStyle = 'gray';
	canvasContext.fillRect(0,0, canvas.width,canvas.height);
	canvasContext.fillStyle = 'yellow';
	canvasContext.font = '30px Helvetica';
	canvasContext.fillText('Click to start', canvas.width/2 - 60, canvas.height/2);
}