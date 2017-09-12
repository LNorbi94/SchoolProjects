package util;

public class Domino {
    
    private final int first;
    private final int second;
    
    public Domino(String domino) {
        String[] dominos = domino.split(" ");
        first = Integer.parseInt(dominos[0]);
        second = Integer.parseInt(dominos[1]);
    }
    
    public int getFirst() {
        return first;
    }
    
    public int getSecond() {
        return second;
    }
    
    public int fits(final int what) {
    	if (first == what) {
    		return second;
    	} else if (second == what) {
    		return first;
    	}
    	return -1;
    }
    
    @Override
    public String toString() {
    	return first + " " + second;
    }
}
