<?php
	$db = mysql_connect('localhost', 'root', '');
	if (!$db) {
    die('Nem tudtam kapcsol�dni: ' . mysql_error());
	}
?>