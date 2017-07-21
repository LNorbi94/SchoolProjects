package gui;

import controllers.*;
import entities.Costumer;
import java.io.BufferedWriter;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.io.Writer;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import javax.swing.*;

public class CostumerWindow extends Window {
    
    public CostumerWindow(CustomerController oCustContr
            , ComputerController oCompContr) {
        super("Felhasználók kezelése");
        if (oCustContr != null)
            this.custContr = oCustContr;
        if (oCompContr != null)
            this.compContr = oCompContr;
        costumerMenu.setEnabled(false);
        for (String col : Costumer.fields) {
            mod.addColumn(col);
        }
        Object[] next;
        while ((next = custContr.nextData()) != null) {
            mod.addRow(next);
        }
        JButton button = new JButton("Új felhasználó hozzáadása");
        button.addActionListener((ActionEvent) -> { addUser(); });
        panel.add(button);
        button = new JButton("Felhasználó szerkesztése");
        button.addActionListener((ActionEvent) -> { editUser(); });
        panel.add(button);
        button = new JButton("Felhasználó törlése");
        button.addActionListener((ActionEvent) -> { deleteUser(); });
        panel.add(button);
        button = new JButton("Be-illetve kiléptetés");
        button.addActionListener((ActionEvent) -> { signUser(); });
        panel.add(button);
        setVisible(true);
    }
    
    private void signUser() {
        if (table.getSelectedRow() == -1)
            return;
        Integer ind = table.getSelectedRow();
        Integer id = (Integer)table.getValueAt(ind, 0);
        Costumer user = custContr.getUser(id);
        if (user.compID == null) {
            ArrayList<String> compIds = new ArrayList<>();
            Object[] next;
            while ((next = compContr.nextData()) != null) {
                if (next[3] == "(null)")
                    compIds.add(next[0].toString());
            }
            JComboBox compList = new JComboBox(compIds.toArray());
            if (compList.getItemCount() == 0) {
                JOptionPane.showMessageDialog(null, "Nincs szabad számítógép!");
            } else {
                JPanel myPanel = new JPanel();
                myPanel.add(new JLabel("Szabad számítógépek:"));
                myPanel.add(compList);
                int result = JOptionPane.showConfirmDialog(null, myPanel, 
                     "Felhasználó beléptetése:", JOptionPane.OK_CANCEL_OPTION);

                int compID = Integer.parseInt((String)compList.getItemAt(compList.getSelectedIndex()));
                if (result == JOptionPane.OK_OPTION) {
                    custContr.sign(id, compID);
                    compContr.sign(compID);
                    updateRow(ind, user.getData(id));
                }
            }
        } else {
            JTextField balance = new JTextField(10);
            JTextField toPay = new JTextField(10);
            JTextField addBalance = new JTextField(10);
            Integer compID = user.compID;
            
            Integer bal = user.balance;
            Integer pay = compContr.calcPrice(compID, user);
            
            balance.setText(bal.toString());
            balance.setEditable(false);
            toPay.setEditable(false);
            toPay.setText(pay.toString());
            
            JPanel myPanel = new JPanel();
            myPanel.add(new JLabel("Egyenleg:"));
            myPanel.add(balance);
            myPanel.add(Box.createHorizontalStrut(15));
            myPanel.add(new JLabel("Fizetendő:"));
            myPanel.add(toPay);
            myPanel.add(Box.createHorizontalStrut(15));
            myPanel.add(new JLabel("Egyenleg hozzáadása:"));
            myPanel.add(addBalance);
            
            int result = JOptionPane.showConfirmDialog(null, myPanel, 
                 "Felhasználó kiléptetése:", JOptionPane.OK_CANCEL_OPTION);
            
            String add = addBalance.getText();
            int addB = 0;
            if (!add.equals(""))
                addB = Integer.parseInt(add);
            
            if (result == JOptionPane.OK_OPTION && bal + addB >= pay) {
                user.balance = bal + addB - pay;
                custContr.sign(id, compID);
                compContr.sign(compID);
                updateRow(ind, user.getData(id));
                DateFormat dateFormat = new SimpleDateFormat("yyyy_MM_dd_HH_mm_ss");
                Date date = new Date();
                
                try (BufferedWriter writer = new BufferedWriter(new OutputStreamWriter(
                    new FileOutputStream(user.idCard + "_szamla_" + dateFormat.format(date) + ".txt"), "utf-8"))) {
                    dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
                    writer.write("A Király Netkávézó Cég által kiállított számla. [" + dateFormat.format(date) + "]");
                    writer.newLine();
                    writer.write("=================================================================================== \n");
                    writer.newLine();
                    writer.write("Egyenlege a fizetés előtt: " + bal + "Ft");
                    writer.newLine();
                    writer.write("Egyenlege a fizetés után: " + user.balance + "Ft");
                    writer.newLine();
                    writer.write("Összesen fizetett: " + addB + "Ft");
                    writer.newLine();
                    writer.write("Szolgáltatás költsége: " + pay + "Ft");
                    writer.newLine();
                    JOptionPane.showMessageDialog(null, "A számla kiállítása sikeres! Kérem küldje el e-mailben az ügyfélnek és őrizze meg!");
                } catch(Exception e) {
                    JOptionPane.showMessageDialog(null, "A számla kiállítása sikertelen!");
                }
            } else if (result == JOptionPane.OK_OPTION) {
                JOptionPane.showMessageDialog(null, "Nem töltött fel elég pénzt az egyenleghez! A kiléptetés sikertelen!");
            }
        }
    }
    
