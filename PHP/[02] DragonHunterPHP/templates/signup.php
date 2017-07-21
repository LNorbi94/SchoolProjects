<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <link href="css/default.css" rel="stylesheet">
    <title> Sárkányharcos - Regisztráció </title>
    <script type="text/javascript" src="js/commonFunctions.js"></script>
    <script type="text/javascript">
        function init()
        {
            $('signUp').addEventListener('submit', function(e) { return check(e); }, false);
        }
        
        function check(e)
        {
            var errors = [];
            var eRe = /\w+@\w+\.\w+/;
            if (!eRe.test($('email').value))
            {
                errors.push("Rossz e-mail címet adtál meg!");
            }
            if (errors.length < 1)
            {
                return true;
            }
            else
            {
                e.preventDefault();
                $('errorList').innerHTML = createListFromArray(errors);
                return false;
            }
        }
        window.addEventListener('load', init, false);
    </script>
  </head>
  <body>
    <div id="wrapper">
        <div class="defaultBox">
        <h2> Regisztráció </h2>
        <ul id="errorList">
            <?php foreach($errors as $k) : ?>
                <li> <?= $k ?> </li>
            <?php endforeach; ?>
        </ul>
        <form action="" method="post" id="signUp">
            <label for="name"> Név: </label> <br> <input type="text" id="name" name="name" required="required" autocomplete="off"> <br>
            <input type="text" id="iFooled" style="display: none"> <input type="password" id="youFirefox" style="display: none">
            <label for="pw"> Jelszó: </label> <br> <input type="password" id="pw" name="pw" required="required"> <br>
            <label for="email"> E-mail cím: </label> <br> <input type="email" id="email" name="email" required="required"> <br>
            <input type="submit" value="Regisztráció">
        </form>
        </div>
    </div>
  </body>
</html>
