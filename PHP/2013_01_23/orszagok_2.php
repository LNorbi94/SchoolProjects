<?php
$link = mysql_connect('localhost', 'root', '');
if (!$link) {
    die('Could not connect: ' . mysql_error());
}
mysql_select_db('Orszagok');
$m = mysql_query('Select * From `orszagok` Where `orszagok`.`terulet`>500000 AND `orszagok`.`foldr_hely` Like "%d�l-eur�pa%" ORDER BY `orszagok`.`terulet` DESC');
	echo "<table style='border:thin solid black' border='0'>";
	echo "<tr><td align='center' width='150px' style='border:thin solid black'><b>Orsz�g</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fov�ros</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>F�ldrajzi hely</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Ter�let</b></td>
	<td align='center' width='100px' style='border:thin solid black'><b>�llamforma</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>N�pess�g</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fov�ros n�pess�ge</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Aut�jel</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Country</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Fov�ros</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>P�nznem</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>P�nzjel</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>V�lt�p�nz</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Telefon</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>GDP</b></td>
	<td align='center' width='80px' style='border:thin solid black'><b>Kateg�ria</b></td>
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