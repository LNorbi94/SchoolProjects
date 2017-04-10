package hunting.windows;

import hunting.GameLogic;
import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

/**
 * A tényleges játék ablaka.
 * @author Lestár Norbert (A8UZ7T)
 *
 */
public class Game {
	private final JFrame	frame;
	private final int 		size;
	private final GameLogic myGame;
	private JButton[][] 	myButtons;

	public Game(int size) {
		this.size	= size;
		frame		= new JFrame();
		myGame		= new GameLogic(size);
		myButtons	= new JButton[size][size];
		initialize();
	}

	/**
	 *  Inicializálja az ablakot, illetve létrehozza a mezőket, valamint a menüt.
	 *  Kilépés megnyomása esetén nem lép ki rögtön a program, hanem megerősítést vár.
	 */
	private void initialize() {
		updateTitle();
		frame.setBounds(100, 100, 600, 300);
		frame.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		frame.getContentPane().setLayout( new GridLayout(size, size, 0, 0) );
		frame.setVisible(true);
		Base.exit(frame);
		createMenuBar();
		for(int i = 0; i < size; ++i) {
			for(int j = 0; j < size; ++j) {
				myButtons[i][j] = addButton(i, j);
				frame.getContentPane().add( myButtons[i][j] );
			}
		}
		myGame.setButtons(myButtons);
	}
	
	/**
	 *  Frissíti az ablak címsorát, és kiírja a következő játékost, illetve vadász esetén a hátralevő lépések számát.
	 */
	private void updateTitle() {
		String next = myGame.next();
		next = next == GameLogic.HUNTER ? next + ", " + myGame.stepLeft() + " lépése maradt" : next;
		frame.setTitle("Vadászat - Következő játékos: " + next);
	}
	
