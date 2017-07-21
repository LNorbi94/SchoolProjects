package gui;

import controllers.*;
import java.awt.*;
import java.awt.event.*;
import javax.swing.*;
import javax.swing.table.DefaultTableModel;

public class Window extends JFrame {
    
    protected JMenuItem costumerMenu;
    protected JMenuItem computerMenu;
    protected JTable table;
    protected DefaultTableModel mod;
    protected JPanel panel;
    protected CustomerController custContr;
    protected ComputerController compContr;
    
    public Window() {
        if(custContr == null)
            custContr = new CustomerController();
        if(compContr == null)
            compContr = new ComputerController();
        custContr.setup();
        compContr.setup();
        setDefaultCloseOperation(DO_NOTHING_ON_CLOSE);
        addWindowListener( new WindowAdapter() {
            @Override
            public void windowClosing(WindowEvent ev) { exit(); }
	});
        setTitle("Internet Kávézó");
        setBounds(100, 100, 800, 600);
        getContentPane().setLayout( new GridLayout(2, 1, 0, 0) );
        mod = new DefaultTableModel(null, new String[] {}) {
            @Override
            public boolean isCellEditable(int rowIndex, int columnIndex) {
                return false;
            } };
        table = new JTable(mod);
        table.setAutoResizeMode(JTable.AUTO_RESIZE_ALL_COLUMNS);
        panel = new JPanel();
        panel.setLayout( new GridLayout(1, 3, 20, 0) );
        JScrollPane sPane = new JScrollPane(table);
        getContentPane().add(sPane);
        getContentPane().add(panel);
        createMenuBar();
        setVisible(true);
    }
    
    public Window(String title) {
        this();
        setTitle("Internet Kávézó"  + " - " + title);
    }
    
    private void createMenuBar() {
        JMenuBar menubar = new JMenuBar();
        
        JMenu file = new JMenu("Fájl");
        file.setMnemonic(KeyEvent.VK_F);
        JMenu help = new JMenu("Súgó");
        help.setMnemonic(KeyEvent.VK_S);
        costumerMenu = new JMenuItem("Felhasználók kezelése");
        costumerMenu.setMnemonic(KeyEvent.VK_F);
        costumerMenu.setToolTipText("Felhasználók beléptetése, illetve menedzselése.");
        costumerMenu.addActionListener( (ActionEvent event) -> { new CostumerWindow(custContr, compContr); dispose(); } );
        computerMenu = new JMenuItem("Számítógépek kezelése");
        computerMenu.setMnemonic(KeyEvent.VK_F);
        computerMenu.setToolTipText("Számítógépek szerkesztése, illetve új felvétele.");
        computerMenu.addActionListener( (ActionEvent event) -> { new ComputerWindow(custContr, compContr); dispose(); } );
        JMenuItem exit = new JMenuItem("Kilépés");
        exit.setMnemonic(KeyEvent.VK_K);
        exit.setToolTipText("Kilépés a játékból.");
        exit.addActionListener( (ActionEvent) -> { exit(); } );
		
        JMenuItem aboutMe = new JMenuItem("Névjegy");
        aboutMe.setMnemonic(KeyEvent.VK_N);
        aboutMe.setToolTipText("Készítő adatai.");
        aboutMe.addActionListener( (ActionEvent) -> { showInfo(); } );
        file.add(costumerMenu);
        file.add(computerMenu);
        file.add(exit);
        help.add(aboutMe);
        menubar.add(file);
        menubar.add(Box.createHorizontalGlue());
        menubar.add(help);
        setJMenuBar(menubar);
    }
    
    private void showInfo() {
        JOptionPane.showMessageDialog(null
                , "Név: \n Lestár Norbert \n Neptun-kód: \n A8UZ7T \n E-mail cím: \n lestar.norbert@gmail.com"
                , "Készítette:"
                , JOptionPane.PLAIN_MESSAGE);
    }
    
    private void exit() {
        custContr.refresh();
        compContr.refresh();
        System.exit(0);
    }
    
}
