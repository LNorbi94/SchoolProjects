package domino.server;

import java.rmi.AlreadyBoundException;
import java.rmi.RemoteException;
import java.rmi.registry.Registry;

public class DominoDeploy {

	public static void deploy(Registry reg, String rmiName, String databaseName) throws RemoteException, AlreadyBoundException {
		DominoStorageImpl dStorage = new DominoStorageImpl(databaseName);
		reg.bind(rmiName, dStorage);
	}
}
