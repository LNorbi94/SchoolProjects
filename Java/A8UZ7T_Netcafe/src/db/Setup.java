package db;

import java.io.File;
import java.io.FileNotFoundException;
import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.Scanner;

public class Setup {

    public static void main(String[] args) {
        final File file = new File("netcafe.sql");
        try (   final Scanner scanner = new Scanner(file);
                final Connection conn = DataBase.getInstance().getConnection();
                final Statement statement = conn.createStatement()) {

            scanner.useDelimiter(";");
            while (scanner.hasNext()) {
                final String sqlQuery = scanner.next().trim();

                if (!"".equals(sqlQuery) && !sqlQuery.toUpperCase().startsWith("SELECT")) {
                    try {
                        statement.execute(sqlQuery);
                    } catch (SQLException ex) {
                        System.err.println(sqlQuery.replaceAll("\\s+", " ") + " feldolgozása során hiba történt!");
                        System.err.println(ex.getMessage());
                    }
                }
            }

        } catch (FileNotFoundException ex) {
            System.err.println("A netcafe.sql fájl nem található!");
        } catch (SQLException ex) {
            System.err.println("Adatbázissal kapcsolatos kivétel keletkezett!");
            System.err.println(ex.getMessage());
        }
    }
    
}
