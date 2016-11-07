package be.pxl.backend.repositories;

import be.pxl.backend.models.Session;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.*;

/**
 * Created by Jonas on 7/10/16.
 */
@Repository
public interface SessionRepository extends CrudRepository<Session, Integer> {

    @Transactional(readOnly = true)
    @Query(value = "select s.id from Session s where s.user.name =:name and s.end is NOT NULL")
    List<Integer> getAllSessions(@Param(value = "name") String name);

}
