package controllers;

import entities.Costumer;
import java.util.Arrays;
import org.junit.Before;
import org.junit.Test;
import static org.junit.Assert.*;

public class CustomerControllerTest {
    
    protected static CustomerController cosTest;
    
    public CustomerControllerTest() {
    }
    
    @Before
    public void setUp() {
        cosTest = new CustomerController();
        cosTest.add("oprendszerek", "Budapest", "7654A");
    }

    @Test
    public void testGetUser() {
        System.out.println("getUser");
        Integer id = 0;
        Costumer expResult = new Costumer("oprendszerek", "Budapest", "7654A");
        Costumer result = cosTest.getUser(id);
        assertEquals(expResult, result);
    }

    @Test
    public void testNextData() {
        System.out.println("nextData");
        Costumer user = new Costumer("oprendszerek", "Budapest", "7654A");
        Object[] expResult = user.getData(0);
        Object[] result = cosTest.nextData();
        assertArrayEquals(expResult, result);
    }

    @Test
    public void testTop() {
        System.out.println("top");
        cosTest.add("a", "b", "c");
        Costumer user = new Costumer("a", "b", "c");
        Object[] expResult = user.getData(1);
        Object[] result = cosTest.top();
        assertArrayEquals(expResult, result);
    }

    @Test
    public void testAdd() {
        System.out.println("add");
        CustomerController instance = new CustomerController();
        instance.add("1", "2", "3");
    }

    @Test
    public void testRemove() {
        System.out.println("remove");
        cosTest.remove(0);
        Object[] result = cosTest.top();
        assertArrayEquals(null, result);
    }

    @Test
    public void testEdit() {
        System.out.println("edit");
        Costumer user = new Costumer("a", "b", "c");
        user.points = 3;
        cosTest.edit("a", "b", "c", 0);
        assertFalse(Arrays.equals(user.getData(0), cosTest.top()));
    }

    @Test
    public void testSign() {
        System.out.println("sign");
        Integer cID = 0;
        cosTest.sign(cID, 0);
        assertEquals(cID, cosTest.getUser(cID).compID);
        cosTest.sign(cID, 0);
        assertEquals(null, cosTest.getUser(cID).compID);
    }
    
}
