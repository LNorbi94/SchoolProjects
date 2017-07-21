// Kvízjáték
// Ebben a játékban országok zászlóinak színét kell kitalálni.
// Egy fájlban tároljuk az ország nevét és a zászlójának színeit. Véletlen szerűen kisorsoljuk egy ország nevét. A játékosnak meg kell adnia a zászló színeit. Jelezzük neki, hogy sikerült-e kitalálnia. Siker esetén akár ki is rajzolhatjuk a zászlót.
// Feladat: Készítse el a fenti játékot játszó programot!
// 
// Név: Lestár Norbert
// Neptun kód: A8UZ7T

import java.util.ArrayList;
import java.io.*;
import java.util.concurrent.ThreadLocalRandom;
import java.util.Scanner;

class Flags {
  
  private ArrayList<Country> countries;
  public Country country;
  
  class Country {
    public Country(String name, String[] colour) {
      this.name = name;
      this.colour = colour;
    }
    public String name;
    public String[] colour;
  }
  
  public Flags() {
    countries = null;
    country = null;
  }
  
  public void readFile(String filename) {
    BufferedReader br = null;
    countries = new ArrayList<>();
    
    try {
      br = new BufferedReader( new FileReader(filename) );
      String line = null;
      while ((line = br.readLine()) != null) {
        String name = null;
        String[] lines = line.split(" ");
        String[] colour = new String[lines.length - 1];
        for(int i = 0; i < lines.length; ++i) {
          if(i == 0) {
            name = lines[i];
          } else {
            colour[i - 1] = lines[i];
          }
        }
        countries.add( new Country(name, colour) );
      }
    } catch (FileNotFoundException e) {
      e.printStackTrace();
    } catch (IOException e) {
      e.printStackTrace();
    } finally {
      if (br != null) {
        try {
          br.close();
        } catch (IOException e) {
          e.printStackTrace();
        }
      }
    }
    country = selectCountry();
  }
  
  public Country selectCountry() {
    final int i = ThreadLocalRandom.current().nextInt(0, countries.size());
    return countries.get(i);
  }
  
  public void writeColours() {
    for(Country c : countries) {
      for(int i = 0; i < c.colour.length; ++i) {
        System.out.println( c.colour[i] );
      }
    }
  }
  
  public boolean checkColours(final ArrayList<String> colours) {
    if(colours == null)
      return false;
    boolean correct = true;
    for(int i = 0; i < country.colour.length; ++i) {
      correct = correct && colours.contains( country.colour[i] );
    }
    correct = correct && colours.size() == country.colour.length;
    return correct;
  }
  
  public static void main(String[] args) {
    Flags fl = new Flags();
    fl.readFile("country.txt");
    fl.writeColours();
    System.out.println("Kerem adja meg a szineket! Kilepeshez irja be hogy 'vege'.");
    Scanner in = new Scanner(System.in);
    String colour;
    ArrayList<String> colours = new ArrayList<>();
    while( !(colour = in.nextLine()).contains("vege") ) {
      colours.add(colour);
    }
    if( fl.checkColours(colours) ) {
      System.out.println("Gratulalok! Nyertel.");
    } else {
      System.out.println("Sajnalom, most nem nyertel.");
    }
  }
  
}
