

var cyclemins : float;
var cyclecalc : float;

cyclemins = 2;
cyclecalc = 0.1/cyclemins * -1;

function Update () {
	transform.Rotate(cyclecalc,0, 0, Space.World);

}