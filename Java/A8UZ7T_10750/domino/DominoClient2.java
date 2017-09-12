package domino;

import static domino.DominoServer.DOMINO_NUMBERS;
import static domino.DominoServer.DONT_HAVE_MSG;
import static domino.DominoServer.END_MSG;
import static domino.DominoServer.NEW_MSG;
import static domino.DominoServer.START_MSG;
import static domino.DominoServer.WIN_MSG;

import java.io.FileOutputStream;
import java.io.IOException;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.Socket;
import java.rmi.NotBoundException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.List;
import java.util.Scanner;

import util.Domino;

public class DominoClient2 extends DominoClient {
	
	private int saveAfterStep;
	private String rmiName;
	private String userName;
	
	DominoClient2(String fileName, int saveAfterStep, String rmiName, String userName) {
		super(fileName);
		this.saveAfterStep = saveAfterStep;
		this.rmiName = rmiName;
		this.userName = userName;
	}

    @Override
    public void run() {
    	try (	Socket client = new Socket(HOST, DominoServer.PORT);
                PrintWriter pw = new PrintWriter(client.getOutputStream());
                Scanner sc = new Scanner(client.getInputStream()) ) {
    		outputFile = new PrintWriter(new OutputStreamWriter(
	                new FileOutputStream(outputname + ".txt"), "utf-8"));
            
            String message = null;
            
            Registry reg = LocateRegistry.getRegistry();
            DominoStorageIface dStorage = (DominoStorageIface) reg.lookup(rmiName);

            List<String> tempDominos = dStorage.load(userName);
            
            for (String d : tempDominos) {
            	Domino domino = new Domino(d);
            	dominos.add(domino);
            }
            
            for (int i = 0; i < DOMINO_NUMBERS; i++) {
                Domino domino = new Domino(sc.nextLine());
                if (dominos.size() < 7)
                	dominos.add(domino);
            }
            
            pw.println(name);
            pw.flush();
            
            boolean exit = false;
            int numberOfStep = 0;
            
            while (!exit)
            {
                message = sc.nextLine();
            	++numberOfStep;
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
	                    		if (-1 != toFit)
	                    			toRemove = d;
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
	            	if (saveAfterStep == numberOfStep) {
	            		tempDominos.clear();
	            		for (Domino d : dominos) {
	            			tempDominos.add(d.toString());
	            		}
	            		dStorage.save(userName, tempDominos);
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
        } catch (NotBoundException e) {
            System.out.println(e.getMessage());
        }
    }
    
    public static void main(String[] args) {
    	try {
	    	if (args.length == 1)
	    		new DominoClient(args[0]).run();
	    	else if (args.length == 4)
	    		new DominoClient2(args[0], Integer.parseInt(args[1]), args[2], args[3]).run();
    	} catch (NumberFormatException e) {
            System.out.println(e.getMessage());
    	}
    }
    
}
