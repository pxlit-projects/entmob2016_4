package be.pxl.backend.repositories;

import be.pxl.backend.models.Session;
import org.springframework.data.repository.CrudRepository;
import org.springframework.stereotype.Repository;

import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository
public interface SessionRepository extends CrudRepository<Session, Integer> {

    List<Session> getAllSessions();

}
