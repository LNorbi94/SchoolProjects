package util;

import java.io.IOException;
import java.io.PrintWriter;
import java.net.Socket;
import java.util.Scanner;

public class Client {
	
	public PrintWriter output;
	public Scanner input;
	public String name;
	
	public Client (Socket s) throws IOException {
		output = new PrintWriter(s.getOutputStream());
		input = new Scanner(s.getInputStream());
	}
	
	public void write (String toWrite) {
		output.println(toWrite);
		output.flush();
	}
	
	public String read () {
		String readLine;
		if (input.hasNextLine()) {
			readLine = input.nextLine();
		} else {
			readLine = "";
		}
		return readLine;
	}
	
	public void freeResources() {
		output.close();
		input.close();
	}

}
