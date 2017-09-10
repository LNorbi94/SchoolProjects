<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Orszagok');
$m = mysql_query('Select `orszagok`.`orszag`,`orszagok`.`autojel` From `orszagok` Where `orszagok`.`autojel` Like "%C%"');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='150px' style='border:thin solid black'><b>Ország</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Autójel</b></td>
	</tr>";
while ($row = mysql_fetch_assoc($m)) {
	echo "<tr>";
    echo "<td style='border:thin solid black'>".$row["orszag"]."</td>";
    echo "<td style='border:thin solid black'>".$row["autojel"]."</td>";
	echo "</tr>";
	$db++;
}
	echo "</table>";
	
	echo "Összesen ".$db." ország autójelében van C.";
mysql_close($link);
?>