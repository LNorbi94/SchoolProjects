package hunting;

import javax.swing.JButton;

public class GameLogic {
	public static String HUNTER = "Támadó";
	public static String PREY 	= "Menekülő";
	public static String NOONE	= "-";
	
	private final int	size;
	private String 		nextPlayer;
	private JButton		selected;
	private int			stepCount;
	private JButton[][] myButtons;
	
	/**
	 * Konstruktor véletlenszerűen beállítja melyik játékos kezdd.
	 * @param size - pálya mérete
	 */
	public GameLogic(int size) {
		this.size = size;
		nextPlayer = (int)(Math.random() * 2) + 1 == 1 ? HUNTER : PREY;
		myButtons = new JButton[size][size];
	}

	/**
	 * (Majdnem) triviális getterek az adattagok elérése.
	 * @return elérni kívánt adattag
	 */
	public String	next() 			{ return nextPlayer; }
	public JButton	getSelected()	{ return selected; }
	public int		stepLeft()		{ return size * 4 - stepCount; }

	/**
	 * Setterek az adattagokhoz.
	 */
	public void setNext()						{ nextPlayer = nextPlayer.equals(HUNTER) ? PREY : HUNTER; }
	public void setSelected(JButton selected)	{ this.selected = selected; }
	public void incStep(String player)			{ if(player.equals(HUNTER)) ++stepCount; }
	public void setButtons(JButton[][] buttons) { myButtons = buttons; }
	
	/**
	 * Megadja melyik játékos nyert (ha van ilyen).
	 * Ha a maximális lépésszámot átlépte a támadó, akkor a menekülő.
	 * Ha nem tud hova lépni a menekülő, akkor a vadász.
	 * @return nyertes (vagy annak hiánya)
	 */
	public String anyWinner() {
		if(stepCount >= size * 4)
			return PREY;
		if( cantEscape() )
			return HUNTER;
		return NOONE;
	}
	
	/**
	 * Megkeresi a menekülő pozicíóját, majd megadja hogy tud lépni vagy sem.
	 * @return igaz, ha a menekülő be lett kerítve
	 */
	public boolean cantEscape() {
		int i = 0;
		int j = 0;
		for(int k = 0; k < size; ++k) {
			for(int l = 0; l < size; ++l) {
				if( myButtons[k][l].getText().equals(GameLogic.PREY) ) {
					i = k;
					j = l;
				}
			}
		}
		boolean ret = true;
		if( validIndex(i-1) )
			ret = ret && myButtons[i-1][j].getText().equals(GameLogic.HUNTER);
		if( validIndex(j-1) )
			ret = ret && myButtons[i][j-1].getText().equals(GameLogic.HUNTER);
		if( validIndex(i+1) )
			ret = ret && myButtons[i+1][j].getText().equals(GameLogic.HUNTER);
		if( validIndex(j+1) )
			ret = ret && myButtons[i][j+1].getText().equals(GameLogic.HUNTER);
		return ret;
	}
	
	/*
	 * Megadja hogy van-e ilyen indexű mező vagy sem
	 * @return igaz, ha van ilyen.
	 */
	private boolean validIndex(final int i) { return 0 <= i && i < size; }
	
	/*
	 * Megadja, hogy a megadott indexnél lévő gomb hogy helyezkedik el a megadott gombhoz.
	 * @return Ha felette/alatta avagy mellette van, igazat ad vissza.
	 */
	public boolean isNextTo(final int i, final int j, JButton button) {
		for(int k = 0; k < size; ++k) {
			for(int l = 0; l < size; ++l) {
				if(myButtons[k][l] == button)
					return k - i < 2 && l - j < 2 && (k - i == 0 || l - j == 0);
			}
		}
		return false;
	}
}
