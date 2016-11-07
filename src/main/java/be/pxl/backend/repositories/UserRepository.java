package be.pxl.backend.repositories;

import be.pxl.backend.models.User;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.CrudRepository;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import java.util.List;

/**
 * Created by Jonas on 7/10/16.
 */

@Repository
public interface UserRepository extends CrudRepository<User, Integer> {

    @Query(value = "select u from User u where u.name =:username")
    User getUserByUsername(@Param(value = "username") String username);

}

