<!DOCTYPE html>
<html>
  <head>
    <meta charset="utf-8">
    <link href="css/default.css" rel="stylesheet">
    <title> Sárkányharcos </title>
  </head>
  <body>
    <div id="wrapper">
        <aside id="gameStartMenu">
            <?php if (!logged()) : ?>
            <p>
                <ul>
                    <li> <a href="index.php?game"> Játék vendégként </a> </li>
                    <li> <a href="index.php?signup"> Regisztráció </a> </li>
                </ul>
            </p>
            <p> <h1> Bejelentkezés </h1> 
                <form action="index.php?signin" method="post">
                    <label for="email"> E-mail: </label> <br> <input type="email" id="email" name="email" required="required"> <br>
                    <label for="pw"> Jelszó: </label> <br> <input type="password" id="pw" name="pw" required="required">
                    <input type="submit" value="Bejelentkezés">
                </form>
            </p>
            <?php else : ?>
            <p>
                <h1> Üdvözöllek, <?= $_SESSION['name'] ?>! </h1>
                <ul>
                    <li> <a href="index.php?game"> Játék indítása </a> </li>
                    <li> <a href="index.php?signout"> Kijelentkezés </a> </li>
                </ul>
            <?php endif; ?>
        </aside>
        <div id="gameStarter" class="defaultBox">
        <h2> Sárkányharcos </h2>
        <img src="img/logo.png" alt="Sárkány">
            <p>
                Az ősi Kínában – a feljegyzések legalábbis erre utalnak – jóval az időszámításunk előtt volt egy furcsa megmérettetés: kínai vitézek rátermettségüket azzal bizonyították,
                hogy minél tovább próbálták megülni Chai-Si hegyvidék varázslatos sárkányát. A legjobb vitéz lett az év sárkányharcosa.
            </p>
            <p>
                A szerencsét próbáló vitézek egy arénánál gyülekeztek. Egyesével ültek fel az aréna bejáratánál a sárkány hátára, majd a sárkányt beengedték az arénába. A cél az volt,
                hogy a sárkánnyal minél több tekercset gyűjtsön be a vitéz. Egyszerre egy tekercset dobtak az aréna véletlenszerű helyére.
            </p>
            <p>
                Ha a sárkány felvette a tekercset, akkor annak hatására bölcsebb és nagyobb lett. Voltak azonban olyan tekercsek, amelyek egyéb varázslatot tartalmaztak. Az arénában ezek mellett lehettek tereptárgyak is.
                A játékban Te a fiatal és ügyes vitézt, Teng Lenget alakítod. Segíts neki sárkányharcossá válni!
            </p>
            <p>
                Azaz a játék célja, hogy sárkányod minnél nagyobbra nőjön. Ha a sárkány a saját farkába harap, tereptárgyba ütközik, vagy falnak, akkor a játéknak vége lesz.
            </p>
            <p>
                6 féle mágikus tekercset dobhatnak a bírók a pályára, névszerint:
                <ul>
                    <li> Bölcsesség tekercse (80%): a sárkány 4 egységgel növekszik tőle. </li>
                    <li> Tükrök tekercse (4%): az irányítás tükörképben történik irányonként (fel helyett le, bal helyett jobb). </li>
                    <li> Fordítás tekercse (4%): a sárkány haladási iránya megfordul (feje és farka helyett cserél).
                        (A bírók egyik este részegen írták ezt a tekercset, így néhány mellékhatása a tekercsnek lehet rosszullét, fejfájás, vagy gyors lefolyású halál).
                    </li>
                    <li> Mohóság tekercse (4%): a sárkány haladási sebessége másfélszeresére nő 5 másodpercig. </li>
                    <li> Lustaság tekercse (4%): a sárkány haladási sebessége másfélszeresére csökken 5 másodpercig. </li>
                    <li> Falánkság tekercse (4%): a sárkány 10 egységgel növekszik tőle. </li>
                </ul>
        </div>
    </div>
  </body>
</html>
