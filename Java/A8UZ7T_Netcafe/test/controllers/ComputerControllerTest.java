package controllers;

import entities.Computer;
import entities.Costumer;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Date;
import org.junit.Test;
import static org.junit.Assert.*;
import org.junit.Before;

public class ComputerControllerTest {
    
    protected static ComputerController compTest;
    
    public ComputerControllerTest() {
    }
    
    @Before
    public void setUp() {
        compTest = new ComputerController();
        compTest.add("Alienware 15", "openSUSE");
    }

    @Test
    public void testGetComputer() {
        System.out.println("getComputer");
        Integer id = 0;
        Computer expResult = new Computer();
        Computer result = compTest.getComputer(id);
        assertEquals(expResult, result);
    }

    @Test
    public void testNextData() {
        System.out.println("nextData");
        Computer comp = new Computer("Alienware 15", "openSUSE", null);
        Object[] expResult = comp.getData(0);
        Object[] result = compTest.nextData();
        assertArrayEquals(expResult, result);
    }

    @Test
    public void testTop() {
        System.out.println("top");
        compTest.add("a", "b");
        Computer comp = new Computer("a", "b", null);
        Object[] expResult = comp.getData(1);
        Object[] result = compTest.top();
        assertArrayEquals(expResult, result);
    }

    @Test
    public void testAdd() {
        System.out.println("add");
        String desc = "";
        String os = "";
        ComputerController instance = new ComputerController();
        instance.add(desc, os);
    }

    @Test
    public void testRemove() {
        System.out.println("remove");
        compTest.remove(0);
        Object[] result = compTest.top();
        assertArrayEquals(null, result);
    }

    @Test
    public void testEdit() {
        System.out.println("edit");
        String desc = "n";
        String os = "a";
        Integer id = 0;
        Computer comp = new Computer(desc, os, null);
        comp.signIn = "a";
        compTest.edit(desc, os, id);
        assertFalse(Arrays.equals(comp.getData(0), compTest.top()));
    }

    @Test
    public void testSign() {
        System.out.println("sign");
        Integer cID = 0;
        compTest.sign(cID);
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Date date = new Date();
        String signIn = dateFormat.format(date);
        assertEquals(signIn, compTest.getComputer(cID).signIn);
        compTest.sign(cID);
        assertEquals(null, compTest.getComputer(cID).signIn);
    }

    @Test
    public void testCalcPrice() {
        System.out.println("calcPrice");
        Integer cID = 0;
        Costumer user = new Costumer();
        compTest.sign(cID);
        DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
        Calendar calendar = Calendar.getInstance();
        calendar.add(Calendar.HOUR_OF_DAY, -10);
        compTest.getComputer(cID).signIn = dateFormat.format(calendar.getTime());
        user.compID = 0;
        user.points = 150;
        int expResult = (int)(compTest.BASEPRICE * 11 - compTest.BASEPRICE * 11 * (1 / 100.0));
        int result = compTest.calcPrice(cID, user);
        assertEquals(expResult, result);
    }
    
}
