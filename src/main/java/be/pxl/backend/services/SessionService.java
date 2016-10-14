package be.pxl.backend.services;

import be.pxl.backend.models.Session;
import be.pxl.backend.repositories.SessionRepository;
import org.springframework.beans.factory.annotation.Autowired;

import java.util.List;

/**
 * Created by Jonas on 14/10/16.
 */
public class SessionService {

    @Autowired
    private SessionRepository sessionRepository;

    public Session startSession(Session session) {
        if (session.getStart() != null && session.getEnd() == null) {
            return sessionRepository.save(session);
        } else {
            return null;
        }
    }

    public Session stopSession(Session session) {
        if (session.getStart() != null && session.getEnd() != null) {
            return sessionRepository.save(session);
        } else {
            return null;
        }
    }

    public Session getSessionById(int id) {
        return sessionRepository.findOne(id);
    }

    public List<Session> getAllSessions() {
        return sessionRepository.allSessions();
    }

}