	/**
	 * Beállítja az ablak felső részén található menüt.
	 */
	private void createMenuBar() {
		JMenuBar menubar = new JMenuBar();

		JMenu file = new JMenu("Fájl");
		file.setMnemonic(KeyEvent.VK_F);
		JMenu help = new JMenu("Súgó");
		help.setMnemonic(KeyEvent.VK_S);
		JMenuItem newGame = new JMenuItem("Új játék");
		newGame.setMnemonic(KeyEvent.VK_U);
		newGame.setToolTipText("Új játék kezdése a méret kiválasztásával.");
		newGame.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent event) { new Base(); frame.dispose(); }
		});
		JMenuItem restartGame = new JMenuItem("Játék újraindítása");
		restartGame.setMnemonic(KeyEvent.VK_J);
		restartGame.setToolTipText("Játék újraindítása a jelenlegi mérettel.");
		restartGame.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent event) { new Game(size); frame.dispose(); }
		});
		JMenuItem exit = new JMenuItem("Kilépés");
		exit.setMnemonic(KeyEvent.VK_K);
		exit.setToolTipText("Kilépés a játékból.");
		exit.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent event) { Base.exit(); }
		});
		
		JMenuItem description = new JMenuItem("Játék leírása");
		description.setMnemonic(KeyEvent.VK_J);
		description.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent event) {
				Base.infoBox("Szabályok: \n"
						+ "Két játékos versenyzik egymással, a támadó és a menekülő. \n"
						+ "A támadó célja bekeríteni a menekülőt 4 * n (ahol n a pálya mérete) lépés alatt."
						+ " Ezen lépések száma az ablak címsorán megjelenik. \n"
						+ "Ha ez nem sikerül, akkor a menekülő nyer. \n"
						+ "További tudnivalók: \n"
						+ "Csak függőlegesen illetve vízszintesen lehet lépni, illetve a másik játékosra nem lehet \"rálépni\". \n"
						+ "A játék kezdetén véletlenszerűen van eldöntve hogy ki kezdd.", "Játék leírása");
			}
		});
		JMenuItem aboutMe = new JMenuItem("Névjegy");
		aboutMe.setMnemonic(KeyEvent.VK_N);
		aboutMe.setToolTipText("Készítő adatai.");
		aboutMe.addActionListener(new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent event) {
				Base.infoBox("Név: \n Lestár Norbert \n Neptun-kód: \n A8UZ7T \n E-mail cím: \n lestar.norbert@gmail.com", "Készítette:");
			}
		});

		file.add(newGame);
		file.add(restartGame);
		file.add(exit);
		help.add(description);
		help.add(aboutMe);
		menubar.add(file);
		menubar.add(Box.createHorizontalGlue());
		menubar.add(help);
		frame.setJMenuBar(menubar);
	}
	
	/**
	 * Létrehoz egy új gombot, majd visszaadja azt.
	 * Ha a létrrehozni kívánt gomb valamely sarokban helyezkedik el, akkor a támadó játékost helyezi el rajta.
	 * Ha közepén, akkor menekülőt.
	 * Továbbá meghív egy metódust ha a felhasználó rákattint a gombra.
	 * @param i - Gomb első indexe
	 * @param j - Gomb második indexe
	 * @return Létrehozott gomb
	 */
	private JButton addButton(final int i, final int j) {
		final JButton button = new JButton();
		
		if(   (i == j && (i == 0 || i == size - 1))
		   || (i == 0 && j == size - 1)
		   || (j == 0 && i == size - 1) ) {
			button.setText(GameLogic.HUNTER);
		}
		if( i == j && i == (size - 1) / 2 )
			button.setText(GameLogic.PREY);

		button.addActionListener( new ActionListener() {
			@Override
			public void actionPerformed(ActionEvent e) { addButtonLogic(i, j, button); }
		});
		
		return button;
	}
	
	/**
	 * A gombok meghívásakor hívodik meg.
	 * Ha nincs egy aktív gomb se, és a megnyomott gombú játékos következik, abban az esetben aktiválja.
	 * Ha már valamely gomb ki volt választva, és ez az a gomb, akkor inaktiválja.
	 * Ellenkező esetben megnézi hogy az aktív gombnak szomszédja-e ez a gomb, és hogy nincs-e rajta másik játékos.
	 * Ha minden adott idelépteti az aktív játékost, és inaktívvá teszi az előzőleg aktív gombot.
	 * @param i - gomb első indexe
	 * @param j - gomb második indexe
	 * @param button - vizsgált gomb
	 */
	private void addButtonLogic(final int i, final int j, JButton button) {
		if( myGame.getSelected() == null && !button.getText().equals("") && button.getText().equals(myGame.next())) {
			button.setBackground( new Color(125, 127, 255) );
			myGame.setSelected( button );
		} else if(myGame.getSelected() != null) {
			JButton selected = myGame.getSelected();
			if(selected == button || ( myGame.isNextTo(i, j, selected) && button.getText().equals("") )) {
				String text = selected.getText();
				selected.setBackground( new JButton().getBackground() );
				myGame.setSelected( null );
				if(selected != button) {
					selected.setText("");
					button.setText(text);
					myGame.setNext();
					updateTitle();
					myGame.incStep(text);
					String winner = myGame.anyWinner();
					if(!winner.equals(GameLogic.NOONE)) {
						endOfGame(winner);
					}
				}
			}
		}
	}
	
	/**
	 * Ha 4 * n lépés alatt nem nyert a támadó, illetve a menekülő be lett kerítve vége lesz a játéknak.
	 * Ekkor lehet új játékot kezdeni más táblán, vagy a jelenlegi beállításokkal, illetve ki lehet lépni.
	 * @param winner - játék nyertese
	 */
	public void endOfGame(String winner) {
		int choice = JOptionPane.showOptionDialog( null
				, winner + " játékos nyert! Mit szeretne most tenni?"
				, "Vége a játéknak!"
				, JOptionPane.YES_NO_OPTION
				, JOptionPane.INFORMATION_MESSAGE
				, null
				, new Object[] {"Új játék", "Játék újraindítása", "Kilépés"}
				, "Új játék" );
		switch(choice) {
			case 0:
				new Base();
				frame.dispose();
				break;
			case 1:
				new Game(size);
				frame.dispose();
				break;
			case 2:
				if( Base.exit() == -1) endOfGame(winner);
				break;
		}
	}
}
