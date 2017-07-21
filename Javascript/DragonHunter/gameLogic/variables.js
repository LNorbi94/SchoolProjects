var LEFT	= 37;
var UP		= 38;
var RIGHT	= 39;
var DOWN	= 40;

var way         = RIGHT;
var activeWay   = way;
var speed       = 500;
var baseSpeed   = 500;
var stop        = false;

var head;
var headCoord =
{
	x: -1
	, y: -1
}
var tails = [];
var activeScroll;
var scrollID = 0;

var wisdomScroll;
var mirrorScroll;
var switchScroll;
var greedScroll;
var slothScroll;
var gluttonyScroll;