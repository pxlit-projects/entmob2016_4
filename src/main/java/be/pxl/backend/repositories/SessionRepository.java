package be.pxl.backend.repositories;

import be.pxl.backend.models.Session;
import be.pxl.backend.models.User;
import org.springframework.data.repository.CrudRepository;

import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */
public interface SessionRepository extends CrudRepository<Session, Integer> {

    List<Session> allSessions();

}
