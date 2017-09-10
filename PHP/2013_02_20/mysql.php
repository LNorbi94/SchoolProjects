<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Nem tudtam kapcsolódni: ' . mysql_error());
	}
?>