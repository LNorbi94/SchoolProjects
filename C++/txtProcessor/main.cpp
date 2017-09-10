#include <iostream>
#include <fstream>
#include <string>
#include <vector>
#include <limits>
#include <stdlib.h>

using namespace std;

struct table
{
    struct client
    {
		string name;
		string zipcode;
		string town;
		string street;
    };
	string company;
	string ktvnumber;
	client client;
	string yearly_fee;
	string fee_interval;
	string license_plate_number;
	string start;
	string storno;
	string description;
	string payment_method;
	string ending;
	string MABISZfee;
	string fee_done_until;
	string actual_payment;
	string BMclass;
};

vector<table> datas;


int main(int argc, char* argv[])
{
	setlocale(LC_ALL, "HU");
	string flname = "file.txt";
	ifstream file;
	file.open(flname);
	string line;
	getline(file, line, '\n');
	while (!file.eof())
	{
		table data;
		// column name: BIZTNEVE
		getline(file, line, '\t');
		data.company = line;
		// column name: MODOZAT
		getline(file, line, '\t');
		// column name: MODNEVE
		getline(file, line, '\t');
		// column name: KTVSZAM
		getline(file, line, '\t');
		data.ktvnumber = line;
		// column name: Szerződő
		getline(file, line, '\t');
		data.client.name = line;
		// column name: UGISZAM
		getline(file, line, '\t');
		data.client.zipcode = line;
		// column name: UGVAROS
		getline(file, line, '\t');
		data.client.town = line;
		// column name: UGUTCA
		getline(file, line, '\t');
		data.client.street = line;
		// column name: EvesDij
		getline(file, line, '\t');
		data.yearly_fee = line;
		// column name: FizUtem
		getline(file, line, '\t');
		data.fee_interval = line;
		// column name: Rendszám
		getline(file, line, '\t');
		data.license_plate_number = line;
		// column name: KEZDET
		getline(file, line, '\t');
		data.start = line;
		// column name: STORNO
		getline(file, line, '\t');
		data.storno = line;
		// column name: UkNeve1
		//file.ignore(numeric_limits<streamsize>::max(), '\t');
		getline(file, line, '\t');
		// column name: UkKodja1
		getline(file, line, '\t');
		// column name: JUTSZAZ1
		getline(file, line, '\t');
		// column name: UkKodja2
		getline(file, line, '\t');
		// column name: UkNeve2
		getline(file, line, '\t');
		// column name: JUTSZAZ2
		getline(file, line, '\t');
		// column name: UkKodja3
		getline(file, line, '\t');
		// column name: UkNeve3
		getline(file, line, '\t');
		// column name: JUTSZAZ3
		getline(file, line, '\t');
		// column name: FőModKod
		getline(file, line, '\t');
		// column name: Megnevezés
		getline(file, line, '\t');
		data.description = line;
		// column name: JutTab1
		getline(file, line, '\t');
		// column name: JutTab2
		getline(file, line, '\t');
		// column name: JutTab3
		getline(file, line, '\t');
		// column name: ROGZDAT
		getline(file, line, '\t');
		// column name: SzerződésSorszám
		getline(file, line, '\t');
		// column name: FoBiztosito
		getline(file, line, '\t');
		// column name: LizingKezdet
		getline(file, line, '\t');
		// column name: LizingVege
		getline(file, line, '\t');
		// column name: Torles
		getline(file, line, '\t');
		// column name: UgyfKod
		getline(file, line, '\t');
		// column name: FIZMOD
		getline(file, line, '\t');
		data.payment_method = line;
		// column name: Lejarat
		getline(file, line, '\t');
		data.ending = line;
		// column name: B_KTVSZAM
		getline(file, line, '\t');
		// column name: Rendszám2
		getline(file, line, '\t');
		// column name: b_kezdet
		getline(file, line, '\t');
		// column name: b_storno
		getline(file, line, '\t');
		// column name: b_edij
		getline(file, line, '\t');
		// column name: b_lejar
		getline(file, line, '\t');
		// column name: k_rendszam
		getline(file, line, '\t');
		// column name: k_ktvszam
		getline(file, line, '\t');
		// column name: b_szerzodesid
		getline(file, line, '\t');
		// column name: FentartasiJutUk1
		getline(file, line, '\t');
		// column name: FentartasiJutUk2
		getline(file, line, '\t');
		// column name: FentartasiJutUk3
		getline(file, line, '\t');
		// column name: MABISZdij
		getline(file, line, '\t');
		data.MABISZfee = line;
		// column name: DijRendezveIg
		getline(file, line, '\t');
		data.fee_done_until= line;
		// column name: AktualisFizUtemSzDij
		getline(file, line, '\t');
		data.actual_payment = line;
		// column name: BMbesorolas
		getline(file, line, '\t');
		data.BMclass = line;
		file.ignore(numeric_limits<streamsize>::max(), '\n');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\t');
		//// column name: UkNeve1
		//getline(file, line, '\n');
		datas.push_back(data);
	}
	ofstream outf;
	string newname = "_new"+flname;
	outf.open(newname);
	outf << "BIZTNEVE\tKTVSZAM\tSzerződő\tUGISZAM\tUGVAROS\tUGUTCA\tEvesDij\tFizUtem\tRendszám\tKEZDET\tSTORNO\tMegnevezés\tFIZMOD\tLejarat"
                "\tMABISZdij\tDijRendezveIg\tAktualisFizUtemSzDij\tBMbesorolas\n";
	for (auto & element : datas) {
		outf << element.company << "\t" << element.ktvnumber << "\t" << element.client.name << "\t" << element.client.zipcode << "\t" << element.client.town
                     << "\t" << element.client.street << "\t" << element.yearly_fee << "\t" << element.fee_interval << "\t" << element.license_plate_number << "\t" << element.start
                     << "\t" << element.storno << "\t" << element.description << "\t" << element.payment_method << "\t" << element.ending << "\t" << element.MABISZfee 
                     << "\t" << element.fee_done_until << "\t" << element.actual_payment << "\t" << element.BMclass << "\n";
	}
	return 0;
}