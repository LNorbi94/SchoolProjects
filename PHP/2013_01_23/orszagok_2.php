<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Orszagok');
$m = mysql_query('Select * From `orszagok` Where `orszagok`.`terulet`>500000 AND `orszagok`.`foldr_hely` Like "%dél-európa%" ORDER BY `orszagok`.`terulet` DESC');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='150px' style='border:thin solid black'><b>Ország</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fováros</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Földrajzi hely</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Terület</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>Államforma</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Népesség</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fováros népessége</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Autójel</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Country</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fováros</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Pénznem</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Pénzjel</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Váltópénz</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Telefon</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>GDP</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Kategória</b></td>
	</tr>";
while ($row = mysql_fetch_assoc($m)) {
	echo "<tr>";
    echo "<td style='border:thin solid black'>".$row["orszag"]."</td>";
    echo "<td style='border:thin solid black'>".$row["fovaros"]."</td>";
    echo "<td style='border:thin solid black'>".$row["foldr_hely"]."</td>";
	echo "<td style='border:thin solid black'>".$row["terulet"]."</td>";
	echo "<td style='border:thin solid black'>".$row["allamforma"]."</td>";
	echo "<td style='border:thin solid black'>".$row["nepesseg"]."</td>";
	echo "<td style='border:thin solid black'>".$row["nep_fovaros"]."</td>";
	echo "<td style='border:thin solid black'>".$row["autojel"]."</td>";
	echo "<td style='border:thin solid black'>".$row["country"]."</td>";
	echo "<td style='border:thin solid black'>".$row["capital"]."</td>";
	echo "<td style='border:thin solid black'>".$row["penznem"]."</td>";
	echo "<td style='border:thin solid black'>".$row["penzjel"]."</td>";
	echo "<td style='border:thin solid black'>".$row["valtopenz"]."</td>";
	echo "<td style='border:thin solid black'>".$row["telefon"]."</td>";
	echo "<td style='border:thin solid black'>".$row["gdp"]."</td>";
	echo "<td style='border:thin solid black'>".$row["kat"]."</td>";
	echo "</tr>";
}
	echo "</table>";
mysql_close($link);
?>