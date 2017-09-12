package domino;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;
import static domino.DominoServer.*;

import util.Domino;

public class DominoClient implements Runnable {
    
	private final String name;
	private final String outputname;
    public final static String HOST = "localhost";
    
    private final List<Domino> dominos;
    private PrintWriter outputFile;
    
    public DominoClient(String name) {
        this.name = name;
        dominos = new ArrayList<>();
        outputname = name;
    }
    
    public String getName() {
        return name;
    }
    
    public void writeMessages(final String first, final String second) throws IOException {
        StringBuilder sb = new StringBuilder();
        sb.append(name);
        sb.append(": ");
        sb.append(first);
        sb.append(" ");
        sb.append(second);
        System.out.println(sb.toString());
        outputFile.println(sb.toString());
        outputFile.flush();
    }
    
    @Override
    public void run() {
    	try (	Socket client = new Socket(HOST, DominoServer.PORT);
                PrintWriter pw = new PrintWriter(client.getOutputStream());
                Scanner sc = new Scanner(client.getInputStream()) ) {
    		outputFile = new PrintWriter(new OutputStreamWriter(
	                new FileOutputStream(outputname + ".txt"), "utf-8"));
            
            String message = null;
            
            for (int i = 0; i < DOMINO_NUMBERS; i++) {
                Domino domino = new Domino(sc.nextLine());
                dominos.add(domino);
            }
            
            pw.println(name);
            pw.flush();
            
            boolean exit = false;
            
            while (!exit)
            {
                message = sc.nextLine();
	            if (START_MSG.equals(message)) {
	                int first = dominos.get(0).getFirst();
	                pw.println(first);
	                pw.flush();
	                writeMessages(Integer.toString(first), message);
	                dominos.remove(0);
	            } else {
	                if (!END_MSG.equals(message) && 0 != dominos.size()) {
	                    int receivedDomino = Integer.parseInt(message);
	                    int toFit = -1;
	                    Domino toRemove = null;
	                    for (Domino d : dominos) {
	                    	if (-1 == toFit) {
	                    		toFit = d.fits(receivedDomino);
	                    		if (-1 != toFit) {
	                    			toRemove = d;
	                    		}
	                    	}
	                    }
	                    if (-1 != toFit) {
	                        pw.println(toFit);
		                    pw.flush();
	                        writeMessages(Integer.toString(toFit), message);
	                        dominos.remove(toRemove);
	                    } else {
	                        pw.println(NEW_MSG);
		                    pw.flush();
	                        writeMessages(NEW_MSG, message);
		                    message = sc.nextLine();
		                    exit = END_MSG.equals(message);
		                    if (!exit && !DONT_HAVE_MSG.equals(message)) {
		                        Domino domino = new Domino(message);
		                        dominos.add(domino);
		                    }
	                    }
	                } else if (0 == dominos.size()) {
	                    pw.println(WIN_MSG);
	                    pw.flush();
	                    writeMessages(WIN_MSG, message);
	                    exit = true;
	                }
	            }
	            if (!exit)
	            	exit = END_MSG.equals(message);
            }
        } catch (IOException e) {
            System.out.println(e.getMessage());
            if (null != outputFile) {
            	outputFile.close();
            }
        }
    }
    
    public static void main(String[] args) {
        new DominoClient(args[0]).run();
    }
    
}
