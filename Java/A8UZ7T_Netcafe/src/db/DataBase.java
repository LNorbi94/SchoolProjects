package db;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DataBase {
    
    private final String connectionUrl = "jdbc:derby://localhost:1527/Netcafe";
    private final String userName = "root";
    private final String password = "root";
    
    private DataBase() {
    }
    
    public Connection getConnection() throws SQLException {
        return DriverManager.getConnection(connectionUrl, userName, password);
    }
    
    public static DataBase getInstance() {
        return dbHolder.INSTANCE;
    }
    
    private static class dbHolder {
        private static final DataBase INSTANCE = new DataBase();
    }
    
}
