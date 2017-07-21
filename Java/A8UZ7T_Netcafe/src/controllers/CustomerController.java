package controllers;

import db.DataBase;
import entities.Costumer;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class CustomerController {
    
    private final Map<Integer, Costumer> container;
    private final ArrayList<Integer> ids;
    private final ArrayList<Integer> toRemove;
    private final ArrayList<Integer> toUpdate;
    private final ArrayList<Integer> toAdd;
    private int next;
    
    public CustomerController() {
        container = new HashMap<>();
        ids = new ArrayList<>();
        toRemove = new ArrayList<>();
        toUpdate = new ArrayList<>();
        toAdd = new ArrayList<>();
        next = 0;
    }
    
    public void setup() {
        if(container.isEmpty()) {
            String sql = "SELECT * FROM costumer";
            try (   Connection connection = DataBase.getInstance().getConnection();
                    Statement stmt = connection.createStatement();
                    ResultSet rs = stmt.executeQuery( sql )) {
                
                while (rs.next()) {
                    Integer id = (int)rs.getObject(1);
                    String password = rs.getObject(2).toString();
                    String location = rs.getObject(3).toString();
                    String idCard = rs.getObject(4).toString();
                    Integer compID =  rs.getObject(5) == null ? null : (int)rs.getObject(5);
                    Integer balance = rs.getObject(6) == null ? null : (int)rs.getObject(6);
                    Integer points = rs.getObject(7) == null ? null : (int)rs.getObject(7);
                    container.put(id, new Costumer(password, location, idCard, compID, balance, points));
                    ids.add(id);
                }
                
            } catch (SQLException e) {
                System.out.println("Beolvasás közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
    }
    
    public void refresh() {
        String sql = "DELETE FROM costumer WHERE ID = ?";
        for (Integer id : toRemove) {
            try (Connection connection = DataBase.getInstance().getConnection()) {
                PreparedStatement preparedStmt = connection.prepareStatement(sql);
                preparedStmt.setInt(1, id);
                preparedStmt.execute();
            } catch (SQLException e) {
                System.out.println("Törlés közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
        
        for (Integer id : toAdd) {
            try (Connection connection = DataBase.getInstance().getConnection()) {
                Costumer cos = container.get(id);
                Statement st = connection.createStatement();
                sql = "INSERT INTO costumer VALUES (" + id + ", '"
                    + cos.password + "', '" + cos.location + "', '"
                    + cos.idCard + "', " + cos.compID + ", "
                    + cos.balance + ", " + cos.points + ")";
                st.executeUpdate(sql);
            } catch (SQLException e) {
                System.out.println("Beillesztés közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
        
        for (Integer id : toUpdate) {
            try (Connection connection = DataBase.getInstance().getConnection()) {
                Costumer cos = container.get(id);
                Statement st = connection.createStatement();
                sql = "UPDATE costumer SET PASSWORD = '" + cos.password
                    + "', LOCATION = '" + cos.location + "', IDCARD = '" + cos.idCard
                    + "', COMPID = " + cos.compID + ", BALANCE = " + cos.balance + ", POINTS = " + cos.points + " WHERE ID = " + id;
                st.executeUpdate(sql);
            } catch (SQLException e) {
                System.out.println("Beillesztés közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
        
        toRemove.clear();
        toAdd.clear();
        toUpdate.clear();
    }
    
    public Costumer getUser(Integer id) {
        return container.get(id);
    }
    
    public Object[] nextData() {
        if (next > ids.size() - 1) {
            next = 0;
            return null;
        }
        Costumer nextCostumer = container.get(ids.get(next));
        return nextCostumer.getData(ids.get(next++));
    }
    
    public Object[] top() {
        if (ids.isEmpty())
            return null;
        Integer id = ids.size() - 1;
        return container.get(ids.get(id)).getData(ids.get(id));
    }
    
    public void add(String pw, String loc, String idC) {
        Integer lastID = -1;
        if (!ids.isEmpty())
            lastID = ids.get(ids.size() - 1);
        ids.add(++lastID);
        toAdd.add(lastID);
        container.put(lastID, new Costumer(pw, loc, idC));
    }
    
    public void remove(Integer id) {
        toRemove.add(id);
        toAdd.remove(id);
        toUpdate.remove(id);
        container.remove(id);
        ids.remove(id);
    }
    
    public void edit(String pw, String loc, String idC, Integer id) {
        container.get(id).password = pw;
        container.get(id).location = loc;
        container.get(id).idCard = idC;
        toUpdate.add(id);
    }
    
    public void sign(Integer uID, Integer cID) {
        Costumer user = container.get(uID);
        if (user.compID == null) {
            user.compID = cID;
        } else {
            user.compID = null;
        }
        toUpdate.add(uID);
    }
}
