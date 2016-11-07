package be.pxl.backend.integrationtests;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertNull;
import static org.junit.Assert.assertTrue;

import be.pxl.backend.models.*;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.repositories.UserRepository;
import be.pxl.backend.start.Application;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.annotation.DirtiesContext;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;
import java.util.List;

/**
 * Created by Jonas on 4/11/16.
 */
@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
@DirtiesContext
public class SessionRepositoryTest {

    @Autowired
    private UserRepository userRepository;

    @Autowired
    private SessionRepository sessionRepository;

    public void deleteAll() {
        sessionRepository.deleteAll();
        userRepository.deleteAll();
    }

    @Test
    public void startSession() {
        deleteAll();

        Session session = new Session("Test",  new Date());
        Session savedSession = sessionRepository.save(session);

        assertEquals(session.getName(), savedSession.getName());
        assertEquals(session.getStart(), savedSession.getStart());
        assertNull(savedSession.getEnd());
    }

    @Test
    public void endSession() {
        deleteAll();

        Session session = new Session("Test", new Date(), new Date());
        Session savedSession = sessionRepository.save(session);

        assertEquals(session.getName(), savedSession.getName());
        assertEquals(session.getStart(), savedSession.getStart());
        assertEquals(session.getEnd(), savedSession.getEnd());
    }

    @Test
    public void getAllSessions() {
        deleteAll();

        User user = new User("Jonas");
        user.setPassword("123456");

        User savedUser = userRepository.save(user);

        Session session1 = new Session("Test1", new Date(), new Date());
        Session session2 = new Session("Test2", new Date(), new Date());
        Session startSession = new Session("Test3", new Date());

        startSession.setUser(savedUser);
        session1.setUser(savedUser);
        session2.setUser(savedUser);

        Session s1 = sessionRepository.save(session1);
        Session s2 = sessionRepository.save(session2);
        sessionRepository.save(startSession);

        List<Session> sessions = sessionRepository.getAllSessions(user.getName());
        assertEquals(2, sessions.size());
        assertTrue(sessions.contains(s1));
        assertTrue(sessions.contains(s2));
    }

}
