package controllers;

import db.DataBase;
import entities.*;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.text.DateFormat;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Map;

public class ComputerController {
        
    private final Map<Integer, Computer> container;
    private final ArrayList<Integer> ids;
    private final ArrayList<Integer> toRemove;
    private final ArrayList<Integer> toUpdate;
    private final ArrayList<Integer> toAdd;
    private int next;
    
    public final int BASEPRICE = 1000;
    
    public ComputerController() {
        container = new HashMap<>();
        ids = new ArrayList<>();
        toRemove = new ArrayList<>();
        toUpdate = new ArrayList<>();
        toAdd = new ArrayList<>();
        next = 0;
    }
    
    public void setup() {
        if (container.isEmpty()) {
            String sql = "SELECT * FROM computer";
            try (   Connection connection = DataBase.getInstance().getConnection();
                    Statement stmt = connection.createStatement();
                    ResultSet rs = stmt.executeQuery( sql )) {
                
                while (rs.next()) {
                    Integer id = (int)rs.getObject(1);
                    String desc = rs.getObject(2).toString();
                    String os = rs.getObject(3).toString();
                    String signin = rs.getObject(4) == null ? null : rs.getObject(4).toString();
                    container.put(id, new Computer(desc, os, signin));
                    ids.add(id);
                }
                
            } catch (SQLException e) {
                System.out.println("Beolvasás közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
    }
    
    public void refresh() {
        String sql = "DELETE FROM computer WHERE ID = ?";
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
                Computer comp = container.get(id);
                Statement st = connection.createStatement();
                String signin = ", null";
                if (comp.signIn != null)
                    signin = ", '" + comp.signIn + "'";
                sql = "INSERT INTO computer VALUES (" + id + ", '"
                    + comp.desc + "', '" + comp.os + "'"
                    + signin + ")";
                st.executeUpdate(sql);
            } catch (SQLException e) {
                System.out.println("Beillesztés közben hiba történt!");
                System.out.println(e.getMessage());
            }
        }
        
        for (Integer id : toUpdate) {
            try (Connection connection = DataBase.getInstance().getConnection()) {
                Computer comp = container.get(id);
                Statement st = connection.createStatement();
                String signin = ", SIGNIN = null";
                if (comp.signIn != null)
                    signin = ", SIGNIN ='" + comp.signIn + "'";
                sql = "UPDATE computer SET DESCRIPTION = '" + comp.desc
                    + "', OS = '" + comp.os + "'" + signin
                    + " WHERE ID = " + id;
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
    
    public Computer getComputer(Integer id) {
        return container.get(id);
    }
    
    public Object[] nextData() {
        if (next > ids.size() - 1) {
            next = 0;
            return null;
        }
        Computer nextCostumer = container.get(ids.get(next));
        return nextCostumer.getData(ids.get(next++));
    }
    
    public Object[] top() {
        if (ids.isEmpty())
            return null;
        Integer id = ids.size() - 1;
        return container.get(ids.get(id)).getData(ids.get(id));
    }
    
    public void add(String desc, String os) {
        Integer lastID = -1;
        if (!ids.isEmpty())
            lastID = ids.get(ids.size() - 1);
        ids.add(++lastID);
        toAdd.add(lastID);
        container.put(lastID, new Computer(desc, os, null));
    }
    
    public void remove(Integer id) {
        toRemove.add(id);
        toAdd.remove(id);
        toUpdate.remove(id);
        container.remove(id);
        ids.remove(id);
    }
    
    public void edit(String desc, String os, Integer id) {
        Computer comp = container.get(id);
        comp.desc = desc;
        comp.os = os;
        toUpdate.add(id);
    }
    
    public void sign(Integer cID) {
        Computer comp = container.get(cID);
        if (comp.signIn == null) {
            DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
            Date date = new Date();
            comp.signIn = dateFormat.format(date);
        } else {
            comp.signIn = null;
        }
        toUpdate.add(cID);
    }
    
    public int calcPrice(Integer cID, Costumer user) {
        Calendar calendar = Calendar.getInstance();
        int hour = calendar.get(Calendar.HOUR_OF_DAY);
        int oldH = 0;
        try {
            DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
            Date date = dateFormat.parse(container.get(cID).signIn);
            calendar.setTime(date);
            oldH = calendar.get(Calendar.HOUR_OF_DAY);
        } catch (ParseException e) {
            // Won't happen
        }
        int points = 0;
        int toldH = oldH;
        while (toldH < hour - 1) {
            if ((toldH >= 0 && toldH <= 16) || (toldH >= 21 && toldH <= 24)) {
                points += 2;
            } else {
                points += 1;
            }
            ++toldH;
            if (toldH == 24) {
                toldH = 0;
            }
        }
        user.points += points;
        int discount = 0;
        if (user.points >= 150) {
            discount = user.points / 150;
            if(discount > 10)
                discount = 10;
        }
        int spent = hour - oldH;
        if (spent < 0) {
            spent = hour + (24 - oldH);
        }
        int finalPrice = BASEPRICE * (spent + 1);
        return (int)(finalPrice - finalPrice * (discount / 100.0));
    }
}
