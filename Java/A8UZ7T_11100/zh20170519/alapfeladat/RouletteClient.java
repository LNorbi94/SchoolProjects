package zh20170519.alapfeladat;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

public class RouletteClient {
	
	private String name;
	
	RouletteClient(String name, String fileName) {
		this.name = name;
		try {
			Scanner file = new Scanner(new File(fileName));
			Socket s = new Socket("localhost", 6792);
			Scanner in = new Scanner(s.getInputStream());
			PrintWriter out = new PrintWriter(s.getOutputStream());
			
			out.println(name);
			out.flush();
			
			while (file.hasNextLine()) {
				String[] messages = file.nextLine().split(" ");
				int num = Integer.parseInt(messages[0]);
				int times = Integer.parseInt(messages[1]);
				while (!(num == -1 && times == -1)) {
					for (int i = 0; i < times; ++i) {
						out.printf("bet %d\n", num);
						out.flush();
					}
					if (!file.hasNextLine())
						break;
					
					messages = file.nextLine().split(" ");
					num = Integer.parseInt(messages[0]);
					times = Integer.parseInt(messages[1]);
				}
				out.println("finish");
				out.flush();
				
				String message = in.nextLine();
				int money = Integer.parseInt(message);
				if (money < 0) {
					money *= -1;
					System.out.printf("%s> I lost %d\n", name, money);
				} else {
					System.out.printf("%s> I won %d\n", name, money);
				}
			}
			
			out.println("out");
			out.flush();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (UnknownHostException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	public static void main(String[] args) {
		new RouletteClient(args[0], args[1]);
	}

}
