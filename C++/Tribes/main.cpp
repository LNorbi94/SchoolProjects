//Név: Lestár Norbert | Neptun kód: A8UZ7T
//Feladat: Törzsek
//D
//Add meg a háborúk átlagos idejét!
//R
//Adj meg egy békés törzset, amely senkivel sem volt ellenséges viszonyban!
//BB
//Add meg a legtöbbet háborúzó törzs nevét és háborúi számát.
//TT
//Adj meg egy törzset, amely csak egyszer háborúzott!

#include <iostream>
#include <fstream>
#include <string>
#include <cstdlib>
#include <limits>

using namespace std;

struct tWar {
	string ki;
	string kivel;
	int mettol;
	int meddig;
};
struct tTorzs {
    string nev;
    int haboruk;
};

void readf(bool &erroro, int &wn, int &tn, tWar Haboruk[], tTorzs Torzsek[]);
void readk(int &wn, int &tn, tWar Haboruk[], tTorzs Torzsek[]);
void kiir(int wn, int tn, tWar Haboruk[], tTorzs Torzsek[]);
int atlag(int wn, tWar Haboruk[]);
void Haboruszam(int tn, int wn, tWar Haboruk[], tTorzs Torzsek[]);
string keres(int tn, tTorzs Torzsek[], int szam);
tTorzs maxkiv(int tn, tTorzs Torzsek[]);

int main()
{
	char task, valasz;
    bool erroro;
	int valaszn, taskn, tn, wn;
	tWar Haboruk[100];
	tTorzs Torzsek[100];
	setlocale(LC_ALL,"Hun");

	taskn = 0;
	valaszn = 0;
    do {
    system("CLS");
	if (valaszn > 0 && valasz != 'i') { cout << "Kerem i/n-el valaszoljon." << endl; }
	if (valasz == 'i' || valaszn == 0) {
    if (valasz =='i') { taskn = 0; valaszn = 0; }
	do {
    system("CLS");
	if (taskn > 0) { cout << "Kerem 1-2 kozotti szamot adjon meg." << endl; }
	cout << "Hogyan toltsem fel az adatokat?" << endl;
	cout << "1 - Fajlbol (fajl nevet meg kell adni.)" << endl;
	cout << "2 - Billentyuzetrol." << endl;
	cin >> task;
	taskn++;
	} while(task != '1' && task != '2');
	if (task == '1' && valaszn == 0) { readf(erroro, wn, tn, Haboruk, Torzsek); }
	if (task == '2' && valaszn == 0) { readk(wn, tn, Haboruk, Torzsek); }
	}

	if (erroro == false) { kiir(wn, tn, Haboruk, Torzsek);
	cout << "Haboruk atlagos ideje: " << atlag(wn, Haboruk) << " ev." << endl;
	Haboruszam(tn, wn, Haboruk, Torzsek);
	if (keres(tn, Torzsek, 0) == "") { cout << "Nem volt bekes torzs." << endl; } else { cout << "Bekes torzs: " << keres(tn, Torzsek, 0) << endl; }
	cout << maxkiv(tn, Torzsek).nev << " nevu torzs haboruzott legtobbet, szamszerint: " << maxkiv(tn, Torzsek).haboruk << "." << endl;
	if (keres(tn, Torzsek, 1) == "") { cout << "Nem volt egyszer haboruzo torzs." << endl; } else { cout << "Egyszer vonult hadba: " << keres(tn, Torzsek, 1) << "." << endl; }
	}
	cout << "Szeretne ujra kezdeni? (i/n)" << endl;
	cin >> valasz;
	valaszn++;
    } while(valasz != 'n');
     return 0;
}

void kiir(int wn, int tn, tWar Haboruk[], tTorzs Torzsek[])
{
    cout << "Torzsek szama: " << tn << endl;
	cout << "Torzsek nevei: " << endl;
    for (int i=0;i<tn;i++)
    {
       cout << Torzsek[i].nev <<endl;
	   Torzsek[i].haboruk = 0;
    }
	cout << "Haboruk szama: " << wn << endl;
	cout << "Haboruk adatai: " << endl;
    for (int i=0;i<wn;i++)
    {
       cout << Haboruk[i].ki << " torzs harcolt a(z) " << Haboruk[i].kivel << " torzzsel, " << Haboruk[i].mettol
	   << "-tol, " << Haboruk[i].meddig <<"-ig." << endl;
    }
}

