package be.pxl.backend.services;

import static org.junit.Assert.assertTrue;

import be.pxl.backend.exceptions.SessionException;
import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.SessionRepository;
import be.pxl.backend.start.Application;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.boot.test.SpringApplicationConfiguration;
import org.springframework.test.context.ActiveProfiles;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import java.util.Date;

/**
 * Created by Jonas on 6/11/16.
 */

@RunWith(SpringJUnit4ClassRunner.class)
@SpringApplicationConfiguration(classes = Application.class)
public class SessionRepositoryTest {


    private SessionService sessionService;

    @Mock
    private SessionRepository sessionRepository;

    @Before
    public void init() {
        MockitoAnnotations.initMocks(this);
        sessionService = new SessionService();
        sessionService.setSessionRepository(sessionRepository);
    }

    @Test(expected = SessionException.class)
    public void addSessionFailedNoStartDate() {
        Session session = new Session();
        sessionService.startSession(session);
    }

    @Test(expected = SessionException.class)
    public void addSessionFailedEnd() {
        Session session = new Session("Test", new Date());
        Session savedSession = sessionService.stopSession(session);
    }

}
