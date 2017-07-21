function $(id)
{
    return document.getElementById(id);
}

function tableGenerator(n, m)
{
    var table = '';
    for(var i = 0; i < n; ++i)
    {
        table += '<tr>';
        for(var j = 0; j < m; ++j)
        {
            table += '<td></td>';
        }
        table += '</tr>';
    }
    return table;
}

function createListFromArray(array)
{
    return '<li>' + array.join('</li><li>') + '</li>';
}


function createImageForTable(src, alt)
{
    var img = new Image();
    img.style.width = '100%';
    img.style.height = '100%';
    img.style.display = 'block';
    img.src = src;
    img.alt = alt;
    return img;
}

function randomNumber(min, max)
{
    return Math.round(Math.random() * max) + min;
}

function randomCoords(table)
{
    var end = true;
	var x, y;
    var repeat = 0;
	while(end && repeat < 30)
	{
		end = false;
		x = randomNumber(0, table.rows.length - 1);
		y = randomNumber(0, table.rows[0].cells.length - 1);
		end = end || (headCoord.x + 1 != x && headCoord.y != y);
		for(var i = 0, row; row = table.rows[i]; i++)
		{
			for(var j = 0, col; col = row.cells[j]; j++)
			{
				end = end || (col.innerHTML != '' && i == x && j == y);
			}
		}
        ++repeat;
	}
	return {
		x : x
		, y : y };
}
