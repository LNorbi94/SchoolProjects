<?php
if (!isset($kuldve))
{
?>
<html>
<form enctype="multipart/form-data" method="post" action="">
<label for="">Avatar: </label>
<input type="file" name="avatar" id="avatar"><br> 
<input type="submit" name="kuldve">
</form>
</html>
<? 
} else
{
	echo "<img src='".$_FILES['avatar']['name']."'>";
}
?>