<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Tevenevelde');
$m = mysql_query('Select * From `tevek`');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='80px' style='border:thin solid black'><b>Sorsz�m</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>N�v</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Jelsz�</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fi�-e</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Datolya DB</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>�hes</b></td></tr>";
while ($row = mysql_fetch_assoc($m)) {
	echo "<tr>";
    echo "<td style='border:thin solid black'>".$row["Sorszam"]."</td>";
    echo "<td style='border:thin solid black'>".$row["Nev"]."</td>";
    echo "<td style='border:thin solid black'>".$row["Jelszo"]."</td>";
	echo "<td style='border:thin solid black'>".$row["Fiue"]."</td>";
	echo "<td style='border:thin solid black'>".$row["Datolyadb"]."</td>";
	echo "<td style='border:thin solid black'>".$row["Ehes"]."</td>";
	echo "</tr>";
}
	echo "</table>";
mysql_close($link);
?>