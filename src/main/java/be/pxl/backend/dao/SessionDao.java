package be.pxl.backend.dao;

import be.pxl.backend.models.Session;
import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */
public interface SessionDao {

    Session startSession(Session session);
    Session stopSession(Session session);

    List<Session> allSessions();
    Session getSessionById(int id);
}