    private void addUser() {
        JTextField pword = new JTextField(10);
        JTextField loc = new JTextField(10);
        JTextField idCard = new JTextField(10);
        JPanel myPanel = new JPanel();
        myPanel.add(new JLabel("Jelszó:"));
        myPanel.add(pword);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Cím:"));
        myPanel.add(loc);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Személyi Igazolvány Szám:"));
        myPanel.add(idCard);
        
        int result = JOptionPane.showConfirmDialog(null, myPanel, 
                 "Új felhasználó felvétele:", JOptionPane.OK_CANCEL_OPTION);
        
        String pw = pword.getText();
        String location = loc.getText();
        String idC = idCard.getText();
        if (result == JOptionPane.OK_OPTION
            && !pw.equals("") && !location.equals("") && !idC.equals("")) {
            custContr.add(pw, location, idC);
            mod.addRow(custContr.top());
        } else if (result == JOptionPane.OK_OPTION) {
            JOptionPane.showMessageDialog(null, "Valamelyik mezőt nem töltötte ki!");    
        }
    }
    
    private void editUser() {
        if (table.getSelectedRow() == -1)
            return;
        Integer ind = table.getSelectedRow();
        Integer id = (Integer)table.getValueAt(ind, 0);
        Costumer user = custContr.getUser(id);
        JTextField pword = new JTextField(10);
        JTextField loc = new JTextField(10);
        JTextField idCard = new JTextField(10);
        pword.setText(user.password);
        loc.setText(user.location);
        idCard.setText(user.idCard);
        
        JPanel myPanel = new JPanel();
        myPanel.add(new JLabel("Jelszó:"));
        myPanel.add(pword);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Cím:"));
        myPanel.add(loc);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Személyi Igazolvány Szám:"));
        myPanel.add(idCard);
        
        int result = JOptionPane.showConfirmDialog(null, myPanel, 
                 "Felhasználó szerkesztése:", JOptionPane.OK_CANCEL_OPTION);
        
        String pw = pword.getText();
        String location = loc.getText();
        String idC = idCard.getText();
        if (result == JOptionPane.OK_OPTION
            && !pw.equals("") && !location.equals("") && !idC.equals("")) {
            custContr.edit(pw, location, idC, id);
            updateRow(ind, custContr.getUser(id).getData(id));
        } else if (result == JOptionPane.OK_OPTION) {
            JOptionPane.showMessageDialog(null, "Valamelyik mezőt nem töltötte ki!");
        }
    }
    
    private void deleteUser() {
        if (table.getSelectedRow() == -1)
            return;
        Integer id = (Integer)table.getValueAt(table.getSelectedRow(), 0);
        Integer cID = custContr.getUser(id).compID;
        if (cID == null) {
            mod.removeRow(table.getSelectedRow());
            custContr.remove(id);
        }
        else {
            JOptionPane.showMessageDialog(null
                    , "Mielőtt töröl egy felhasználót jelentkeztesse ki!");
        }
    }
    
    private void updateRow(int rNum, Object[] datas) {
        int i = 0;
        for (Object data : datas) {
            mod.setValueAt(data, rNum, i);
            i++;
        }
    }
    
}
