DROP TABLE costumer;
CREATE TABLE costumer (
	id INT PRIMARY KEY
	, password VARCHAR(80) NOT NULL
	, location VARCHAR(80) NOT NULL
	, idcard VARCHAR(80) NOT NULL
	, compid INT
	, balance INT NOT NULL
	, points INT NOT NULL
);

INSERT INTO costumer VALUES (10, 'almafaOprendszer', 'Budapest', '1234567890', null, 0, 0);
INSERT INTO costumer VALUES (12, 'almafa1Oprendszer', 'Budapest', '3234567890', null, 0, 0);
INSERT INTO costumer VALUES (15, 'almafa2Oprendszer', 'Budapest', '4234567890', null, 0, 0);
INSERT INTO costumer VALUES (17, 'alma', 'Budapest', '6734567890', null, 0, 0);
INSERT INTO costumer VALUES (20, 'korte', 'Budapest', '1238967890', null, 0, 0);
INSERT INTO costumer VALUES (21, 'korte123', 'Budapest', '1231167890', null, 0, 0);
INSERT INTO costumer VALUES (24, 'almakorte', 'Budapest', '1234522890', null, 0, 0);
INSERT INTO costumer VALUES (26, 'almakor1te', 'Budapest', '1234567330', null, 0, 0);
INSERT INTO costumer VALUES (27, 'almakorte545', 'Budapest', '1234457890', null, 0, 0);
INSERT INTO costumer VALUES (28, 'almakorte34', 'Budapest', '1288567890', null, 0, 0);
INSERT INTO costumer VALUES (30, 'almakorte112', 'Budapest', '1291567890', null, 0, 0);
INSERT INTO costumer VALUES (31, 'almakorte768', 'Budapest', '1234566850', null, 0, 0);
INSERT INTO costumer VALUES (33, 'almakorte123123', 'Budapest', '1234567830', null, 0, 0);
INSERT INTO costumer VALUES (35, 'almakorte213', 'Budapest', '1234547890', null, 0, 0);
INSERT INTO costumer VALUES (36, 'almakorte12312', 'Budapest', '1232567890', null, 0, 0);
INSERT INTO costumer VALUES (39, 'almafa2Oprendszer23', 'Budapest', '1234561890', null, 0, 0);
INSERT INTO costumer VALUES (41, 'almafa2Oprendszer9', 'Budapest', '1231567890', null, 0, 0);
INSERT INTO costumer VALUES (45, 'alma33', 'Budapest', '1234567000', null, 0, 0);
INSERT INTO costumer VALUES (46, 'alma9l8', 'Budapest', '9934567890', null, 0, 0);
INSERT INTO costumer VALUES (48, 'almaggz342', 'Budapest', '1984467890', null, 0, 0);
INSERT INTO costumer VALUES (60, 'korte44444', 'Budapest', '1231561810', null, 0, 0);

DROP TABLE computer;
CREATE TABLE computer (
	id INT PRIMARY KEY
	, description VARCHAR(80) NOT NULL
	, os VARCHAR(80) NOT NULL
	, signin VARCHAR(80)
);

INSERT INTO computer VALUES (10, 'Alienware 13', 'openSuse', null);
INSERT INTO computer VALUES (20, 'Alienware 15', 'openSuse', null);
INSERT INTO computer VALUES (30, 'Alienware 17', 'openSuse', null);