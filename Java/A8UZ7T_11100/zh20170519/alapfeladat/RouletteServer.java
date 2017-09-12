package zh20170519.alapfeladat;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

public class RouletteServer {
	
	private class Bet {
		
		public Bet(String name) {
			this.name = name;
			numbers = new ArrayList<>();
			times = new ArrayList<>();
		}
		
		void increase(Integer number) {
			if (numbers.contains(number)) {
				int index = numbers.indexOf(number);
				int num = times.get(index);
				++num;
				times.remove(index);
				times.add(index, num);
			} else {
				numbers.add(number);
				times.add(1);
			}
		}
		
		int getMoney(int number) {
			int money = 0;
			for (int i = 0; i < numbers.size(); ++i) {
				if (numbers.get(i) == number) {
					money += (35 * times.get(i));
				} else {
					money -= times.get(i);
				}
			}
			return money;
		}

		List<Integer> numbers;
		List<Integer> times;
		
		String name;
	}
	
	
	public final static int PORT = 6792;
	
	private Random rng;
	
	private List<PrintWriter> out;
	private List<Scanner> in;
	private List<String> names;
	private List<Bet> bets;
	private List<String> namesOut;
	
	public RouletteServer(int numOfPlayers) {
		rng = new Random(123456);
		out = new ArrayList<>();
		in = new ArrayList<>();
		names = new ArrayList<>();
		namesOut = new ArrayList<>();
		bets = new ArrayList<>();
		
		try {
			ServerSocket ss = new ServerSocket(PORT);
			for (int i = 0; i < numOfPlayers; ++i) {
				Socket s = ss.accept();
				out.add(new PrintWriter(s.getOutputStream()));
				in.add(new Scanner(s.getInputStream()));
				
				names.add(in.get(i).nextLine());
			}
			
			while (names.size() != namesOut.size()) {
				for (int i = 0; i < names.size(); ++i) {
					String clientName = names.get(i);
					if (namesOut.contains(clientName))
						continue;
					
					String message = in.get(i).nextLine();
					System.out.printf("Server> %s: %s\n", clientName, message);
					if ("out".equals(message)) {
						namesOut.add(clientName);
						continue;
					}
					else if ("finish".equals(message)) {
						continue;
					}
					else {
						int num = Integer.parseInt(message.split(" ")[1]);
						Bet bet = new Bet(clientName);
						bets.add(bet);
						bet.increase(num);
						
						message = in.get(i).nextLine();
						System.out.printf("Server> %s: %s\n", clientName, message);
						while (!"finish".equals(message)) {
							num = Integer.parseInt(message.split(" ")[1]);
							bet.increase(num);
							message = in.get(i).nextLine();
							System.out.printf("Server> %s: %s\n", clientName, message);
						}
					}
				}
				int randomNum = rng.nextInt(37);
				for (int i = 0; i < names.size(); ++i) {
					String clientName = names.get(i);
					if (namesOut.contains(clientName))
						continue;
					
					Bet b = findBet(names.get(i));
					if (null == b) {
						out.get(i).println(0);
					} else  {
						out.get(i).println(b.getMoney(randomNum));
					}
					out.get(i).flush();
				}
				bets.clear();
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public Bet findBet(String name) {
		for (Bet b : bets) {
			if (b.name.equals(name)) {
				return b;
			}
		}
		return null;
	}
	
	public static void main(String[] args) {
		new RouletteServer(Integer.parseInt(args[0]));
	}

}
