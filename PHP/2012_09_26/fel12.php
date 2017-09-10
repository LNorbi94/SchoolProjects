<?php
$ossz =0;
for ($i=1; $i<2*$szam-1; $i++)
{
if ($i%2 ==1)
{
$ossz = $ossz+$i;
}
}
echo "A páratlan számok összege: ".$ossz;
?>
