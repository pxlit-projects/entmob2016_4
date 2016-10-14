package be.pxl.backend.repositories;

import be.pxl.backend.models.Session;
import be.pxl.backend.models.User;

import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */
public interface SessionDao {

    Session startSession(Session session);
    Session stopSession(Session session);

    List<Session> allSessions(User user);
    Session getSessionById(int id);
}
