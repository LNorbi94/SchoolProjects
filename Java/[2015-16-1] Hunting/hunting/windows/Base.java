package hunting.windows;

import javax.swing.*;
import java.awt.FlowLayout;
import java.awt.event.*;

/**
 * Kezdeti ablak, itt lehet új játékot kezdeni.
 * @author Lestár Norbert (A8UZ7T)
 *
 */
public class Base {
	private final JFrame frame;

	public Base() {
		frame = new JFrame();
		initialize();
	}

	/**
	 *  Inicializálja az ablakot, illetve létrehoz gombokat a játék kezdéséhez.
	 *  A gombok külön metódusban jönnek létre, így később könnyebb új méretet megadni ha szükséges.
	 *  Kilépés megnyomása esetén nem lép ki rögtön a program, hanem megerősítést vár.
	 */
	private void initialize() {
		frame.setTitle("Vadászat");
		frame.setBounds(100, 100, 310, 80);
		frame.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
		frame.getContentPane().setLayout( new FlowLayout(FlowLayout.CENTER, 10, 8) );
		frame.setVisible(true);
		createButton(3);
		createButton(5);
		createButton(7);
		exit(frame);
	}
	
	/**
	 * Létrehozza a gombokat az új játék kezdéséhez a megadott méretben.
	 * @param size - mezők mérete
	 */
	private void createButton(final int size) {
		JButton button = new JButton(size + "x" + size);
		button.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) { openGame(size); }
		});
		frame.getContentPane().add(button);
	}
	
	/**
	 * Létrehoz egy új ablakban a megadott mérettel egy játékot, majd törli a jelenlegi ablakot.
	 * @param size - mezők mérete
	 */
	private void openGame(final int size) {
		new Game(size);
		frame.dispose();
	}
	
	/**
	 * Megkérdezi a felhasználót hogy valóban ki akar-e lépni.
	 * Visszatérési érték szükséges ha valahol tudni szeretnénk hogy nem lépett ki a felhasználó
	 * (Például játék végénél)
	 * @return -1 abban az esetben, ha a felhasználó nem lép ki
	 */
	public static int exit() {
		int choice = JOptionPane.showOptionDialog( null
				, "Biztosan ki szeretne lépni?"
				, "Kilépés megerősítése"
				, JOptionPane.YES_NO_OPTION
				, JOptionPane.QUESTION_MESSAGE
				, null
				, new Object[] {"Igen", "Nem"}
				, "Nem" );
		if(choice == 0)
			System.exit(0);
		return -1;
	}
	
	/**
	 * Kilépés, abban az esetben hasznos ha ezt más osztályban is szeretnénk használni.
	 * @param frame - adott osztályban lévő keret
	 */
	public static void exit(JFrame frame) {
		frame.addWindowListener( new WindowAdapter() {
			public void windowClosing(WindowEvent ev) { exit(); }
		});
	}
	
	/**
	 * Egyszerű messageBox, információk megjelenítésére.
	 * @param infoMessage	- ablakban kiírt szöveg
	 * @param titleBar 		- ablak címsorában megjelenő szöveg
	 */
	public static void infoBox(String infoMessage, String titleBar)
	{
		JOptionPane.showMessageDialog(null, infoMessage, titleBar, JOptionPane.PLAIN_MESSAGE);
	}
}
