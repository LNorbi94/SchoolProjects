package gui;

import controllers.*;
import entities.Computer;
import javax.swing.Box;
import javax.swing.JButton;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class ComputerWindow extends Window {
    
    public ComputerWindow(CustomerController oCustContr
                         , ComputerController oCompContr) {
        super("Számítógépek kezelése");
        if (oCustContr != null)
            this.custContr = oCustContr;
        if (oCompContr != null)
            this.compContr = oCompContr;
        computerMenu.setEnabled(false);
        for (String col : Computer.fields) {
            mod.addColumn(col);
        }
        Object[] next;
        while ((next = compContr.nextData()) != null) {
            mod.addRow(next);
        }
        JButton button = new JButton("Új számítógép hozzáadása");
        button.addActionListener((ActionEvent) -> { addComputer(); });
        panel.add(button);
        button = new JButton("Számítógép szerkesztése");
        button.addActionListener((ActionEvent) -> { editComputer(); });
        panel.add(button);
        button = new JButton("Számítógép törlése");
        button.addActionListener((ActionEvent) -> { removeComputer(); });
        panel.add(button);
        setVisible(true);
    }
    
    private void addComputer() {
        JTextField desc = new JTextField(10);
        JTextField os = new JTextField(10);
        JPanel myPanel = new JPanel();
        myPanel.add(new JLabel("Leírás:"));
        myPanel.add(desc);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Operációs Rendszer:"));
        myPanel.add(os);
        
        int result = JOptionPane.showConfirmDialog(null, myPanel, 
                "Új számítógép felvétele:", JOptionPane.OK_CANCEL_OPTION);
        
        String descS = desc.getText();
        String osS = os.getText();
        if (result == JOptionPane.OK_OPTION
            && !descS.equals("") && !osS.equals("")) {
            compContr.add(descS, osS);
            mod.addRow(compContr.top());
        } else if (result == JOptionPane.OK_OPTION) {
            JOptionPane.showMessageDialog(null, "Valamelyik mezőt nem töltötte ki!");
        }
    }

    private void editComputer() {
        if (table.getSelectedRow() == -1)
            return;
        Integer ind = table.getSelectedRow();
        Integer id = (Integer)table.getValueAt(ind, 0);
        Computer comp = compContr.getComputer(id);
        JTextField desc = new JTextField(10);
        JTextField os = new JTextField(10);
        desc.setText(comp.desc);
        os.setText(comp.os);
        
        JPanel myPanel = new JPanel();
        myPanel.add(new JLabel("Leírás:"));
        myPanel.add(desc);
        myPanel.add(Box.createHorizontalStrut(15));
        myPanel.add(new JLabel("Operációs Rendszer:"));
        myPanel.add(os);
        
        int result = JOptionPane.showConfirmDialog(null, myPanel, 
                 "Számítógép szerkesztése:", JOptionPane.OK_CANCEL_OPTION);
        
        String descS = desc.getText();
        String osS = os.getText();
        if (result == JOptionPane.OK_OPTION
                && !descS.equals("") && !osS.equals("")) {
            compContr.edit(descS, osS, id);
            updateRow(ind, compContr.getComputer(id).getData(id));
        } else if (result == JOptionPane.OK_OPTION) {
            JOptionPane.showMessageDialog(null, "Valamelyik mezőt nem töltötte ki!");
        }
    }

    private void removeComputer() {
        if (table.getSelectedRow() == -1)
            return;
        Integer id = (Integer)table.getValueAt(table.getSelectedRow(), 0);
        if (compContr.getComputer(id).signIn != null) {
            JOptionPane.showMessageDialog(null
                    , "Mielőtt töröl egy számítógépet jelentkeztesse ki a felhasználót!");
        } else {
            mod.removeRow(table.getSelectedRow());
            compContr.remove(id);
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
