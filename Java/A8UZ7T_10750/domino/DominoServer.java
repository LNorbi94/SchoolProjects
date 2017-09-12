package domino;

import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

import util.Client;
import util.Domino;

public class DominoServer implements Runnable {
	
    private static final String DRAW_MSG = "DONTETLEN";
	public static final int PORT = 60504;
    public static final int DOMINO_NUMBERS = 7;
    
    public static final String DONT_HAVE_MSG = "NINCS";
	public static final String START_MSG = "START";
	public static final String END_MSG = "VEGE";
	public static final String NEW_MSG = "UJ";
	public static final String WIN_MSG = "NYERTEM";
    
    private int couldntPlay;
	private final List<Client> clients;
	private final List<Domino> talon;
	
	private int numOfGames;
	private final String fileToWrite;
	private final String dominoFile;
	
	public DominoServer(final int numOfGames, final String dominoFile
			, final String fileToWrite) {
		clients = new ArrayList<>();
		talon = new ArrayList<>();
		couldntPlay = 0;

		if (2 > numOfGames || 4 < numOfGames) {
			System.out.println("Nem megfelelo a jatekosok szama.");
			this.numOfGames = 2;
		} else {
			this.numOfGames = numOfGames;
		}
		
		this.dominoFile = dominoFile;
		this.fileToWrite = fileToWrite;
	}
    
    public static int getPreviousPlayer(final int who, final int playerNum) {
    	return who - 1 >= 0 ? who - 1 : playerNum - 1;
    }

	private void writeMessage(PrintWriter file, String message, int prevNum) {
		file.println(clients.get(prevNum).name + ": " + message);
	}
    
	private void setupKit(ServerSocket server, Scanner dominos) throws IOException {
		String domino;
		for (int i = 0; i < numOfGames; ++i) {
			Client client = new Client(server.accept());
			clients.add(client);
			for (int j = 0; j < DOMINO_NUMBERS; ++j) {
				domino = dominos.nextLine();
				client.write(domino);
			}
		}
		
		while (dominos.hasNextLine()) {
			domino = dominos.nextLine();
			talon.add(new Domino(domino));
		}
		
		for (Client client : clients) {
			client.name = client.read();
		}
	}

	private static boolean addDomino(final List<Client> clients, final List<Domino> talon
			, final int prevNum) {
		Client previousClient = clients.get(prevNum);
		boolean anyDominoLeft = 0 < talon.size();
		if (anyDominoLeft) {
			previousClient.write(talon.get(0).toString());
			talon.remove(0);
		} else {
			previousClient.write(DONT_HAVE_MSG);
		}
		return anyDominoLeft;
	}
	
	@Override
	public void run() {
		try (ServerSocket server = new ServerSocket(PORT);
                Scanner dominos = new Scanner(new InputStreamReader(
                        new FileInputStream(dominoFile), "utf-8"));
				PrintWriter file = new PrintWriter(new OutputStreamWriter(
		                new FileOutputStream(fileToWrite), "utf-8"))) {
			
			setupKit(server, dominos);

			clients.get(0).write(START_MSG);
			
			String message = clients.get(0).read();
			String lastMessage = message;
			String winner = null;
			
			boolean exit = false;
			int i = 1;
			int prevNum = -1;
			
			while (!exit && couldntPlay != numOfGames) {
				for (; i < numOfGames && !exit; ++i) {
					prevNum = getPreviousPlayer(i, numOfGames);
					if (NEW_MSG.equals(message)) {
						boolean couldadd = addDomino(clients, talon, prevNum);
						if (!couldadd) {
							exit = couldntPlay == numOfGames;
							++couldntPlay;
						}
						if (!exit)
							clients.get(i).write(lastMessage);
					} else if (WIN_MSG.equals(message)) {
						winner = clients.get(prevNum).name;
						writeMessage(file, message, prevNum);
						exit = true;
					} else {
						clients.get(i).write(message);
						lastMessage = message;
					}
					if (!exit) {
						writeMessage(file, message, prevNum);
						message = clients.get(i).read();
						if (!NEW_MSG.equals(message)) {
							couldntPlay = 0;
						}
					}
				}
				i = 0;
			}

			for (Client client : clients) {
				if (!client.name.equals(winner)) {
					client.write(END_MSG);
				}
				client.freeResources();
			}
			if (null == winner) {
				System.out.println(DRAW_MSG);
				file.println(DRAW_MSG);
			}
		} catch (IOException e) {
			System.out.println(e.getMessage());
		}
		
	}
	
	public static void main(String[] args) {
		new DominoServer(Integer.parseInt(args[0]), args[1], args[2]).run();
	}

}
