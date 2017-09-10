<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Tevenevelde');
$m = mysql_query('Select * From `tevek`');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='80px' style='border:thin solid black'><b>Sorszám</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Név</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Jelszó</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fiú-e</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Datolya DB</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Éhes</b></td></tr>";
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