void readf(bool &erroro, int &wn, int &tn, tWar Haboruk[], tTorzs Torzsek[])
{
    tn = 0; wn = 0;
    string nev;
	nev = "";
	cout << "Adja meg a fajl nevet:" << endl;
	cin >> nev;
	ifstream be(nev.c_str());
	if (be.fail()) {
        cout << "Nem nyithato meg a fajl!" << endl;
        erroro=true;
        return;
	} else {
    erroro=false;
	string sor;
	getline(be,sor,'\n');
	tn=atoi(sor.c_str());
	for (int i=0;i<tn;i++)
    {
       getline(be,sor,'\n');
	   Torzsek[i].nev = sor;
	   Torzsek[i].haboruk = 0;
    }

	getline(be,sor,'\n');
	wn=atoi(sor.c_str());
	for (int i=0;i<wn;i++)
    {
       getline(be,sor,'\n');
	   Haboruk[i].ki = sor;
       getline(be,sor,'\n');
	   Haboruk[i].kivel = sor;
       getline(be,sor,'\n');
	   Haboruk[i].mettol = atoi(sor.c_str());
       getline(be,sor,'\n');
	   Haboruk[i].meddig = atoi(sor.c_str());
    }
    return;
	}
}

void readk(int &wn, int &tn, tWar Haboruk[], tTorzs Torzsek[])
{
    bool hiba = false;
    tn=1; wn=1;
    do {
    if(hiba || tn < 1) { cout << "Kerem pozitiv egesz szamot adjon meg." << endl; }
	cout << "Adja meg a torzsek szamat:" << endl;
    if (cin >> tn) { hiba = false; } else { hiba = true; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); }
    } while(hiba || tn < 1);
	for (int i=0;i<tn;i++)
    {
		cout << "Adja meg a(z) " << (i+1) << ". torzs nevet:" << endl;
		cin >> Torzsek[i].nev;
    }

    hiba = false;
    do {
    if(hiba || wn < 1) { cout << "Kerem pozitiv egesz szamot adjon meg." << endl; }
	cout << "Adja meg a haboruk szamat:" << endl;
    if (cin >> wn) { hiba = false; } else { hiba = true; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); }
    } while(hiba || wn < 1);
	for (int i=0;i<wn;i++)
    {
       cout << (i+1) << ". Haboru. Ki kezdte: " << endl;
	   cin >> Haboruk[i].ki;
       cout << "Ki ellen: " << endl;
	   cin >> Haboruk[i].kivel;
       hiba = false;
       do {
	   cout << "Mettol: [pozitiv egesz szam]" << endl;
       if (cin >> Haboruk[i].mettol) { hiba = false; } else { hiba = true; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); }
       } while(hiba || Haboruk[i].mettol < 1);
       bool hiba2 = false;
       Haboruk[i].meddig = 0;
       do {
	   cout << "Meddig: [pozitiv egesz szam]" << endl;
       if (cin >> Haboruk[i].meddig) { hiba2 = false; } else { hiba2 = true; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); }
       } while(hiba2 || Haboruk[i].meddig < 1);
    }
}

int atlag(int wn, tWar Haboruk[])
{
    int atlag = 0;
    int osszes;
    int ev[wn];
    cout << "Haboruk ideje: ";
    for(int i=0;i<wn;i++){
        ev[i] = Haboruk[i].meddig - Haboruk[i].mettol;
        cout << ev[i];
        if (i<wn-1) { cout << " ev, "; } else { cout << " ev." << endl; }
    }
    for(int i=0;i<wn;i++){
        osszes += ev[i];
    }
    atlag = (osszes / wn);
    return atlag;
}

void Haboruszam(int tn, int wn, tWar Haboruk[], tTorzs Torzsek[])
{
    for(int i=0;i<wn;i++) {
        for(int j=0;j<tn;j++){
            if(Haboruk[i].ki == Torzsek[j].nev || Haboruk[i].kivel == Torzsek[j].nev){
                Torzsek[j].haboruk++;
            }
        }
    }
}

string keres(int tn, tTorzs Torzsek[], int szam) {
    string bekes = "";
    for(int i=0;i<tn;i++){
        if(Torzsek[i].haboruk == szam) {
            bekes = Torzsek[i].nev;
            return bekes;
        }
    }
    return bekes;
}

tTorzs maxkiv(int tn, tTorzs Torzsek[])
{
    int max = 0;
    int legtobb = Torzsek[max].haboruk;
    for(int i=1;i<tn;i++){
        if (legtobb < Torzsek[i].haboruk){
            max = i;
            legtobb = Torzsek[i].haboruk;
        }
    }
    return Torzsek[max];
}
