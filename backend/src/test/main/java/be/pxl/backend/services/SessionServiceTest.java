package be.pxl.backend.services;

import static org.mockito.Mockito.when;

import be.pxl.backend.exceptions.SessionException;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;

import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class SessionServiceTest {


    @Autowired
    private SessionService sessionService;

    private SessionRepository sessionRepository;

    @Before
    public void init() {
        sessionRepository = Mockito.mock(SessionRepository.class);
    }

    @Test(expected = SessionException.class)
    public void startSessionFailedNoStartDate() {
        Session session = new Session();
        when(sessionRepository.save(session)).thenReturn(session);
        sessionService.startSession(session);
    }

    @Test(expected = SessionException.class)
    public void stopSessionFailedNoEndDate() {
        Session session = new Session("Test", new Date());
        when(sessionRepository.save(session)).thenReturn(session);
        sessionService.stopSession(session);
    }

    @Test(expected = SessionException.class)
    public void stopSessionFailedEndDateBeforeStartDate() {
        Session session = new Session("Test", new Date() , new Date(1908));
        when(sessionRepository.save(session)).thenReturn(session);
        Session savedSession = sessionService.stopSession(session);
    }

    @Test
    public void startSessionSucces() {
        Session session = new Session("Test", new Date());
        when(sessionRepository.save(session)).thenReturn(session);
        sessionService.startSession(session);
    }

    @Test
    public void stopSessionSucces() {
        Session session = new Session("Test", new Date(), new Date());
        when(sessionRepository.save(session)).thenReturn(session);
        sessionService.stopSession(session);
    }

}
