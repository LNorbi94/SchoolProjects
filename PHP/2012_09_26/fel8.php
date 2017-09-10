<table width="200" border="1">
<?php
for($i=1;$i<$a+1;$i++)
{echo "<tr>";
for($j=1;$j<$b+1;$j++)
{
echo "<td align='right'>".$i * $j."</td>";
}
echo "</tr>";
}
?>
</table>