package domino.server;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;

import domino.DominoStorageIface;

public class DominoStorageImpl	extends UnicastRemoteObject
								implements DominoStorageIface {
	
	private static final long serialVersionUID = 1L;
	private Connection conn;

	DominoStorageImpl(String fileName) throws RemoteException {
		String url = "jdbc:hsqldb:file:" + fileName;

		loadDbDriver("org.hsqldb.jdbc.JDBCDriver");
		
		try {
			this.conn = DriverManager.getConnection(url);
			createTable();
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
	}
	
	public void loadDbDriver(String driverName) {
		try {
			Class.forName(driverName);
		} catch (ClassNotFoundException e) {
			System.out.println(e.getMessage());
		}
	}
	
	public void createTable() throws SQLException {
		Statement stat = conn.createStatement();
		stat.executeUpdate("DROP TABLE IF EXISTS dominos;");
		stat.executeUpdate("CREATE TABLE dominos ( user varchar(80), domino varchar(80), idx int );");
	}
	
	@Override
	public void save(String userName, List<String> dominos) {
		try {
			PreparedStatement prep = conn.prepareStatement("DELETE FROM dominos d WHERE d.user = ?;");
			prep.setString(1, userName);
			prep.addBatch();
			prep = conn.prepareStatement("INSERT INTO dominos VALUES (?, ?, ?);");
			int index = 1;
			for (String domino : dominos) {
				prep.setString(1, userName);
				prep.setString(2, domino);
				prep.setInt(3, index);
				prep.addBatch();
				index++;
			}
			
			conn.setAutoCommit(false);
			prep.executeBatch();
			conn.setAutoCommit(true);
			conn.commit();
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
	}
	
	@Override
	public List<String> load(String userName) {
		List<String> dominoList = new ArrayList<String>();
		try (PreparedStatement prep =
				conn.prepareStatement("SELECT * FROM dominos d WHERE d.user = ?;");) {
			prep.setString(1, userName);
			ResultSet rs = prep.executeQuery();
			while (rs.next()) {
				String domino = rs.getString(2);
				dominoList.add(domino);
			}
		} catch (SQLException e) {
			System.out.println(e.getMessage());
		}
		return dominoList;
	}
	
}
