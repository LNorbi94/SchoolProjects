function init()
{
    $('start').addEventListener('click', check, false);
    $('newGameBtn').addEventListener('click', location.reload.bind(window.location), false);
    document.addEventListener('keydown', changeDirection, false);
}

function check()
{
    var n = parseInt($('fieldRowSize').value);
    var m = parseInt($('fieldColSize').value);
    var k = parseInt($('objects').value);
    var errors = [];

    if(n < 4 || n > 35 || m < 4 || m > 35)
    {
        errors.push("A pálya méretének 4 és 35 közöttinek kell lennie!");
    }
    if(k < 0 || k > Math.min(n, m))
    {
        errors.push("Pozitív számú tereptárgyat kell megadni (és lehetőleg nem többet a tábla szélessége/magasságánál)!");
    }

    if(errors.length < 1)
    {
        initGame();
    } else
    {
        $('errorList').innerHTML = createListFromArray(errors);
    }
}

function initGame()
{
    $('game').style.display = "block";
    $('gameStarter').hidden = true;

    var n = parseInt($('fieldRowSize').value);
    var m = parseInt($('fieldColSize').value);
    var k = parseInt($('objects').value);
    var table = $('gameTable');

    table.innerHTML = tableGenerator(n, m);
    headCoord.x = n % 2 == 0 ? n / 2 : Math.round(n / 2);
    headCoord.y = 0;
    head = createImageForTable('theme/Head.svg', 'Sárkány feje');
    wisdomScroll = createImageForTable('theme/Scroll.svg', 'Bölcsesség tekercse');
    mirrorScroll = createImageForTable('theme/Scroll.svg', 'Tükrök tekercse');
    switchScroll = createImageForTable('theme/Scroll.svg', 'Fordítás tekercse');
    greedScroll = createImageForTable('theme/Scroll.svg', 'Mohóság tekercse');
    slothScroll = createImageForTable('theme/Scroll.svg', 'Lustaság tekercse');
    gluttonyScroll = createImageForTable('theme/Scroll.svg', 'Falánkság tekercse');

    table.rows[headCoord.x].cells[headCoord.y].appendChild(head);

    for(var i = 0; i < k; ++i)
    {
        var blockage = createImageForTable('theme/Blockage.svg', 'A Tereptárgy');
        var coords = randomCoords(table);
        table.rows[coords.x].cells[coords.y].appendChild(blockage);
    }

    generateScroll(table);
    animation(table);
}

function generateScroll(table)
{
    var rNum = randomNumber(0, 99);
    var coords = randomCoords(table);
    if(rNum >= 0 && rNum <= 79)
    {
        table.rows[coords.x].cells[coords.y].appendChild(wisdomScroll);
    } else if(rNum > 79 && rNum <= 83)
    {
        table.rows[coords.x].cells[coords.y].appendChild(mirrorScroll);
    } else if(rNum > 83 && rNum <= 87)
    {
        table.rows[coords.x].cells[coords.y].appendChild(switchScroll);
    } else if(rNum > 87 && rNum <= 91)
    {
        table.rows[coords.x].cells[coords.y].appendChild(greedScroll);
    } else if(rNum > 91 && rNum <= 95)
    {
        table.rows[coords.x].cells[coords.y].appendChild(slothScroll);
    } else if(rNum > 95 && rNum <= 99)
    {
        table.rows[coords.x].cells[coords.y].appendChild(gluttonyScroll);
    }
}

function changeDirection()
{
    var oldWay = way;
    var keyCode;

    if(window.event)
    {
        keyCode = window.event.keyCode;
    } else if(e)
    {
        keyCode = e.which;
    }

    if( (activeWay != RIGHT    || keyCode != LEFT  ) 
        && (activeWay != LEFT  || keyCode != RIGHT )
        && (activeWay != UP    || keyCode != DOWN  )
        && (activeWay != DOWN  || keyCode != UP    )
        && keyCode >= 36       && keyCode <= 40 )
    {
        if(activeScroll === 'T')
        {
            switch(keyCode)
            {
                case DOWN:
                    way = UP;
                    break;
                case UP:
                    way = DOWN;
                    break;
                case LEFT:
                    way = RIGHT;
                    break;
                case RIGHT:
                    way = LEFT;
                    break;
            }
        } else 
        {
            way = keyCode;
        }
    }
}

function changeText(text)
{
    $('activeScroll').innerHTML = text;
}

function addPoint(point)
{
    var actualPoint = $('points').innerHTML;
    $('points').innerHTML = parseInt(actualPoint) + point;
}

window.addEventListener('load', init, false);
